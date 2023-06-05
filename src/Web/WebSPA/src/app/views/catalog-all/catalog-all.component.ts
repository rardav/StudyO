import { Component, OnInit } from '@angular/core';
import { Course, Language, Level, Subject } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-catalog-all',
  templateUrl: './catalog-all.component.html',
  styleUrls: ['./catalog-all.component.css']
})
export class CatalogAllComponent implements OnInit{
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
