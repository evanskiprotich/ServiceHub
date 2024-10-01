import {Component, HostListener} from '@angular/core';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {
  @HostListener('window:scroll', ['$event'])
  onWindowScroll() {
    const navbar = document.querySelector('.navbar') as HTMLElement;
    if (window.pageYOffset > 100) {
      navbar.classList.add('scrolled');
    } else {
      navbar.classList.remove('scrolled');
    }
  }
}
