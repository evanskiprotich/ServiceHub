// src/app/components/admin/services/services.component.ts
import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../services/admin.service';

@Component({
  selector: 'app-admin-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class AdminServicesComponent implements OnInit {
  services: any[] = [];
  loading = false;
  error = '';

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.loadServices();
  }

  loadServices(): void {
    this.loading = true;
    this.adminService.getServices().subscribe(
      (data) => {
        this.services = data;
        this.loading = false;
      },
      (error) => {
        this.error = 'Failed to load services';
        this.loading = false;
        console.error('Error loading services:', error);
      }
    );
  }

  deleteService(serviceId: string): void {
    if (confirm('Are you sure you want to delete this service?')) {
      this.adminService.deleteService(serviceId).subscribe(
        () => {
          this.services = this.services.filter(service => service.id !== serviceId);
        },
        (error) => {
          console.error('Error deleting service:', error);
          // Handle error (e.g., show error message to user)
        }
      );
    }
  }
}
