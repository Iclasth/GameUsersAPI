import { Routes } from '@angular/router';
import { Login } from './feature/auth/login/login';
import { Home } from './pages/home/home';
import { authGuardGuard } from './core/guards/auth-guard-guard';

export const routes: Routes = [
    {
        path: 'login', // URL que o usuário acessa
        component: Login // Componente em questão
    },
    {
        path: 'home',
        component: Home,
        canActivate: [authGuardGuard]
    },
    {
        // Caminho padrão apontando para a tela de login 
        path: '', redirectTo: 'login', pathMatch: 'full'
    }
];
