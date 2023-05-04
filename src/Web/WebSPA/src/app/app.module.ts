import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { IndexNavbarComponent } from './components/navbars/index-navbar/index-navbar.component';
import { IndexComponent } from './views/index/index.component';
import { LoginComponent } from './views/auth/login/login.component';
import { RegisterComponent } from './views/auth/register/register.component';
import { FooterComponent } from './components/footer/footer.component';
import { AuthComponent } from './layouts/auth/auth.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthNavbarComponent } from './components/navbars/auth-navbar/auth-navbar.component';
import { CatalogComponent } from './views/catalog/catalog.component';
import { CommonModule } from '@angular/common';
import { CourseComponent } from './views/course/course.component';
import { FlowbiteModule } from 'flowbite-angular';


@NgModule({
  declarations: [
    AppComponent,
    IndexNavbarComponent,
    IndexComponent,
    LoginComponent,
    RegisterComponent,
    FooterComponent,
    AuthComponent,
    AuthNavbarComponent,
    CatalogComponent,
    CourseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    FlowbiteModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
