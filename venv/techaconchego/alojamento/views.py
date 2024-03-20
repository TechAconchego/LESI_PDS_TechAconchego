from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.


# criar as views da app alojamento, para serem chamadas
# no main TechAconchego

def home(request):
    return HttpResponse('<h1>TechAconchego Alojamento Home</h1>')


def about(request):
    return HttpResponse('<h1>TechAconchego Alojamento About</h1>')