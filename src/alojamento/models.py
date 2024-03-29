# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.

from django.db import models
from senhorio.models import Senhorio
from estudante.models import Estudante


# Create your models here.

class Alojamento(models.Model):
    id_alojamento = models.AutoField(primary_key=True)
    renda_base = models.FloatField(db_column='renda_base')  # Corrigido o nome do campo
    id_senhorio = models.ForeignKey(Senhorio, models.DO_NOTHING, db_column='id_senhorio')
    nquartos = models.IntegerField()
    aluguerparcial = models.CharField(max_length=255)
    nquartoslivres = models.IntegerField()

    class Meta:
        managed = True
        db_table = 'alojamento'

class Aluguer(models.Model):
    id_estudante = models.OneToOneField(Estudante, models.DO_NOTHING, db_column='id_estudante', primary_key=True)
    id_senhorio = models.IntegerField()
    id_alojamento = models.ForeignKey(Alojamento, models.DO_NOTHING, db_column='id_alojamento')
    data_inicio = models.DateTimeField()
    data_fim = models.DateTimeField(blank=True, null=True)
    renda_final = models.IntegerField(db_column='renda_final')  # Corrigido o nome do campo

    class Meta:
        managed = True
        db_table = 'aluguer'
        unique_together = (('id_estudante', 'id_senhorio', 'id_alojamento', 'data_inicio'),)



