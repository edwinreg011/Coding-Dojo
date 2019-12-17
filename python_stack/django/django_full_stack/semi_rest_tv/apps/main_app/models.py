from __future__ import unicode_literals
from django.db import models
from datetime import date, datetime

class ShowManager(models.Manager):
  def basic_validator(self, data):
    errors = {}
    if len(data['title']) <= 0:
      errors['title'] = "Title input too short."
    if len(data['network']) <= 0:
      errors['network'] = "Network input too short."
    if len(data['desc']) < 10:
      errors['desc'] = "Description must be at least 10 characters"
    if len(data['release_date']) > 0 and datetime.strptime(data["release_date"], '%Y-%m-%d') > datetime.today():
      errors['release_date'] = "Future date is invalid."
    return errors

class Show(models.Model):
  title = models.CharField(max_length=45)
  network = models.CharField(max_length=45)
  release_date = models.DateField()
  desc = models.TextField()
  objects = ShowManager()