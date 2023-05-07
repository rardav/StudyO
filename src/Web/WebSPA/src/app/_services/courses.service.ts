import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {
  gatewayUrl: string = environment.gatewayUrl;
  aggregatorUrl: string = environment.aggregatorUrl;

  constructor(private http: HttpClient) { }

  getCourses() {
    return this.http.get<Course[]>(this.aggregatorUrl + 'api/courses/');
  }

  getCourse(id: string) {
    return this.http.get<Course>(this.aggregatorUrl + 'api/courses/' + id);
  }
}
