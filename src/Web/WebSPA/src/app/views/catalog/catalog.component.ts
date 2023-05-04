import { Component, OnInit } from '@angular/core';
import { Course, Language, Level, Subject } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit{
  courses: Course[] = [];

  level: typeof Level = Level;
  subject: typeof Subject = Subject;
  language: typeof Language = Language;

  constructor(private coursesService: CoursesService){}

  ngOnInit(): void {
    this.coursesService.getCourses().subscribe(courses => {
      this.courses = courses;
      
    })
  }


}
