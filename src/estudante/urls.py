from django.urls import path
from . import views

urlpatterns = [
    path('criar_estudante', views.criar_estudante, name='criar_estudante'),
    path('listar_estudantes/', views.listar_estudantes, name='listar_estudantes'),
    path('atualizar_estudantes//<int:id_estudante>/', views.atualizar_estudante, name='atualizar_estudante'),
    path('excluir_estudante/<int:id_estudante>/', views.excluir_estudante, name='excluir_estudante'),
    path('gerenciar/', views.gerenciar_estudantes, name='gerenciar_estudantes'),
]