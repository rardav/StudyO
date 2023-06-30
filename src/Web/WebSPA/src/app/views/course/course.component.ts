import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course, Language, Level, Subject } from 'src/app/_models/course';
import { AuthService } from 'src/app/_services/auth.service';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})

export class CourseComponent implements OnInit{
  course: Course;
  rating: number;
  reviewsCount: number=0;

  level: typeof Level = Level;
  subject: typeof Subject = Subject;
  language: typeof Language = Language;

  constructor(private route: ActivatedRoute,
    private coursesService: CoursesService,
    public authService: AuthService,
    private router: Router) {
      
    }

  ngOnInit(): void {
    let courseId = this.route.snapshot.paramMap.get('id') || '';

    this.coursesService.getCourse(courseId).subscribe( course => {
      this.course = course;

      let sum = 0;
      this.course.reviews.forEach(review => {
        sum += review.rating
        this.reviewsCount++;
      });
      this.rating = sum/this.reviewsCount;

    })
  }

  startCourse(): void {
    this.router.navigate(['/catalog/start/' + this.course.id]);
  }
}
