// src/app/components/client/service-requests/service-requests.component.ts
import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../../services/client.service';

@Component({
  selector: 'app-service-requests',
  templateUrl: './service-requests.component.html',
  styleUrls: ['./service-requests.component.scss']
})
export class ServiceRequestsComponent implements OnInit {
  serviceRequests: any[] = [];
  loading = false;
  error = '';

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.loadServiceRequests();
  }

  loadServiceRequests(): void {
    this.loading = true;
    this.clientService.getServiceHistory().subscribe(
      (data) => {
        this.serviceRequests = data.filter((service: any) => service.status === 'pending');
        this.loading = false;
      },
      (error) => {
        this.error = 'Failed to load service requests';
        this.loading = false;
        console.error('Error loading service requests:', error);
      }
    );
  }

  cancelRequest(serviceRequestId: string): void {
    this.clientService.cancelRequest(serviceRequestId).subscribe(
      () => {
        this.serviceRequests = this.serviceRequests.filter(request => request.id !== serviceRequestId);
      },
      (error) => {
        console.error('Error cancelling request:', error);
        // Handle error (e.g., show error message to user)
      }
    );
  }
}
