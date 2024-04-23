from django import forms
from .models import Alojamento
from .models import Estudante
from .models import Senhorio


class AlojamentoForm(forms.ModelForm):
    class Meta:
        model = Alojamento
        fields = ['renda_base', 'id_senhorio', 'nquartos', 'aluguerparcial', 'nquartoslivres']

class EstudanteForm(forms.ModelForm):
    class Meta:
        model = Estudante
        fields = ['id_estudante', 'nome', 'password', 'id_desconto']

class SenhorioForm(forms.ModelForm):
    class Meta:
        model = Senhorio
        fields = ['nome', 'password']



## funções de registo de utilizazores 

from django import forms
from django.contrib.auth.models import User

class UserRegistrationForm(forms.ModelForm):
    CHOICES = [('student', 'Estudante'), ('landlord', 'Senhorio'),('tech','Manutenção')]
    account_type = forms.ChoiceField(choices=CHOICES)
    password = forms.CharField(widget=forms.PasswordInput)

    class Meta:
        model = User
        fields = ['username', 'email', 'password', 'account_type']
        widgets = {'password': forms.PasswordInput()}


 




class UserLoginForm(forms.Form):
    username = forms.CharField()
    password = forms.CharField(widget=forms.PasswordInput)
    

