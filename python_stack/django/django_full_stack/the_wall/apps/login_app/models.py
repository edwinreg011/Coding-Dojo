from __future__ import unicode_literals
from django.db import models
import re


class UserManager(models.Manager):
    def user_validator(self, data):
        errors = {}
        EMAIL_REGEX = re.compile(
            r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

        if len(data['first_name']) <= 2:
            errors['first_name'] = 'Please enter valid first name'
        if len(data['last_name']) <= 2:
            errors['lsat_name'] = 'Please enter valid last name.'

        if not EMAIL_REGEX.match(data['email']):
            errors['email'] = "Invalid email address!"
        try:
            User.objects.get(email=data['email'])
            errors['email'] = 'Email already in use.'
        except:
            pass

        if len(data['password']) <= 7:
            errors['password'] = 'Please enter a password 8 characters or more'
        if data['password'] != data['confirm_password']:
            errors['confirm_password'] = 'Passwords do not match'
        return errors


class User(models.Model):
    first_name = models.CharField(max_length=45)
    last_name = models.CharField(max_length=45)
    email = models.CharField(max_length=45)
    password = models.CharField(max_length=45)
    confirm_password = models.CharField(max_length=45)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()


class Message(models.Model):
    message = models.TextField()
    user = models.ForeignKey(User, related_name='messages')
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()


class Comment(models.Model):
    comment = models.TextField()
    message = models.ForeignKey(Message, related_name='comments')
    user = models.ForeignKey(User, related_name='commenter')
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()
