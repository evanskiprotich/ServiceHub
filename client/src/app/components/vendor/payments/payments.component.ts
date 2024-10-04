// src/app/components/vendor/payments/payments.component.ts
import { Component, OnInit } from '@angular/core';
import { VendorService } from '../../../services/vendor.service';

@Component({
  selector: 'app-vendor-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.scss']
})
export class VendorPaymentsComponent implements OnInit {
  payments: any[] = [];
  loading = false;
  error = '';

  constructor(private vendorService: VendorService) { }

  ngOnInit(): void {
    this.loadPayments();
  }

  loadPayments(): void {
    this.loading = true;
    this.vendorService.getPayments().subscribe(
      (data) => {
        this.payments = data;
        this.loading = false;
      },
      (error) => {
        this.error = 'Failed to load payments';
        this.loading = false;
        console.error('Error loading payments:', error);
      }
    );
  }
}
