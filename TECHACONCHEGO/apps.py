from django.apps import AppConfig


class AlojamentoConfig(AppConfig):
    default_auto_field = 'django.db.models.BigAutoField'
    name = 'alojamento'
    ## verbose_name = 'Alojamento Config

class EstudanteConfig(AppConfig):
    default_auto_field = 'django.db.models.BigAutoField'
    name = 'estudante'

class ManutencaoConfig(AppConfig):
    default_auto_field = 'django.db.models.BigAutoField'
    name = 'manutencao'

class SenhorioConfig(AppConfig):
    default_auto_field = 'django.db.models.BigAutoField'
    name = 'senhorio'
