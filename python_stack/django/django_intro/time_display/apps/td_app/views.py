from django.shortcuts import render, HttpResponse
from datetime import datetime, timezone

def index(request):
  now = datetime.today()
  context = {
    "date": now.strftime("%B %d, %Y"),
    "time": now.strftime("%I:%M %p")
  }
  return render(request, 'td_app/index.html', context)
