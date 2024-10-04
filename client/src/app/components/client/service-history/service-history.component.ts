// src/app/components/client/service-history/service-history.component.ts
import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../../services/client.service';

@Component({
  selector: 'app-service-history',
  templateUrl: './service-history.component.html',
  styleUrls: ['./service-history.component.scss']
})
export class ServiceHistoryComponent implements OnInit {
  serviceHistory: any[] = [];
  loading = false;
  error = '';

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.loadServiceHistory();
  }

  loadServiceHistory(): void {
    this.loading = true;
    this.clientService.getServiceHistory().subscribe(
      (data) => {
        this.serviceHistory = data;
        this.loading = false;
      },
      (error) => {
        this.error = 'Failed to load service history';
        this.loading = false;
        console.error('Error loading service history:', error);
      }
    );
  }
}
