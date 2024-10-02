import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VendorService {
  private apiUrl = 'http://localhost:5105/api/v1/Vendor';

  constructor(private http: HttpClient) { }

  getServices(): Observable<any> {
    return this.http.get(`${this.apiUrl}/services`);
  }

  addService(serviceData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/add-service`, serviceData);
  }

  updateService(serviceId: string, serviceData: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/update-service/${serviceId}`, serviceData);
  }

  removeService(serviceId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/remove-service/${serviceId}`);
  }

  getServiceRequests(): Observable<any> {
    return this.http.get(`${this.apiUrl}/service-requests`);
  }

  acceptRequest(requestId: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/accept-request/${requestId}`, {});
  }

  rejectRequest(requestId: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/reject-request/${requestId}`, {});
  }

  getPaymentDetails(requestId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/payment-details/${requestId}`);
  }

  getPayments(): Observable<any> {
    return this.http.get(`${this.apiUrl}/payments`);
  }

  sendMessage(clientId: string, messageData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/send-message/${clientId}`, messageData);
  }

  getChatMessages(clientId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/chat-messages/${clientId}`);
  }

  updateProfile(profileData: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/update-profile`, profileData);
  }

  getNotifications(): Observable<any> {
    return this.http.get(`${this.apiUrl}/notifications`);
  }
}
