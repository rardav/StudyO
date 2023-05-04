import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course, Language, Level, Subject } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit{
  course: Course;

  level: typeof Level = Level;
  subject: typeof Subject = Subject;
  language: typeof Language = Language;

  constructor(private route: ActivatedRoute,
    private coursesService: CoursesService) {
      
    }

  ngOnInit(): void {
    let courseId = this.route.snapshot.paramMap.get('id') || '';

    this.coursesService.getCourse(courseId).subscribe( course => {
      this.course = course;
    })
  }
}
