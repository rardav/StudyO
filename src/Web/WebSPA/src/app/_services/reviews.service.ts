import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course';
import { Review } from '../_models/review';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {
  gatewayUrl: string = environment.gatewayUrl;
  aggregatorUrl: string = environment.aggregatorUrl;

  constructor(private http: HttpClient) { }

  addReview(review: Review){
    console.log(review);

    return this.http.post(this.gatewayUrl + 'reviews', review);
  }
}
