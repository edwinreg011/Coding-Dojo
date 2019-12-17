from django.conf.urls import url
from . import views

urlpatterns = [
  url(r'^$', views.index),
  url(r'^template$', views.temp),
  url(r'^dict$', views.passData),
]