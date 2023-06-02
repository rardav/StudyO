import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {}

  constructor(private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
  }

  register() {
    this.authService.register(this.model).subscribe({
      next: response => {
        this.router.navigateByUrl('/')
      },
      error: error => console.log(error)
    })
  }
}
