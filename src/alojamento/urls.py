from django.urls import path, include
from . import views

urlpatterns = [
    path('', views.home, name='alojamento-home'),
    path('about/', views.about, name='alojamento-about'),
    path('criar/', views.criar_alojamento, name='criar_alojamento'),
    path('listar/', views.listar_alojamentos, name='listar_alojamentos'),
    path('<int:id_alojamento>/', views.detalhes_alojamento, name='detalhes_alojamento'),
    path('<int:id_alojamento>/atualizar/', views.atualizar_alojamento, name='atualizar_alojamento'),
    path('<int:id_alojamento>/apagar/', views.apagar_alojamento, name='apagar_alojamento'),
]
