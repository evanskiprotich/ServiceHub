import { Component, OnInit } from '@angular/core';
import {AdminService} from "../../services/admin.service";

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent implements OnInit {
  users: any[] = [];
  services: any[] = [];
  serviceRequests: any[] = [];
  payments: any[] = [];
  loading = {
    users: false,
    services: false,
    serviceRequests: false,
    payments: false
  };

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.loadUsers();
    this.loadServices();
    this.loadServiceRequests();
    this.loadPayments();
  }

  loadUsers(): void {
    this.loading.users = true;
    this.adminService.getUsers().subscribe(
      (data) => {
        this.users = data;
        this.loading.users = false;
      },
      (error) => {
        console.error('Error loading users:', error);
        this.loading.users = false;
      }
    );
  }

  loadServices(): void {
    this.loading.services = true;
    this.adminService.getServices().subscribe(
      (data) => {
        this.services = data;
        this.loading.services = false;
      },
      (error) => {
        console.error('Error loading services:', error);
        this.loading.services = false;
      }
    );
  }

  loadServiceRequests(): void {
    this.loading.serviceRequests = true;
    this.adminService.getServiceRequests().subscribe(
      (data) => {
        this.serviceRequests = data;
        this.loading.serviceRequests = false;
      },
      (error) => {
        console.error('Error loading service requests:', error);
        this.loading.serviceRequests = false;
      }
    );
  }

  loadPayments(): void {
    this.loading.payments = true;
    this.adminService.getPayments().subscribe(
      (data) => {
        this.payments = data;
        this.loading.payments = false;
      },
      (error) => {
        console.error('Error loading payments:', error);
        this.loading.payments = false;
      }
    );
  }

  deleteUser(userId: string): void {
    if (confirm('Are you sure you want to delete this user?')) {
      this.adminService.deleteUser(userId).subscribe(
        () => {
          this.users = this.users.filter(user => user.id !== userId);
        },
        (error) => {
          console.error('Error deleting user:', error);
        }
      );
    }
  }

  deleteService(serviceId: string): void {
    if (confirm('Are you sure you want to delete this service?')) {
      this.adminService.deleteService(serviceId).subscribe(
        () => {
          this.services = this.services.filter(service => service.id !== serviceId);
        },
        (error) => {
          console.error('Error deleting service:', error);
        }
      );
    }
  }
}
