import { Component, OnInit } from '@angular/core';
import {VendorService} from "../../services/vendor.service";

@Component({
  selector: 'app-vendor-dashboard',
  templateUrl: './vendor-dashboard.component.html',
  styleUrls: ['./vendor-dashboard.component.scss']
})
export class VendorDashboardComponent implements OnInit {
  services: any[] = [];
  serviceRequests: any[] = [];
  payments: any[] = [];
  notifications: any[] = [];
  loading = {
    services: false,
    serviceRequests: false,
    payments: false,
    notifications: false
  };

  constructor(private vendorService: VendorService) { }

  ngOnInit(): void {
    this.loadServices();
    this.loadServiceRequests();
    this.loadPayments();
    this.loadNotifications();
  }

  loadServices(): void {
    this.loading.services = true;
    this.vendorService.getServices().subscribe(
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
    this.vendorService.getServiceRequests().subscribe(
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
    this.vendorService.getPayments().subscribe(
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

  loadNotifications(): void {
    this.loading.notifications = true;
    this.vendorService.getNotifications().subscribe(
      (data) => {
        this.notifications = data;
        this.loading.notifications = false;
      },
      (error) => {
        console.error('Error loading notifications:', error);
        this.loading.notifications = false;
      }
    );
  }

  acceptRequest(requestId: string): void {
    this.vendorService.acceptRequest(requestId).subscribe(
      () => {
        this.serviceRequests = this.serviceRequests.filter(request => request.id !== requestId);
      },
      (error) => {
        console.error('Error accepting request:', error);
      }
    );
  }

  rejectRequest(requestId: string): void {
    this.vendorService.rejectRequest(requestId).subscribe(
      () => {
        this.serviceRequests = this.serviceRequests.filter(request => request.id !== requestId);
      },
      (error) => {
        console.error('Error rejecting request:', error);
      }
    );
  }

  removeService(serviceId: string): void {
    if (confirm('Are you sure you want to remove this service?')) {
      this.vendorService.removeService(serviceId).subscribe(
        () => {
          this.services = this.services.filter(service => service.id !== serviceId);
        },
        (error) => {
          console.error('Error removing service:', error);
        }
      );
    }
  }
}
