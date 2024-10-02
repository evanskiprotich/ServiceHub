// src/app/client-dashboard/client-dashboard.component.ts
import { Component, OnInit } from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {ClientService} from "../../services/client.service";

@Component({
  selector: 'app-client-dashboard',
  templateUrl: './client-dashboard.component.html',
  styleUrls: ['./client-dashboard.component.scss']
})
export class ClientDashboardComponent implements OnInit {
  currentUser: any;
  serviceHistory: any[] = [];
  notifications: any[] = [];
  nearbyServices: any[] = [];
  loading = {
    serviceHistory: false,
    notifications: false,
    nearbyServices: false
  };

  constructor(
    private authService: AuthService,
    private clientService: ClientService
  ) {}

  ngOnInit() {
    this.currentUser = this.authService.currentUserValue;
    this.loadServiceHistory();
    this.loadNotifications();
    this.loadNearbyServices();
  }

  loadServiceHistory() {
    this.loading.serviceHistory = true;
    this.clientService.getServiceHistory().subscribe(
      (data) => {
        this.serviceHistory = data;
        this.loading.serviceHistory = false;
      },
      (error) => {
        console.error('Error loading service history:', error);
        this.loading.serviceHistory = false;
      }
    );
  }

  loadNotifications() {
    this.loading.notifications = true;
    this.clientService.getNotifications().subscribe(
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

  loadNearbyServices() {
    this.loading.nearbyServices = true;
    this.clientService.getNearbyServices().subscribe(
      (data) => {
        this.nearbyServices = data;
        this.loading.nearbyServices = false;
      },
      (error) => {
        console.error('Error loading nearby services:', error);
        this.loading.nearbyServices = false;
      }
    );
  }

  requestService(serviceId: string) {
    this.clientService.requestService({ serviceId }).subscribe(
      (response) => {
        console.log('Service requested successfully:', response);
        // Update UI or show a success message
      },
      (error) => {
        console.error('Error requesting service:', error);
        // Show an error message to the user
      }
    );
  }

  // Add more methods for other client actions (e.g., makePayment, cancelRequest, etc.)
}
