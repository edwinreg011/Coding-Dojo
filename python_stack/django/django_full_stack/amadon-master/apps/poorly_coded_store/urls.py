from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^buying$', views.buying),
    url(r'^checkout$', views.checkout),
    url(r'^reset$', views.reset),
]