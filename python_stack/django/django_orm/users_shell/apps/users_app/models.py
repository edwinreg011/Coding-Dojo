from django.db import models

class User(models.Model):
  first_name = models.CharField(max_length=45)
  last_name = models.CharField(max_length=45)
  email_address = models.CharField(max_length=45)
  age = models.IntegerField()


  def __repr__(self):
    return f"First name: {self.first_name} Last Name: {self.last_name} Email: {self.email_address} Age: {self.age}"

