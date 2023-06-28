import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './views/auth/login/login.component';
import { RegisterComponent } from './views/auth/register/register.component';
import { IndexComponent } from './views/index/index.component';
import { AuthComponent } from './layouts/auth/auth.component';
import { CourseComponent } from './views/course/course.component';
import { ProfileComponent } from './views/profile/profile.component';
import { CatalogComponent } from './layouts/catalog/catalog.component';
import { CatalogAllComponent } from './views/catalog-all/catalog-all.component';
import { OngoingCourseComponent } from './layouts/ongoing-course/ongoing-course.component';
import { ReviewComponent } from './views/review/review.component';
import { AddCourseComponent } from './views/add-course/add-course.component';

const routes: Routes = [
  {
    path: "auth",
    component: AuthComponent,
    children: [
      { path: "login", component: LoginComponent },
      { path: "register", component: RegisterComponent },
      { path: "", redirectTo: "login", pathMatch: "full" }
    ],
  },
  { path: '', component: IndexComponent },
  { 
    path: 'catalog', 
    component: CatalogComponent,
    children: [
      { path: "all", component: CatalogAllComponent},
      { path: "", redirectTo: "all", pathMatch: "full" }
    ]
   },
  { path: 'catalog/:id', component: CourseComponent },
  { path: 'catalog/start/:id', component: OngoingCourseComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'review', component: ReviewComponent },
  { path: 'add-course', component: AddCourseComponent },
  { path: "**", redirectTo: "", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
