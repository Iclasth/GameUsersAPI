import { inject, Inject } from '@angular/core';
import { Router, type CanActivateFn } from '@angular/router';
import { Auth } from '../services/auth';

export const authGuardGuard: CanActivateFn = (route, state) => {
  const authService = inject(Auth);
  const router = inject(Router);

  if (authService.isLoggedIn()){
    return true;
  } else{
    router.navigate(['/login']);
    return false;
  }

  
};
