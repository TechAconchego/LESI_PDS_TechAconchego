from django.shortcuts import render

# Create your views here.
from django.shortcuts import render, redirect, get_object_or_404
from .models import Estudante, Nota
from .forms import EstudanteForm

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
