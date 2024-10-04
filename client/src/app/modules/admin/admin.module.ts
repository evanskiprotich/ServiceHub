import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { AdminRoutingModule } from './admin-routing.module';
import {AdminDashboardComponent} from "../../components/admin-dashboard/admin-dashboard.component";
import {AdminUsersComponent} from "../../components/admin/users/users.component";
import {AdminServicesComponent} from "../../components/admin/services/services.component";
import {AdminServiceRequestsComponent} from "../../components/admin/service-requests/service-requests.component";
import {AdminPaymentsComponent} from "../../components/admin/payments/payments.component";
import {SharedModule} from "../../shared/shared.module";

@NgModule({
  declarations: [
    AdminDashboardComponent,
    AdminUsersComponent,
    AdminServicesComponent,
    AdminServiceRequestsComponent,
    AdminPaymentsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AdminRoutingModule,
    SharedModule
  ]
})
export class AdminModule { }
