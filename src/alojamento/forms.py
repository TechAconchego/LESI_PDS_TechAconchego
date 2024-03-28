from django import forms
from .models import Alojamento

class AlojamentoForm(forms.ModelForm):
    class Meta:
        model = Alojamento
        fields = ['renda_base', 'id_senhorio', 'nquartos', 'aluguerparcial', 'nquartoslivres']
