from django.db import models

class Dojo(models.Model):
  name = models.CharField(max_length=255)
  city = models.CharField(max_length=255)
  state = models.CharField(max_length=2)
  desc = models.TextField()
  created_at = models.DateTimeField(auto_now_add=True)
  updated_at = models.DateTimeField(auto_now=True)
  def __repr__(self):
    return f"Dojo name: {self.name} City: {self.city} State: {self.state} Description: {self.desc}"

class Ninja(models.Model):
  first_name = models.CharField(max_length=255)
  last_name = models.CharField(max_length=255)
  dojo = models.ForeignKey(Dojo, related_name='ninjas')
  created_at = models.DateTimeField(auto_now_add=True)
  updated_at = models.DateTimeField(auto_now=True)
  def __repr__(self):
    return f"First name: {self.first_name} Last Name: {self.last_name} Dojo: {self.dojo}"