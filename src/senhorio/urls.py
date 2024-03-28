

from django.urls import path
from . import views

urlpatterns = [
    path('listar_senhorios/', views.listar_senhorios, name='listar_senhorios'),
    path('criar/', views.criar_senhorio, name='criar_senhorio'),
    path('detalhes/<int:id>/', views.detalhes_senhorio, name='detalhes_senhorio'),
    path('atualizar/<int:id>/', views.atualizar_senhorio, name='atualizar_senhorio'),
    path('apagar/<int:id>/', views.apagar_senhorio, name='apagar_senhorio'),
    path('gerenciar/', views.gerenciar_senhorios, name='gerenciar_senhorios'),
]