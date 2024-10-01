import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';

export interface User {
  id: number;
  username: string;
  role: 'client' | 'vendor' | 'admin';
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<User | null>;
  public currentUser: Observable<User | null>;

  constructor(private router: Router) {
    this.currentUserSubject = new BehaviorSubject<User | null>(JSON.parse(localStorage.getItem('currentUser') || 'null'));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User | null {
    return this.currentUserSubject.value;
  }

  login(username: string, password: string): Observable<User> {
    // In a real application, you would make an HTTP request to your backend here
    return new Observable<User>(observer => {
      // Simulating an API call
      setTimeout(() => {
        const user: User = {
          id: 1,
          username: username,
          role: username === 'admin' ? 'admin' : (username === 'vendor' ? 'vendor' : 'client')
        };
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        observer.next(user);
        observer.complete();
      }, 1000);
    });
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
    this.router.navigate(['/login']);
  }
}
