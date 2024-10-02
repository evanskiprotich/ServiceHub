import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  private apiUrl = 'http://localhost:5105/api/v1/Report';

  constructor(private http: HttpClient) { }

  getClientServiceRequests(clientId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/client/${clientId}/service-requests`);
  }

  getClientPayments(clientId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/client/${clientId}/payments`);
  }

  getClientActivity(clientId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/client/${clientId}/activity`);
  }

  getClientReviews(clientId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/client/${clientId}/reviews`);
  }

  getVendorEarnings(vendorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/vendor/${vendorId}/earnings`);
  }

  getVendorServicePerformance(vendorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/vendor/${vendorId}/service-performance`);
  }

  getVendorServiceRequests(vendorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/vendor/${vendorId}/service-requests`);
  }

  getVendorClientFeedback(vendorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/vendor/${vendorId}/client-feedback`);
  }

  getVendorWithdrawals(vendorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/vendor/${vendorId}/withdrawals`);
  }

  getVendorChatInteractions(vendorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/vendor/${vendorId}/chat-interactions`);
  }

  getUserActivity(): Observable<any> {
    return this.http.get(`${this.apiUrl}/user-activity`);
  }

  getFinancialReport(): Observable<any> {
    return this.http.get(`${this.apiUrl}/financial`);
  }

  getDisputeResolutionReport(): Observable<any> {
    return this.http.get(`${this.apiUrl}/dispute-resolution`);
  }

  getServicePopularityReport(): Observable<any> {
    return this.http.get(`${this.apiUrl}/service-popularity`);
  }

  getVendorPerformanceReport(): Observable<any> {
    return this.http.get(`${this.apiUrl}/vendor-performance`);
  }

  getPlatformGrowthReport(): Observable<any> {
    return this.http.get(`${this.apiUrl}/platform-growth`);
  }

  getClientSatisfactionReport(): Observable<any> {
    return this.http.get(`${this.apiUrl}/client-satisfaction`);
  }

  getRevenueReport(): Observable<any> {
    return this.http.get(`${this.apiUrl}/revenue`);
  }
}
