from django.shortcuts import render, HttpResponse, redirect
from .models import User

def index(request):
  context = {
    "all_users": User.objects.all()
  }
  return render(request,'users_app/index.html', context)