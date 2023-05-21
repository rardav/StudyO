import { NgModule } from '@angular/core';
import { AuthModule } from 'angular-auth-oidc-client';


@NgModule({
    imports: [AuthModule.forRoot({
        config: {
              authority: 'http://localhost:5050',
              redirectUrl: window.location.origin,
              postLogoutRedirectUri: window.location.origin,
              clientId: 'web_spa',
              scope: 'openid profile', // 'openid profile offline_access ' + your scopes
              responseType: 'code'
          }
      })],
    exports: [AuthModule],
})
export class AuthConfigModule {}
