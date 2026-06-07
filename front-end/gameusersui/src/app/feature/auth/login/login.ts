import { Component } from '@angular/core';
import { AuthCard } from '../../../shared/components/auth-card/auth-card';
import { FormField } from '../../../shared/components/form-field/form-field';
import { RouterLink } from "@angular/router";
import { ReactiveFormsModule, FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [AuthCard, RouterLink, FormField, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  loginForm = new FormGroup({
    username: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(25)]),
    password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(100)])
  });

  onsubmit() 
  {
    if (this.loginForm.valid) {
      console.log('Dados do formulário: ', this.loginForm.value);
    }
    else {
      console.log('Dados inválidos! ')
    }
  } 
}



