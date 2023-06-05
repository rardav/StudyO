import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDetails } from 'src/app/_models/userDetails';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  user: UserDetails;

  constructor(private authService: AuthService,
    private router: Router) {}

  ngOnInit(): void {
    this.getUserDetails();
  }

  logout() {
    this.authService.logout();

    this.router.navigate(['/']);
  }

  getUserDetails() {
    this.authService.getUser(this.authService.getCurrentUser()!.email).subscribe({
      next: response => {
        this.user = response;
        console.log(this.user);
      },
      error: error => console.log(error)
    })
  }

}
