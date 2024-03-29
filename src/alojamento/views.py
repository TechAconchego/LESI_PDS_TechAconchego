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
    return render(request, 'alojamento.html', {'title': 'TechAconchego Alojamento Home'})

def about(request):
    return render(request, 'about.html', {'title': 'TechAconchego Alojamento About'})


from django.shortcuts import render, redirect, get_object_or_404
from .models import Alojamento
from .forms import AlojamentoForm

def criar_alojamento(request):
    if request.method == 'POST':
        form = AlojamentoForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('listar_alojamentos')
    else:
        form = AlojamentoForm()
    return render(request, 'criar_alojamento.html', {'form': form})

def listar_alojamentos(request):
    alojamentos = Alojamento.objects.all()
    return render(request, 'listar_alojamentos.html', {'alojamentos': alojamentos})

def detalhes_alojamento(request, id_alojamento):
    alojamento = get_object_or_404(Alojamento, pk=id_alojamento)
    return render(request, 'detalhes_alojamento.html', {'alojamento': alojamento})

def atualizar_alojamento(request, id_alojamento):
    alojamento = get_object_or_404(Alojamento, pk=id_alojamento)
    if request.method == 'POST':
        form = AlojamentoForm(request.POST, instance=alojamento)
        if form.is_valid():
            form.save()
            return redirect('listar_alojamentos')
    else:
        form = AlojamentoForm(instance=alojamento)
    return render(request, 'atualizar_alojamento.html', {'form': form})

def apagar_alojamento(request, id_alojamento):
    alojamento = get_object_or_404(Alojamento, pk=id_alojamento)
    if request.method == 'POST':
        alojamento.delete()
        return redirect('listar_alojamentos')
    return render(request, 'apagar_alojamento.html', {'alojamento': alojamento})
