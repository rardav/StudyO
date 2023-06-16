import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/_models/course';
import { AuthService } from 'src/app/_services/auth.service';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-ongoing-course',
  templateUrl: './ongoing-course.component.html',
  styleUrls: ['./ongoing-course.component.css']
})
export class OngoingCourseComponent implements OnInit {
  course: Course;

  constructor(private route: ActivatedRoute,
    private coursesService: CoursesService,
    public authService: AuthService,
    private router: Router) {
      
    }

  ngOnInit(): void {
    let courseId = this.route.snapshot.paramMap.get('id') || '';

    this.coursesService.getCourse(courseId).subscribe( course => {
      this.course = course;
      console.log(this.course);
    })
  }
}
