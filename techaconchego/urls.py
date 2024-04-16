"""
URL configuration for techaconchego project.

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/5.0/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.contrib import admin
from django.urls import path, include

from django.contrib.auth import views as autentic_views  # permite importar views de sistema
                                                        # para controlo de autenticação
                                                        
from . import views

urlpatterns = [
    path('admin/', admin.site.urls),
#    path('', include('alojamento.urls')),
#    path('estudante/', include('estudante.urls')),
#    path('senhorio/', include('senhorio.urls')),
    path('', views.home, name='home'),
    path('about/', views.about, name='about'),
    
    path('criar/', views.criar_alojamento, name='criar_alojamento'),
    path('listar/', views.listar_alojamentos, name='listar_alojamentos'),
    
    path('<int:id_alojamento>/', views.detalhes_alojamento, name='detalhes_alojamento'),
    path('<int:id_alojamento>/atualizar/', views.atualizar_alojamento, name='atualizar_alojamento'),
    path('<int:id_alojamento>/apagar/', views.apagar_alojamento, name='apagar_alojamento'),
    path('listar_senhorios/', views.listar_senhorios, name='listar_senhorios'),
    path('criar/', views.criar_senhorio, name='criar_senhorio'),
    path('detalhes/<int:id>/', views.detalhes_senhorio, name='detalhes_senhorio'),
    path('atualizar/<int:id>/', views.atualizar_senhorio, name='atualizar_senhorio'),
    path('apagar/<int:id>/', views.apagar_senhorio, name='apagar_senhorio'),
    path('gerenciar/', views.gerenciar_senhorios, name='gerenciar_senhorios'),
    path('criar_estudante/', views.criar_estudante, name='criar_estudante'),
    path('listar_estudantes/', views.listar_estudantes, name='listar_estudantes'),
    path('atualizar_estudantes/<int:id_estudante>/', views.atualizar_estudante, name='atualizar_estudante'),
    path('excluir_estudante/<int:id_estudante>/', views.excluir_estudante, name='excluir_estudante'),
    path('gerenciar/', views.gerenciar_estudantes, name='gerenciar_estudantes'),
    
    ## path('login/',autentic_views.LoginView.as_view(template_name='loginestudante.html'),name='login'),
    
    ## nova abordagem ao registo e login
        path('register/', views.register, name='register'),
        ## path('login/', views.user_login, name='login'), não usar, a de baixo, permite enviar argumentos
        path('login/', autentic_views.LoginView.as_view(template_name='registration/login.html'), name='login'),
        
]