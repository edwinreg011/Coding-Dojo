from django.shortcuts import render, HttpResponse, redirect 
from django.utils.crypto import get_random_string

def index(request):
  if 'count'  not in request.session:
    request.session['count'] = 0
  return render(request, 'first_app/index.html')

def generate(request):
  if request.method == 'POST':
    request.session['count'] += 1
    request.session['randword'] = get_random_string(length=14)
  return redirect('/')

def reset(request):
  del request.session['count']
  del request.session['randword']
  return redirect('/')