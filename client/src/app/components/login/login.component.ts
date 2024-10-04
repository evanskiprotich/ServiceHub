import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService, User } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  ngOnInit() {
    // If the user is already logged in, redirect to the appropriate dashboard
    if (this.authService.isLoggedIn()) {
      this.redirectToDashboard();
    }
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.error = '';

    this.authService.login(this.loginForm.value)
      .subscribe(
        response => {
          this.loading = false;
          this.redirectToDashboard();
        },
        error => {
          this.loading = false;
          this.error = 'Invalid email or password';
          console.error('Login error:', error);
        }
      );
  }

  private redirectToDashboard() {
    const user = this.authService.currentUserValue;
    if (user) {
      if (user.role === 'Admin') {
        this.router.navigate(['/admin']);
      } else if (user.role === 'Vendor') {
        this.router.navigate(['/vendor']);
      } else {
        this.router.navigate(['/client']);
      }
    } else {
      // Handle the case where user is null (shouldn't happen, but TypeScript doesn't know that)
      this.router.navigate(['/']);
    }
  }
}
