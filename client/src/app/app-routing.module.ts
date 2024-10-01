import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './LoginComponent/LoginComponent.component';
import { RegisterComponent } from './RegisterComponent/RegisterComponent.component';
import { LandingPageComponentComponent } from './LandingPageComponent/LandingPageComponent.component';
import { ClientDashboardComponentComponent } from './ClientDashboardComponent/ClientDashboardComponent.component';
import { VendorDashboardComponentComponent } from './VendorDashboardComponent/VendorDashboardComponent.component';
import { AdminDashboardComponentComponent } from './AdminDashboardComponent/AdminDashboardComponent.component';

const routes: Routes = [
  { path: '', component: LandingPageComponentComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'client-dashboard', component: ClientDashboardComponentComponent },
  { path: 'vendor-dashboard', component: VendorDashboardComponentComponent },
  { path: 'admin-dashboard', component: AdminDashboardComponentComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
