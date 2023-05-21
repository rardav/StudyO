import { Injectable } from '@angular/core';
import { User, UserManager } from 'oidc-client';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userManager = new UserManager({
    authority: environment.identityUrl,
    client_id: 'webSpa',
    redirect_uri: environment.redirectUrl,
    response_type: 'code',
    scope: 'openid profile catalogApi',
    post_logout_redirect_uri: environment.postLogoutUrl,
  });
  
  async login() {
    const user = await this.userManager.signinRedirect();
    return user;
  }

  async completeLogin(): Promise<User> {
    const user = await this.userManager.signinRedirectCallback();
    return user;
  }

  async logout(): Promise<void> {
    await this.userManager.signoutRedirect();
  }

  async completeLogout(): Promise<void> {
    await this.userManager.signoutRedirectCallback();
  }

  getUser() {
    return this.userManager.getUser();
  }
}
