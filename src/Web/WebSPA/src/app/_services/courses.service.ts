import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCourses() {
    return this.http.get<Course[]>(this.baseUrl + 'courses');
  }
}
