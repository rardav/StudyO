import { Component } from '@angular/core';import { ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/_models/course';
import { Review } from 'src/app/_models/review';
import { AuthService } from 'src/app/_services/auth.service';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})

export class ReviewComponent {
  course: Course;
  review: Review = {} as Review;

  constructor(private route: ActivatedRoute,
    private coursesService: CoursesService,
    private authService: AuthService){}

  ngOnInit(): void {
    let courseId = this.route.snapshot.paramMap.get('id') || '';

    this.coursesService.getCourse(courseId).subscribe({
      next: response => {
        this.course = response;
      },
      error: error => console.log(error)
    })
  }

  save() {
    this.review.courseId = this.course.id;
    this.review.authorEmail = this.authService.getCurrentUser()!.email;

    console.log(this.review)
  }
}
