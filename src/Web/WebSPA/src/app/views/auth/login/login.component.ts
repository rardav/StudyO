import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public oidcSecurityService: OidcSecurityService) { }

  ngOnInit(): void {
  }

  login() {
    this.oidcSecurityService.authorize();
  }

}
