from django.shortcuts import render, HttpResponse

def index(request):
  return HttpResponse("this is the equivalent of app.route('/') !")

def temp(request):
  return render (request, "first_app/index.html")

def passData(request):
  context = {
    "name": "Edwin",
    "fav_color": "Black",
    "pets": ["Luna", "Tuna", "Jona"]
  }
  return render (request, "first_app/index.html", context)