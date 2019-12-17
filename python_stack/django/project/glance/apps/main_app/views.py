from django.shortcuts import render, HttpResponse, redirect
from .models import *
from datetime import datetime, date
from time import strftime, strptime
from django.contrib import messages
import bcrypt


def index(request):
    return render(request, 'main_app/index.html')


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


def logout(request):
    del request.session['user_id']
    del request.session['first_name']
    return redirect('/')


def check_login(request):
    if not 'first_name' in request.session:
        messages.error(request, 'Log in to view this page')
        return False
    return True


#### GLANCE APP ####


def success(request):
    if not check_login(request):
        return redirect('/')
    all_events = Event.objects.all().order_by("event_time").filter(event_date = datetime.today())
    context = {
        "all_events_tb": all_events
    }
    return render(request, 'main_app/success.html', context)


def new_event(request):
    return render(request, 'main_app/newevent.html')


def create_event(request):
  if request.method == 'POST':
    errors = Event.objects.basic_validator(request.POST)
    if len(errors) > 0:
      for key, value in errors.items():
        messages.error(request, value)
      return redirect('/users/events/new')
    else:
      new_event = Event.objects.create(title=request.POST['title'],
      location=request.POST['location'],
      event_date=request.POST['event_date'],
      event_time=request.POST['event_time'],
      desc=request.POST['desc'],
      user=User.objects.get(first_name=request.session['first_name']))
      new_event_id = new_event.id
      return redirect(f"/users/success")


def view_event(request, event_id):
  new_event = Event.objects.get(id=event_id)
  context = {
    "event_view": new_event,
  }
  return render(request, 'main_app/viewevent.html', context)


def edit_event(request, event_id):
  event = Event.objects.get(id=event_id)
  context = {
    "event_view": event,
  }
  return render(request, 'main_app/editevent.html', context)


def update(request, event_id):
  if request.method == "POST":
    errors = Event.objects.basic_validator(request.POST)
    if len(errors) > 0:
      for key, value in errors.items():
        messages.error(request, value)
      return redirect(f'/users/events/edit/{event_id}')
    else:
      event = Event.objects.get(id = event_id)
      event.title = request.POST['title']
      event.location = request.POST['location']
      event.event_date = request.POST['event_date']
      event.event_time = request.POST['event_time']
      event.desc = request.POST['desc']
      event.save()
      return redirect("/users/success")

def delete_event(request, event_id):
  event = Event.objects.get(id = event_id)
  event.delete()
  return redirect("/users/success")
