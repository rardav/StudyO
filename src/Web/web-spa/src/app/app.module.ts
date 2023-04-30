import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexNavbarComponent } from './components/navbars/index-navbar/index-navbar.component';
import { HomeComponent } from './pages/home/home.component';
import { CoursesComponent } from './pages/courses/courses.component';
import { QuizzesComponent } from './pages/quizzes/quizzes.component';
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';
import { GroupsComponent } from './pages/groups/groups.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FooterComponent } from './components/footer/footer.component';
import { AuthComponent } from './layouts/auth/auth.component';
import { AuthNavbarComponent } from './components/navbars/auth-navbar/auth-navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexNavbarComponent,
    HomeComponent,
    CoursesComponent,
    QuizzesComponent,
    LoginComponent,
    SignupComponent,
    GroupsComponent,
    FooterComponent,
    AuthComponent,
    AuthNavbarComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    AppRoutingModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
