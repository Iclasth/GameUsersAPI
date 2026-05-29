import { Component } from '@angular/core';
import { AuthCard } from '../../../shared/components/auth-card/auth-card';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-login',
  imports: [AuthCard, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {}
