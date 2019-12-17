from django.shortcuts import render, HttpResponse, redirect
import random
from datetime import datetime

def index(request):
  if 'gold' not in request.session:
    request.session['gold'] = 0
  if 'activities' not in request.session:
    request.session['activities'] = []
  return render(request, 'first_app/index.html')

def money(request):
  now = datetime.today()
  if request.method == 'POST':
    if request.POST['building'] == 'farm':
      request.session['amount'] = random.randint(10,20)
      request.session['gold'] += request.session['amount']
      request.session['activities'].append('You earned' + ' ' + str(request.session['amount']) + ' ' + 'gold!' + ' ' + 'on' + ' ' + now.strftime("%B %d, %Y") + ' ' + 'at' + ' ' + now.strftime("%I:%M %p"))

    
    if request.POST['building'] == 'cave':
      request.session['amount'] = random.randint(5,10)
      request.session['gold'] += request.session['amount']
      request.session['activities'].append('You earned' + ' ' + str(request.session['amount']) + ' ' + 'gold!' + ' ' + 'on' + ' ' + now.strftime("%B %d, %Y") + ' ' + 'at' + ' ' + now.strftime("%I:%M %p"))

    
    if request.POST['building'] == 'house':
      request.session['amount'] = random.randint(2,5)
      request.session['gold'] += request.session['amount']
      request.session['activities'].append('You earned' + ' ' + str(request.session['amount']) + ' ' + 'gold!' + ' ' + 'on' + ' ' + now.strftime("%B %d, %Y") + ' ' + 'at' + ' ' + now.strftime("%I:%M %p"))

    
    if request.POST['building'] == 'casino':
      request.session['amount'] = random.randint(-50,50)
      request.session['gold'] += request.session['amount']
      if request.session['amount'] > 0:
        request.session['activities'].append('You earned' + ' ' + str(request.session['amount']) + ' ' + 'gold!' + ' ' + 'on' + ' ' + now.strftime("%B %d, %Y") + ' ' + 'at' + ' ' + now.strftime("%I:%M %p"))
      elif request.session['amount'] < 0:
        request.session['activities'].append('Oh no! You lost' + ' ' + str(request.session['amount']) + ' ' + 'gold!' + ' ' + 'on' + ' ' + now.strftime("%B %d, %Y") + ' ' + 'at' + ' ' + now.strftime("%I:%M %p"))

  return redirect('/')

def reset(request):
  del request.session['gold']
  del request.session['activities']
  return redirect('/')
