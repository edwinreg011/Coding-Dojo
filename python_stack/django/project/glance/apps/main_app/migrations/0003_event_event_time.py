# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2019-10-22 18:36
from __future__ import unicode_literals

from django.db import migrations, models
import django.utils.timezone


class Migration(migrations.Migration):

    dependencies = [
        ('main_app', '0002_event'),
    ]

    operations = [
        migrations.AddField(
            model_name='event',
            name='event_time',
            field=models.TimeField(default=django.utils.timezone.now),
            preserve_default=False,
        ),
    ]
