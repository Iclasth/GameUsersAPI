import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, tap } from 'rxjs';


@Injectable({
  providedIn: 'root',
})
export class Auth 
{
  private http = inject(HttpClient);

  private readonly API_URL = 'https://localhost:7013/api/user';

  login(credentials: any) : Observable<any> {
    return this.http.post<any>(`${this.API_URL}/login`, credentials).pipe(
      tap(response => {
        if (response && response.token) {
          localStorage.setItem('auth_token', response.token);
        }
      })
    );
  }

  logout() : void {
    localStorage.removeItem('auth_token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('auth_token');
  }
}


