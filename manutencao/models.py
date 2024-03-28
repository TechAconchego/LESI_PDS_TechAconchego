# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.

from django.db import models
from alojamento.models import Alojamento

# Create your models here.


class Prestador(models.Model):
    id_prestador = models.IntegerField(primary_key=True)  # The composite primary key (id_prestador, id_tipo) found, that is not supported. The first column is selected.
    id_tipo = models.IntegerField()
    nome = models.CharField(max_length=255)

    class Meta:
        managed = False
        db_table = 'prestador'
        unique_together = (('id_prestador', 'id_tipo'),)

class ContratoServ(models.Model):
    id_senhorio = models.IntegerField(primary_key=True)  # The composite primary key (id_senhorio, id_prestador, id_tipo, id_alojamento) found, that is not supported. The first column is selected.
    id_prestador = models.ForeignKey('Prestador', models.DO_NOTHING, db_column='id_prestador')
    id_tipo = models.IntegerField()
    id_alojamento = models.ForeignKey(Alojamento, models.DO_NOTHING, db_column='id_alojamento')
    inicio = models.DateTimeField()
    fim = models.DateTimeField(blank=True, null=True)
    mensalidade = models.IntegerField()

    class Meta:
        managed = False
        db_table = 'contrato_serv'
        unique_together = (('id_senhorio', 'id_prestador', 'id_tipo', 'id_alojamento'),)
