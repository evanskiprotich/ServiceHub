// src/app/app.module.ts
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';

import { AuthService } from './services/auth.service';
import { ClientService } from './services/client.service';
import { VendorService } from './services/vendor.service';
import { AdminService } from './services/admin.service';
import { AuthGuard } from './guards/auth.guard';
import {SharedModule} from "./shared/shared.module";
import {RoleGuard} from "./guards/role.guard";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    LandingPageComponent,
    UnauthorizedComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    SharedModule
  ],
  providers: [
    AuthService,
    ClientService,
    VendorService,
    AdminService,
    AuthGuard,
    RoleGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
