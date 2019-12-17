from django.conf.urls import url 
from . import views 

urlpatterns =[
  url(r'^$', views.index),
  url(r'^users/register$', views.register),
  url(r'^users/login$', views.login),
  url(r'^users/success$', views.success),
  url(r'^users/logout$', views.logout),
  url(r'^users/events/new$', views.new_event),
  url(r'^users/events/create$', views.create_event),
  url(r'^users/events/(?P<event_id>\d+)$', views.view_event),
  url(r'^users/events/edit/(?P<event_id>\d+)$', views.edit_event),
  url(r'^users/events/update/(?P<event_id>\d+)$', views.update),
  url(r'^users/events/delete/(?P<event_id>\d+)$', views.delete_event),
]
