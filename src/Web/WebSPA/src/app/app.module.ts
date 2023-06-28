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
import { CatalogAllComponent } from './views/catalog-all/catalog-all.component';
import { CommonModule } from '@angular/common';
import { CourseComponent } from './views/course/course.component';
import { FlowbiteModule } from 'flowbite-angular';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { ProfileComponent } from './views/profile/profile.component';
import { CatalogComponent } from './layouts/catalog/catalog.component';
import { CardsHeaderComponent } from './components/cards-header/cards-header.component';
import { CardComponent } from './components/card/card.component';
import { OngoingCourseComponent } from './layouts/ongoing-course/ongoing-course.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ReviewComponent } from './views/review/review.component';
import { AddCourseComponent } from './views/add-course/add-course.component';


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
    CatalogAllComponent,
    CourseComponent,
    ProfileComponent,
    CatalogComponent,
    CardsHeaderComponent,
    CardComponent,
    OngoingCourseComponent,
    SidebarComponent,
    ReviewComponent,
    AddCourseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FontAwesomeModule,
    FlowbiteModule,
    CommonModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
