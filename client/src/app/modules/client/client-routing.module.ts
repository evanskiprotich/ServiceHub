import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ServiceHistoryComponent } from '../../components/client/service-history/service-history.component';
import { ServiceRequestsComponent } from '../../components/client/service-requests/service-requests.component';
import { PaymentsComponent } from '../../components/client/payments/payments.component';
import { ProfileComponent } from '../../components/client/profile/profile.component';
import {ClientDashboardComponent} from "../../components/client-dashboard/client-dashboard.component";

const routes: Routes = [
  {
    path: '',
    component: ClientDashboardComponent,
    children: [
      //{ path: '', redirectTo: 'service-requests', pathMatch: 'full' },
      { path: 'service-history', component: ServiceHistoryComponent },
      { path: 'service-requests', component: ServiceRequestsComponent },
      { path: 'payments', component: PaymentsComponent },
      { path: 'profile', component: ProfileComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
