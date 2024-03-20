from django.urls import path,include
from . import views

urlpatterns = [
    path('', views.home, name='alojamento-home'),
    path('about/', views.about, name='alojamento-about'),
]
