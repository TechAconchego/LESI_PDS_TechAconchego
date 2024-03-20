from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.


# criar as views da app alojamento, para serem chamadas
# no main TechAconchego

## usando httpresponse
## def home(request):
   ## return HttpResponse('<h1>TechAconchego Alojamento Home</h1>')

## def about(request):
    ## return HttpResponse('<h1>TechAconchego Alojamento About</h1>')

# usando render

def home(request):
    return render(request, 'alojamento/home.html', {'title': 'TechAconchego Alojamento Home'})

def about(request):
    return render(request, 'alojamento/about.html', {'title': 'TechAconchego Alojamento About'})
