import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private apiUrl = 'http://localhost:5105/api/v1/Client';

  constructor(private http: HttpClient) { }

  requestService(serviceData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/request-service`, serviceData);
  }

  makePayment(paymentData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/make-payment`, paymentData);
  }

  getServiceHistory(): Observable<any> {
    return this.http.get(`${this.apiUrl}/service-history`);
  }

  getServiceStatus(serviceRequestId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/service-status/${serviceRequestId}`);
  }

  cancelRequest(serviceRequestId: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/cancel-request/${serviceRequestId}`, {});
  }

  leaveReview(serviceId: string, reviewData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/leave-review/${serviceId}`, reviewData);
  }

  sendMessage(vendorId: string, messageData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/send-message/${vendorId}`, messageData);
  }

  getChatMessages(vendorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/chat-messages/${vendorId}`);
  }

  updateProfile(profileData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/update-profile`, profileData);
  }

  getNotifications(): Observable<any> {
    return this.http.get(`${this.apiUrl}/notifications`);
  }

  getNearbyServices(): Observable<any> {
    return this.http.get(`${this.apiUrl}/nearby`);
  }
}
