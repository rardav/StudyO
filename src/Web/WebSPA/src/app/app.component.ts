import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'WebSPA';

  constructor(private authService: AuthService) {}

  ngOnInit() {

  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    
    if (!userString) return;

    const user: User = JSON.parse(userString);

    this.authService.setCurrentUser(user);
  }
}
