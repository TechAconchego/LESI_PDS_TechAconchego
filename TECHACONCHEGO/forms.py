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
