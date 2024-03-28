# Generated by Django 5.0.3 on 2024-03-28 15:34

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='ContratoServ',
            fields=[
                ('id_senhorio', models.IntegerField(primary_key=True, serialize=False)),
                ('id_tipo', models.IntegerField()),
                ('inicio', models.DateTimeField()),
                ('fim', models.DateTimeField(blank=True, null=True)),
                ('mensalidade', models.IntegerField()),
            ],
            options={
                'db_table': 'contrato_serv',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Prestador',
            fields=[
                ('id_prestador', models.IntegerField(primary_key=True, serialize=False)),
                ('id_tipo', models.IntegerField()),
                ('nome', models.CharField(max_length=255)),
            ],
            options={
                'db_table': 'prestador',
                'managed': False,
            },
        ),
    ]