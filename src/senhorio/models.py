# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.


from django.db import models

# Create your models here.


class Senhorio(models.Model):
    id_senhorio = models.AutoField(primary_key=True)
    nome = models.CharField(max_length=255)
    password = models.IntegerField()

    class Meta:
        managed = False
        db_table = 'senhorio'


class Desconto(models.Model):
    id_desconto = models.AutoField(primary_key=True)
    valor = models.IntegerField()

    class Meta:
        managed = False
        db_table = 'desconto'