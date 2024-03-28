from django import forms
from .models import Estudante

class EstudanteForm(forms.ModelForm):
    class Meta:
        model = Estudante
        fields = ['nome', 'password', 'id_desconto']
