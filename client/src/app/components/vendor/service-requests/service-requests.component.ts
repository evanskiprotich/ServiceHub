// src/app/components/vendor/service-requests/service-requests.component.ts
import { Component, OnInit } from '@angular/core';
import { VendorService } from '../../../services/vendor.service';

@Component({
  selector: 'app-vendor-service-requests',
  templateUrl: './service-requests.component.html',
  styleUrls: ['./service-requests.component.scss']
})
export class VendorServiceRequestsComponent implements OnInit {
  serviceRequests: any[] = [];
  loading = false;
  error = '';

  constructor(private vendorService: VendorService) { }

  ngOnInit(): void {
    this.loadServiceRequests();
  }

  loadServiceRequests(): void {
    this.loading = true;
    this.vendorService.getServiceRequests().subscribe(
      (data) => {
        this.serviceRequests = data;
        this.loading = false;
      },
      (error) => {
        this.error = 'Failed to load service requests';
        this.loading = false;
        console.error('Error loading service requests:', error);
      }
    );
  }

  acceptRequest(requestId: string): void {
    this.vendorService.acceptRequest(requestId).subscribe(
      () => {
        const request = this.serviceRequests.find(r => r.id === requestId);
        if (request) {
          request.status = 'accepted';
        }
      },
      (error) => {
        console.error('Error accepting request:', error);
        // Handle error (e.g., show error message to user)
      }
    );
  }

  rejectRequest(requestId: string): void {
    this.vendorService.rejectRequest(requestId).subscribe(
      () => {
        const request = this.serviceRequests.find(r => r.id === requestId);
        if (request) {
          request.status = 'rejected';
        }
      },
      (error) => {
        console.error('Error rejecting request:', error);
        // Handle error (e.g., show error message to user)
      }
    );
  }
}
