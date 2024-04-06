
from django.shortcuts import render, redirect, get_object_or_404
from .models import Estudante, Nota
from .models import Senhorio
from .forms import EstudanteForm
from .forms import SenhorioForm
from django.shortcuts import render, redirect, get_object_or_404
from .models import Alojamento
from .forms import AlojamentoForm


## ALOJAMENTO ####################################################################

def home(request):
    return render(request, 'alojamento.html', {'title': 'TechAconchego Alojamento Home'})

def about(request):
    return render(request, 'about.html', {'title': 'TechAconchego Alojamento About'})

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




## ESTUDANTE ############################################################

def listar_estudantes(request):
    estudantes = Estudante.objects.all()
    return render(request, 'listar_estudantes.html', {'estudantes': estudantes})

def criar_estudante(request):
    if request.method == 'POST':
        form = EstudanteForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('listar_estudantes')
    else:
        form = EstudanteForm()
    return render(request, 'criar_estudante.html', {'form': form})

def detalhes_estudante(request, id_estudante):
    estudante = get_object_or_404(Estudante, id_estudante=id_estudante)
    return render(request, 'detalhes_estudante.html', {'estudante': estudante})

def excluir_estudante(request, id_estudante):
    estudante = get_object_or_404(Estudante, id_estudante=id_estudante)
    estudante.delete()
    return redirect('listar_estudantes')

def atualizar_estudante(request, id_estudante):
    estudante = get_object_or_404(Estudante, id_estudante=id_estudante)
    if request.method == 'POST':
        form = EstudanteForm(request.POST, instance=estudante)
        if form.is_valid():
            form.save()
            return redirect('listar_estudantes')
    else:
        form = EstudanteForm(instance=estudante)
    return render(request, 'atualizar_estudante.html', {'form': form})

def gerenciar_estudantes(request):
    return render(request, 'estudante.html')




## SENHORIO ############################################################

def listar_senhorios(request):
    senhorios = Senhorio.objects.all()
    return render(request, 'listar_senhorios.html', {'senhorios': senhorios})

def criar_senhorio(request):
    if request.method == 'POST':
        form = SenhorioForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('listar_senhorios')
    else:
        form = SenhorioForm()
    return render(request, 'criar_senhorio.html', {'form': form})

def detalhes_senhorio(request, id):
    senhorio = get_object_or_404(Senhorio, pk=id)
    return render(request, 'detalhes_senhorio.html', {'senhorio': senhorio})

def atualizar_senhorio(request, id):
    senhorio = get_object_or_404(Senhorio, pk=id)
    if request.method == 'POST':
        form = SenhorioForm(request.POST, instance=senhorio)
        if form.is_valid():
            form.save()
            return redirect('listar_senhorios')
    else:
        form = SenhorioForm(instance=senhorio)
    return render(request, 'atualizar_senhorio.html', {'form': form})

def apagar_senhorio(request, id):
    senhorio = get_object_or_404(Senhorio, pk=id)
    if request.method == 'POST':
        senhorio.delete()
        return redirect('listar_senhorios')
    return render(request, 'apagar_senhorio.html', {'senhorio': senhorio})

def gerenciar_senhorios(request):
    return render(request, 'senhorio.html')