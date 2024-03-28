from django import forms
from .models import Senhorio

class SenhorioForm(forms.ModelForm):
    class Meta:
        model = Senhorio
        fields = ['nome', 'password']
