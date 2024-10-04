import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AdminDashboardComponent} from "../../components/admin-dashboard/admin-dashboard.component";
import {AdminUsersComponent} from "../../components/admin/users/users.component";
import {AdminServicesComponent} from "../../components/admin/services/services.component";
import {AdminServiceRequestsComponent} from "../../components/admin/service-requests/service-requests.component";
import {AdminPaymentsComponent} from "../../components/admin/payments/payments.component";

const routes: Routes = [
  {
    path: '',
    component: AdminDashboardComponent,
    children: [
      { path: '', redirectTo: 'users', pathMatch: 'full' },
      { path: 'users', component: AdminUsersComponent },
      { path: 'services', component: AdminServicesComponent },
      { path: 'service-requests', component: AdminServiceRequestsComponent },
      { path: 'payments', component: AdminPaymentsComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
