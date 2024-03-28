# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.

from django.db import models

# Create your models here.


class Estudante(models.Model):
    id_estudante = models.AutoField(primary_key=True)
    nome = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    id_desconto = models.ForeignKey(Desconto, models.DO_NOTHING, db_column='id_desconto', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'estudante'


class Nota(models.Model):
    id_estudante = models.OneToOneField(Estudante, models.DO_NOTHING, db_column='id_estudante', primary_key=True)  # The composite primary key (id_estudante, curso, anolectivo, uc) found, that is not supported. The first column is selected.
    curso = models.IntegerField()
    anolectivo = models.CharField(max_length=255)
    uc = models.CharField(max_length=255)
    classificacao = models.IntegerField(blank=True, null=True)
    id_desconto = models.ForeignKey(Desconto, models.DO_NOTHING, db_column='id_desconto')

    class Meta:
        managed = False
        db_table = 'nota'
        unique_together = (('id_estudante', 'curso', 'anolectivo', 'uc'),)

class Desconto(models.Model):
    id_desconto = models.AutoField(primary_key=True)
    valor = models.IntegerField()

    class Meta:
        managed = False
        db_table = 'desconto'