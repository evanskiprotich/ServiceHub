import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

export interface User {
  id: string;
  email: string;
  username: string;
  role: 'Admin' | 'Vendor' | 'Client';
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5105/api/v1/Authentication';
  private currentUserSubject: BehaviorSubject<User | null>;
  public currentUser: Observable<User | null>;
  private tokenSubject: BehaviorSubject<string | null>;
  public token: Observable<string | null>;

  constructor(private http: HttpClient, private router: Router) {
    const userJson = localStorage.getItem('currentUser');
    // Only parse the JSON if it's not null
    this.currentUserSubject = new BehaviorSubject<User | null>(userJson ? JSON.parse(userJson) : null);
    this.currentUser = this.currentUserSubject.asObservable();

    const token = localStorage.getItem('token');
    this.tokenSubject = new BehaviorSubject<string | null>(token);
    this.token = this.tokenSubject.asObservable();
  }


  public get currentUserValue(): User | null {
    return this.currentUserSubject.value;
  }

  public get tokenValue(): string | null {
    return this.tokenSubject.value;
  }

  login(credentials: { email: string, password: string }): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, credentials)
      .pipe(map(response => {
        const decodedUser = this.decodeToken(response.token);  // Decode JWT to extract user details
        localStorage.setItem('currentUser', JSON.stringify(decodedUser));
        localStorage.setItem('token', response.token);
        this.currentUserSubject.next(decodedUser);
        this.tokenSubject.next(response.token);
        return response;
      }));
  }

  logout() {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('token');
    this.currentUserSubject.next(null);
    this.tokenSubject.next(null);
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return !!this.currentUserValue && !!this.tokenValue;
  }

  getToken(): string | null {
    return this.tokenValue;
  }

  // Helper function to decode JWT and extract user info
  private decodeToken(token: string): User | null {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const user: User = {
        id: payload.sub,
        email: payload.email,
        username: payload.username,
        role: payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] as 'Admin' | 'Vendor' | 'Client'
      };
      return user;
    } catch (error) {
      console.error('Error decoding token', error);
      return null;
    }
  }
}
