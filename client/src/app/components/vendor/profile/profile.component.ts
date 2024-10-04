// src/app/components/vendor/profile/profile.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VendorService } from '../../../services/vendor.service';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-vendor-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class VendorProfileComponent implements OnInit {
  profileForm: FormGroup;
  loading = false;
  error = '';
  success = '';

  constructor(
    private formBuilder: FormBuilder,
    private vendorService: VendorService,
    private authService: AuthService
  ) {
    this.profileForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadProfile();
  }

  loadProfile(): void {
    const currentUser = this.authService.currentUserValue;
    if (currentUser) {
      this.profileForm.patchValue({
        name: currentUser.name,
        email: currentUser.email
        // Add other fields as necessary
      });
    }
  }

  onSubmit(): void {
    if (this.profileForm.invalid) {
      return;
    }

    this.loading = true;
    this.vendorService.updateProfile(this.profileForm.value).subscribe(
      (response) => {
        this.success = 'Profile updated successfully';
        this.loading = false;
        // Update the current user in AuthService if necessary
      },
      (error) => {
        this.error = 'Failed to update profile';
        this.loading = false;
        console.error('Error updating profile:', error);
      }
    );
  }
}
