import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ClientRoutingModule } from './client-routing.module';
import { ServiceHistoryComponent } from '../../components/client/service-history/service-history.component';
import { ServiceRequestsComponent } from '../../components/client/service-requests/service-requests.component';
import { PaymentsComponent } from '../../components/client/payments/payments.component';
import { ProfileComponent } from '../../components/client/profile/profile.component';
import {ClientDashboardComponent} from "../../components/client-dashboard/client-dashboard.component";
import {SharedModule} from "../../shared/shared.module";

@NgModule({
  declarations: [
    ClientDashboardComponent,
    ServiceHistoryComponent,
    ServiceRequestsComponent,
    PaymentsComponent,
    ProfileComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ClientRoutingModule,
    SharedModule
  ]
})
export class ClientModule { }
