import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LandingPageComponent} from "./components/landing-page/landing-page.component";
import {AdminDashboardComponent} from "./components/admin-dashboard/admin-dashboard.component";
import {VendorDashboardComponent} from "./components/vendor-dashboard/vendor-dashboard.component";
import {ClientDashboardComponent} from "./components/client-dashboard/client-dashboard.component";
import {RegisterComponent} from "./components/register/register.component";
import {LoginComponent} from "./components/login/login.component";
import {AuthGuard} from "./guards/auth.guard";


const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'client',
    component: ClientDashboardComponent,
    canActivate: [AuthGuard],
    data: { roles: ['client'] }
  },
  {
    path: 'vendor',
    component: VendorDashboardComponent,
    canActivate: [AuthGuard],
    data: { roles: ['vendor'] }
  },
  {
    path: 'admin',
    component: AdminDashboardComponent,
    canActivate: [AuthGuard],
    data: { roles: ['admin'] }
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
