import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingPageComponentComponent } from './LandingPageComponent/LandingPageComponent.component';
import { RegisterComponentComponent } from './RegisterComponent/RegisterComponent.component';
import { LoginComponentComponent } from './LoginComponent/LoginComponent.component';
import { ClientDashboardComponentComponent } from './ClientDashboardComponent/ClientDashboardComponent.component';
import { VendorDashboardComponentComponent } from './VendorDashboardComponent/VendorDashboardComponent.component';
import { AdminDashboardComponentComponent } from './AdminDashboardComponent/AdminDashboardComponent.component';
import { ServiceDetailsComponentComponent } from './ServiceDetailsComponent/ServiceDetailsComponent.component';
import { PaymentComponentComponent } from './PaymentComponent/PaymentComponent.component';

@NgModule({
  declarations: [								
    AppComponent,
      LandingPageComponentComponent,
      RegisterComponentComponent,
      LoginComponentComponent,
      ClientDashboardComponentComponent,
      VendorDashboardComponentComponent,
      AdminDashboardComponentComponent,
      ServiceDetailsComponentComponent,
      PaymentComponentComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
