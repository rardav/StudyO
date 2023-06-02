import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {}
  loggedIn = false;

  constructor(private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.model).subscribe({
      next: response => {
        this.loggedIn = true;

        this.router.navigate(['/']);
      },
      error: error => console.log(error)
    })
  }
}
