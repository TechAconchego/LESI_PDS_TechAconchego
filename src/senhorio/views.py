from django.shortcuts import render, redirect, get_object_or_404
from .models import Senhorio
from .forms import SenhorioForm

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