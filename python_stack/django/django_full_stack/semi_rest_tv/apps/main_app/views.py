from django.shortcuts import render, HttpResponse, redirect
from .models import *
from time import strftime, strptime
from django.contrib import messages

def index(request):
  return redirect("/shows")



def shows(request):
  all_shows = Show.objects.all()
  context = {
    "all_shows_tb": all_shows
  }
  return render (request, 'main_app/index.html', context)



def new_show(request):
  return render (request, 'main_app/newshow.html')



def create(request):
  if request.method == 'POST':
    errors = Show.objects.basic_validator(request.POST)
    if len(errors) > 0:
      for key, value in errors.items():
        messages.error(request, value)
      return redirect('/shows/new')
    else:
      new_show = Show.objects.create(
      title = request.POST['title'],
      network = request.POST['network'],
      release_date = request.POST['release_date'],
      desc = request.POST['desc'])
      new_show_id = new_show.id
      return redirect (f"/shows/{new_show_id}")



def display_show(request, show_id):
  new_show = Show.objects.get(id = show_id)
  format_release = new_show.release_date.strftime('%d %B, %Y')
  context = {
    "release_date_view": format_release,
    "show_view": new_show,
  }
  return render(request, "main_app/viewshow.html", context)



def edit(request, show_id):
  show = Show.objects.get(id = show_id)
  context = {
    "show_view": show
  }
  return render(request, "main_app/editshow.html", context)



def update(request, show_id):
  if request.method == 'POST':
    errors = Show.objects.basic_validator(request.POST)
    if len(errors) > 0:
      for key, value in errors.items():
        messages.error(request, value)
      return redirect(f"/shows/{show_id}/edit")
    else:
      show = Show.objects.get(id = show_id)
      show.title = request.POST['title']
      show.network = request.POST['network']
      show.release_date = request.POST['release_date']
      show.desc = request.POST['desc']
      show.save()
    return redirect(f"/shows/{show_id}")



def destroy(request, show_id):
  show = Show.objects.get(id = show_id)
  show.delete()
  return redirect('/shows')