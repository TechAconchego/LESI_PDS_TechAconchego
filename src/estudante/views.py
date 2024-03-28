from django.shortcuts import render

# Create your views here.

from django.shortcuts import render, redirect, get_object_or_404
from django.http import JsonResponse
from .models import Estudante

from .forms import EstudanteForm

def criar_estudante(request):
    if request.method == 'POST':
        form = EstudanteForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('listar_estudantes')
    else:
        form = EstudanteForm()
    return render(request, 'criar_estudante.html', {'form': form})

def listar_estudantes(request):
    estudantes = Estudante.objects.all()
    return render(request, 'listar_estudantes.html', {'estudantes': estudantes})

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

def excluir_estudante(request, id_estudante):
    estudante = get_object_or_404(Estudante, id_estudante=id_estudante)
    estudante.delete()
    return redirect('listar_estudantes')