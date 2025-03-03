import { Component, inject } from '@angular/core';
import { Router, ROUTER_INITIALIZER, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterLink,RouterOutlet,RouterLinkActive],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  route=inject(Router)
  onlogoff(){
    this.route.navigateByUrl('/login')
    localStorage.removeItem('empUser');


  }

}
