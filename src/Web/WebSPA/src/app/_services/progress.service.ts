import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Progress } from '../_models/progress';
import { ProgressCourse } from '../_models/progressCourse';

@Injectable({
  providedIn: 'root'
})
export class ProgressService {
  gatewayUrl: string = environment.gatewayUrl;
  aggregatorUrl: string = environment.aggregatorUrl;
  
  constructor(private http: HttpClient) { }

  updateProgress(progress: Progress){
    return this.http.post(this.gatewayUrl + 'progress', progress);
  }

  getCourses(email: string) {
    return this.http.get<ProgressCourse[]>(this.aggregatorUrl + 'api/progress', {
      params: {
        studentEmail: email
      }
    });
  }

  getCurrentProgress(email: string, courseId: string){
    return this.http.get<Progress>(this.gatewayUrl + 'progress/courses/' + courseId, {
      params: {
        studentEmail: email
      }
    });
  }
}
