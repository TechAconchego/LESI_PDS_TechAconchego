# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models


class Alojamento(models.Model):
    id_alojamento = models.AutoField(primary_key=True)
    renda_base = models.FloatField()
    nquartos = models.IntegerField()
    aluguerparcial = models.CharField(max_length=255)
    nquartoslivres = models.IntegerField()
    id_senhorio = models.ForeignKey('Senhorio', models.DO_NOTHING, db_column='id_senhorio')

    class Meta:
        managed = False
        db_table = 'alojamento'


class Aluguer(models.Model):
    id_estudante = models.OneToOneField('Estudante', models.DO_NOTHING, db_column='id_estudante', primary_key=True)
    id_senhorio = models.IntegerField()
    data_inicio = models.DateTimeField()
    data_fim = models.DateTimeField(blank=True, null=True)
    renda_final = models.IntegerField()
    id_alojamento = models.ForeignKey(Alojamento, models.DO_NOTHING, db_column='id_alojamento')

    class Meta:
        managed = False
        db_table = 'aluguer'
        unique_together = (('id_estudante', 'id_senhorio', 'id_alojamento', 'data_inicio'),)


class AuthGroup(models.Model):
    name = models.CharField(unique=True, max_length=150)

    class Meta:
        managed = False
        db_table = 'auth_group'


class AuthGroupPermissions(models.Model):
    id = models.BigAutoField(primary_key=True)
    group = models.ForeignKey(AuthGroup, models.DO_NOTHING)
    permission = models.ForeignKey('AuthPermission', models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_group_permissions'
        unique_together = (('group', 'permission'),)


class AuthPermission(models.Model):
    name = models.CharField(max_length=255)
    content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING)
    codename = models.CharField(max_length=100)

    class Meta:
        managed = False
        db_table = 'auth_permission'
        unique_together = (('content_type', 'codename'),)


class AuthUser(models.Model):
    password = models.CharField(max_length=128)
    last_login = models.DateTimeField(blank=True, null=True)
    is_superuser = models.BooleanField()
    username = models.CharField(unique=True, max_length=150)
    first_name = models.CharField(max_length=150)
    last_name = models.CharField(max_length=150)
    email = models.CharField(max_length=254)
    is_staff = models.BooleanField()
    is_active = models.BooleanField()
    date_joined = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'auth_user'


class AuthUserGroups(models.Model):
    id = models.BigAutoField(primary_key=True)
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)
    group = models.ForeignKey(AuthGroup, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_user_groups'
        unique_together = (('user', 'group'),)


class AuthUserUserPermissions(models.Model):
    id = models.BigAutoField(primary_key=True)
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)
    permission = models.ForeignKey(AuthPermission, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_user_user_permissions'
        unique_together = (('user', 'permission'),)


class ContratoServ(models.Model):
    id_senhorio = models.IntegerField(primary_key=True)
    id_tipo = models.IntegerField()
    inicio = models.DateTimeField()
    fim = models.DateTimeField(blank=True, null=True)
    mensalidade = models.IntegerField()
    id_alojamento = models.ForeignKey(Alojamento, models.DO_NOTHING, db_column='id_alojamento')
    id_prestador = models.ForeignKey('Prestador', models.DO_NOTHING, db_column='id_prestador')

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


class DjangoAdminLog(models.Model):
    action_time = models.DateTimeField()
    object_id = models.TextField(blank=True, null=True)
    object_repr = models.CharField(max_length=200)
    action_flag = models.SmallIntegerField()
    change_message = models.TextField()
    content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING, blank=True, null=True)
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'django_admin_log'


class DjangoContentType(models.Model):
    app_label = models.CharField(max_length=100)
    model = models.CharField(max_length=100)

    class Meta:
        managed = False
        db_table = 'django_content_type'
        unique_together = (('app_label', 'model'),)


class DjangoMigrations(models.Model):
    id = models.BigAutoField(primary_key=True)
    app = models.CharField(max_length=255)
    name = models.CharField(max_length=255)
    applied = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'django_migrations'


class Estudante(models.Model):
    id_estudante = models.AutoField(primary_key=True)
    nome = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    id_desconto = models.ForeignKey(Desconto, models.DO_NOTHING, db_column='id_desconto', blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'estudante'


class Nota(models.Model):
    id_estudante = models.OneToOneField(Estudante, models.DO_NOTHING, db_column='id_estudante', primary_key=True)
    curso = models.IntegerField()
    anolectivo = models.CharField(max_length=255)
    uc = models.CharField(max_length=255)
    classificacao = models.IntegerField(blank=True, null=True)
    id_desconto = models.ForeignKey(Desconto, models.DO_NOTHING, db_column='id_desconto')

    class Meta:
        managed = False
        db_table = 'nota'
        unique_together = (('id_estudante', 'curso', 'anolectivo', 'uc'),)


class Prestador(models.Model):
    id_prestador = models.IntegerField(primary_key=True)
    id_tipo = models.IntegerField()
    nome = models.CharField(max_length=255)

    class Meta:
        managed = False
        db_table = 'prestador'
        unique_together = (('id_prestador', 'id_tipo'),)


class Senhorio(models.Model):
    id_senhorio = models.AutoField(primary_key=True)
    nome = models.CharField(max_length=255)
    password = models.IntegerField()

    class Meta:
        managed = False
        db_table = 'senhorio'
