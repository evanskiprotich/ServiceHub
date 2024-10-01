import {Component, OnInit} from '@angular/core';
import {AuthService, User} from "../../services/auth.service";

@Component({
  selector: 'app-client-dashboard',
  templateUrl: './client-dashboard.component.html',
  styleUrl: './client-dashboard.component.css'
})
export class ClientDashboardComponent implements OnInit {
  currentUser: User | null = null;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.currentUser.subscribe(user => this.currentUser = user);
  }
}
