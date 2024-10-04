import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { VendorRoutingModule } from './vendor-routing.module';
import {VendorDashboardComponent} from "../../components/vendor-dashboard/vendor-dashboard.component";
import {VendorServicesComponent} from "../../components/vendor/services/services.component";
import {VendorServiceRequestsComponent} from "../../components/vendor/service-requests/service-requests.component";
import {VendorPaymentsComponent} from "../../components/vendor/payments/payments.component";
import {VendorProfileComponent} from "../../components/vendor/profile/profile.component";
import {SharedModule} from "../../shared/shared.module";

@NgModule({
  declarations: [
    VendorDashboardComponent,
    VendorServicesComponent,
    VendorServiceRequestsComponent,
    VendorPaymentsComponent,
    VendorProfileComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    VendorRoutingModule,
    SharedModule
  ]
})
export class VendorModule { }
