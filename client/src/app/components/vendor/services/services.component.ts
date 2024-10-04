// src/app/components/vendor/services/services.component.ts
import { Component, OnInit } from '@angular/core';
import { VendorService } from '../../../services/vendor.service';

@Component({
  selector: 'app-vendor-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class VendorServicesComponent implements OnInit {
  services: any[] = [];
  loading = false;
  error = '';

  constructor(private vendorService: VendorService) { }

  ngOnInit(): void {
    this.loadServices();
  }

  loadServices(): void {
    this.loading = true;
    this.vendorService.getServices().subscribe(
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

  removeService(serviceId: string): void {
    if (confirm('Are you sure you want to remove this service?')) {
      this.vendorService.removeService(serviceId).subscribe(
        () => {
          this.services = this.services.filter(service => service.id !== serviceId);
        },
        (error) => {
          console.error('Error removing service:', error);
          // Handle error (e.g., show error message to user)
        }
      );
    }
  }
}
