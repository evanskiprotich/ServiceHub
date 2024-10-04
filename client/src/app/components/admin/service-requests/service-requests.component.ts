// src/app/components/admin/service-requests/service-requests.component.ts
import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../services/admin.service';

@Component({
  selector: 'app-admin-service-requests',
  templateUrl: './service-requests.component.html',
  styleUrls: ['./service-requests.component.scss']
})
export class AdminServiceRequestsComponent implements OnInit {
  serviceRequests: any[] = [];
  loading = false;
  error = '';

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.loadServiceRequests();
  }

  loadServiceRequests(): void {
    this.loading = true;
    this.adminService.getServiceRequests().subscribe(
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
}
