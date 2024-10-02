import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'; // Ensure HttpClientModule is imported
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Import FormsModule and ReactiveFormsModule

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { ClientDashboardComponent } from './components/client-dashboard/client-dashboard.component';
import { VendorDashboardComponent } from './components/vendor-dashboard/vendor-dashboard.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ServiceHistoryComponent } from './components/client/service-history/service-history.component';
import { ServiceRequestsComponent } from './components/client/service-requests/service-requests.component';
import { PaymentsComponent } from './components/client/payments/payments.component';
import { ProfileComponent } from './components/client/profile/profile.component';
import { ServicesComponent } from './components/vendor/services/services.component';
import { UsersComponent } from './components/admin/users/users.component';

import { JwtInterceptor } from './interceptors/jwt.interceptor'; // Ensure JwtInterceptor is correctly imported
import { SumPipe } from './pipes/sum.pipe';
import { AuthService } from './services/auth.service';
import { AdminService } from './services/admin.service';
import { ClientService } from './services/client.service';
import { VendorService } from './services/vendor.service';
import { AuthGuard } from './guards/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    ClientDashboardComponent,
    VendorDashboardComponent,
    AdminDashboardComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    ServiceHistoryComponent,
    ServiceRequestsComponent,
    PaymentsComponent,
    ProfileComponent,
    ServicesComponent,
    UsersComponent,
    SumPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthService,
    AdminService,
    ClientService,
    VendorService,
    AuthGuard,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
