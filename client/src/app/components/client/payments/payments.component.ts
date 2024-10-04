// src/app/components/client/payments/payments.component.ts
import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../../services/client.service';

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.scss']
})
export class PaymentsComponent implements OnInit {
  payments: any[] = [];
  loading = false;
  error = '';

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.loadPayments();
  }

  loadPayments(): void {
    this.loading = true;
    this.clientService.getServiceHistory().subscribe(
      (data) => {
        this.payments = data.filter((service: any) => service.status === 'completed');
        this.loading = false;
      },
      (error) => {
        this.error = 'Failed to load payments';
        this.loading = false;
        console.error('Error loading payments:', error);
      }
    );
  }

  makePayment(paymentData: any): void {
    this.clientService.makePayment(paymentData).subscribe(
      (response) => {
        console.log('Payment successful:', response);
        // Update the payments list or show success message
      },
      (error) => {
        console.error('Error making payment:', error);
        // Handle error (e.g., show error message to user)
      }
    );
  }
}
