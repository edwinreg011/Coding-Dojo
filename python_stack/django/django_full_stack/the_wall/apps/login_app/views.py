from django.shortcuts import render, HttpResponse, redirect
from .models import *
from django.contrib import messages
import bcrypt


def index(request):
    return render(request, 'login_app/index.html')


def register(request):
    if request.method == 'POST':
        errors = User.objects.user_validator(request.POST)
        if len(errors) > 0:
            for key, value in errors.items():
                messages.error(request, value)
            return redirect('/')
        else:
            hashed_password = bcrypt.hashpw(
                request.POST['password'].encode(), bcrypt.gensalt())
            new_user = User.objects.create(
                first_name=request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password=hashed_password)
            request.session['user_id'] = new_user.id
            return redirect('/users/success')
    return redirect('/')


def login(request):
    if request.method == 'POST':
        try:
            user = User.objects.get(email=request.POST['email'])
        except:
            messages.error(request, 'Invalid username or password')
            return redirect('/')
        if bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
            request.session['first_name'] = user.first_name
            request.session['user_id'] = user.id
            return redirect('/users/success')
        else:
            messages.error(request, 'Invalid username or password')
            return redirect('/')
    return redirect('/')


def success(request):
    if not check_login(request):
        return redirect('/')
    context = {
        'user': User.objects.get(id=request.session['user_id']),
        'post_data': Message.objects.all(),
        'comment_data': Comment.objects.all(),
    }
    return render(request, 'login_app/success.html', context)


def logout(request):
    del request.session['user_id']
    del request.session['first_name']
    return redirect('/')


def check_login(request):
    if not 'first_name' in request.session:
        messages.error(request, 'Log in to view this page')
        return False
    return True


# THE_WALL

def add_message(request):
    Message.objects.create(message=request.POST['add_message'], user=User.objects.get(id=request.session['user_id']))
    return redirect('/users/success')

def add_comment(request):
  Comment.objects.create(comment = request.POST['add_comment'], user=User.objects.get(id=request.session['user_id']), message=Message.objects.get(id=request.POST['message_ID']))
  return redirect('/users/success')

def delete(request, id):
    m = Message.objects.get(id=id)
    m.delete()
    return redirect('/users/success')