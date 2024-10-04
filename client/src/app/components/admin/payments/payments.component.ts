// src/app/components/admin/payments/payments.component.ts
import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../services/admin.service';

@Component({
  selector: 'app-admin-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.scss']
})
export class AdminPaymentsComponent implements OnInit {
  payments: any[] = [];
  loading = false;
  error = '';

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.loadPayments();
  }

  loadPayments(): void {
    this.loading = true;
    this.adminService.getPayments().subscribe(
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
