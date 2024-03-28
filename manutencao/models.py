# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.

from django.db import models

# Create your models here.


class Prestador(models.Model):
    id_prestador = models.IntegerField(primary_key=True)  # The composite primary key (id_prestador, id_tipo) found, that is not supported. The first column is selected.
    id_tipo = models.IntegerField()
    nome = models.CharField(max_length=255)

    class Meta:
        managed = False
        db_table = 'prestador'
        unique_together = (('id_prestador', 'id_tipo'),)

