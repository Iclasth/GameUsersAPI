import { Component, inject } from '@angular/core';
import { AuthCard } from '../../../shared/components/auth-card/auth-card';
import { FormField } from '../../../shared/components/form-field/form-field';
import { Router, RouterLink } from "@angular/router";
import { ReactiveFormsModule, FormControl, FormGroup, Validators} from '@angular/forms';
import { Auth } from '../../../core/services/auth';
@Component({
  selector: 'app-login',
  imports: [AuthCard, RouterLink, FormField, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  private authService = inject(Auth)
  private router = inject(Router)

  loginForm = new FormGroup({
    username: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(25)]),
    password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(100)])
  });

  onsubmit() 
  {
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value).subscribe({
        next: (response) => {
          console.log('Login feito com sucesso!', response);
          this.router.navigate(['/home']);
        },
        error: (err) => {
          console.error('Falha no login: ', err);
        },
      })
    }
    else {
      console.log('Dados inválidos! ')
    }
  } 
}



