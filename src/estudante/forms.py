from django import forms
from .models import Estudante

class EstudanteForm(forms.ModelForm):
    class Meta:
        model = Estudante
        fields = ['id_estudante', 'nome', 'password', 'id_desconto']
