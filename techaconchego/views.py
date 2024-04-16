from django.shortcuts import render, redirect, get_object_or_404
from django.contrib import messages
from django.contrib.auth.decorators import login_required
from django.contrib.auth import authenticate, login


from .models import Estudante, Nota
from .models import Senhorio
from .models import Alojamento

from .forms import EstudanteForm
from .forms import SenhorioForm
from .forms import AlojamentoForm

from django.contrib.auth.models import User
from django.db.models.signals import post_save
from django.dispatch import receiver
from .models import UserProfile

@receiver(post_save, sender=User)
def create_user_profile(sender, instance, created, **kwargs):
    if created:
        UserProfile.objects.create(user=instance)

@receiver(post_save, sender=User)
def save_user_profile(sender, instance, **kwargs):
    instance.userprofile.save()

##  registo de utilizadores, estudante, senhorio, prestserviços

from .forms import UserRegistrationForm,UserLoginForm

def register(request):
    if request.method == 'POST':
        form = UserRegistrationForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('login')
    else:
        form = UserRegistrationForm()
    return render(request, 'registration/register.html', {'form': form})

def user_login(request):
    if request.method == 'POST':
        form = UserLoginForm(request.POST)
        if form.is_valid():
            username = form.cleaned_data['username']
            password = form.cleaned_data['password']
            user = authenticate(username=username, password=password)
            if user:
                login(request, user)
                if user.userprofile.is_student:
                    # Redirecione para a página do estudante
                    return redirect('student_dashboard')
                elif user.userprofile.is_landlord:
                    # Redirecione para a página do senhorio
                    return redirect('landlord_dashboard')
    else:
        form = UserLoginForm()
    return render(request, 'registration/login.html', {'form': form})





## Principais ####################################################################

## Função subsituida pela generica 
# def login(request):
    ##return render(request, 'loginestudante.html',{'title': 'TechAconchego Alojamento Login'})

def about(request):
    return render(request, 'about.html', {'title': 'TechAconchego Alojamento About'})


## ALOJAMENTO ####################################################################

def home(request):
    return render(request, 'home.html', {'title': 'TechAconchego Alojamento Home'})

def criar_alojamento(request):
    if request.method == 'POST':
        form = AlojamentoForm(request.POST)
        try:
            if form.is_valid():
                form.save()
                return redirect('listar_alojamentos')
        except Exception as e:
            return render(request, ' criar_alojamento.html', {'form': form, 'error': str(e)})
    else:
        form = AlojamentoForm()
    return render(request, 'criar_alojamento.html', {'form': form})

## versão simples
def listar_alojamentos(request):
    alojamentos = Alojamento.objects.all()
    return render(request, 'listar_alojamentos.html', {'alojamentos': alojamentos})

## versão com teste de user
def listar_alojamentos(request):
    if request.user.is_authenticated and request.user.userprofile.is_student:
        alojamentos = Alojamento.objects.all()
        return render(request, 'listar_alojamentos.html', {'alojamentos': alojamentos})
    else:
        # Redirecionar para a página de login se o usuário não estiver autenticado ou não for um estudante
        return redirect('login')



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
    else:
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
    estudante = get_object_or_404(Estudante, ipk=id_estudante)
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