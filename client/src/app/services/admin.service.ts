import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'http://localhost:5105/api/v1/Admin';

  constructor(private http: HttpClient) { }

  registerAdmin(adminData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, adminData);
  }

  getUsers(): Observable<any> {
    return this.http.get(`${this.apiUrl}/users`);
  }

  deleteUser(userId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/delete-user/${userId}`);
  }

  getServices(): Observable<any> {
    return this.http.get(`${this.apiUrl}/services`);
  }

  deleteService(serviceId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/delete-service/${serviceId}`);
  }

  getServiceRequests(): Observable<any> {
    return this.http.get(`${this.apiUrl}/service-requests`);
  }

  getPayments(): Observable<any> {
    return this.http.get(`${this.apiUrl}/payments`);
  }
}
