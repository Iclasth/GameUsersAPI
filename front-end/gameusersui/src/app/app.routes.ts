import { Routes } from '@angular/router';
import { Login } from './feature/auth/login/login';

export const routes: Routes = [
    {
        path: 'login', // URL que o usuário acessa
        component: Login // Componente em questão
    },
    {
        // Caminho padrão apontando para a tela de login 
        path: '', redirectTo: 'login', pathMatch: 'full'
    }
];
