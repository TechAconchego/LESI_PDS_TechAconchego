# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.

from django.db import models

# Create your models here.

class Alojamento(models.Model):
    id_alojamento = models.AutoField(primary_key=True)
    renda_base = models.FloatField(db_column='Renda Base')  # Field name made lowercase. Field renamed to remove unsuitable characters.
    id_senhorio = models.ForeignKey('Senhorio', models.DO_NOTHING, db_column='id_senhorio')
    nquartos = models.IntegerField()
    aluguerparcial = models.CharField(max_length=255)
    nquartoslivres = models.IntegerField()

    class Meta:
        managed = False
        db_table = 'alojamento'

class Aluguer(models.Model):
    id_estudante = models.OneToOneField('Estudante', models.DO_NOTHING, db_column='id_estudante', primary_key=True)  # The composite primary key (id_estudante, id_senhorio, id_alojamento, data_inicio) found, that is not supported. The first column is selected.
    id_senhorio = models.IntegerField()
    id_alojamento = models.ForeignKey(Alojamento, models.DO_NOTHING, db_column='id_alojamento')
    data_inicio = models.DateTimeField()
    data_fim = models.DateTimeField(blank=True, null=True)
    renda_final = models.IntegerField(db_column='Renda Final')  # Field name made lowercase. Field renamed to remove unsuitable characters.

    class Meta:
        managed = False
        db_table = 'aluguer'
        unique_together = (('id_estudante', 'id_senhorio', 'id_alojamento', 'data_inicio'),)

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

class Desconto(models.Model):
    id_desconto = models.AutoField(primary_key=True)
    valor = models.IntegerField()

    class Meta:
        managed = False
        db_table = 'desconto'


