# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2019-10-17 18:42
from __future__ import unicode_literals

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('login_app', '0002_auto_20191017_1803'),
    ]

    operations = [
        migrations.RenameField(
            model_name='comment',
            old_name='commenter',
            new_name='user',
        ),
        migrations.RenameField(
            model_name='message',
            old_name='creator',
            new_name='user',
        ),
    ]
