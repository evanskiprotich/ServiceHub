import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {VendorDashboardComponent} from "../../components/vendor-dashboard/vendor-dashboard.component";
import {VendorServicesComponent} from "../../components/vendor/services/services.component";
import {VendorServiceRequestsComponent} from "../../components/vendor/service-requests/service-requests.component";
import {VendorPaymentsComponent} from "../../components/vendor/payments/payments.component";
import {VendorProfileComponent} from "../../components/vendor/profile/profile.component";

const routes: Routes = [
  {
    path: '',
    component: VendorDashboardComponent,
    children: [
      { path: '', redirectTo: 'service-requests', pathMatch: 'full' },
      { path: 'services', component: VendorServicesComponent },
      { path: 'service-requests', component: VendorServiceRequestsComponent },
      { path: 'payments', component: VendorPaymentsComponent },
      { path: 'profile', component: VendorProfileComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
