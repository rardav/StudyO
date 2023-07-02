import { Component, OnInit } from '@angular/core';
import { Course, Language, Level, Subject } from 'src/app/_models/course';
import { ProgressCourse } from 'src/app/_models/progressCourse';
import { AuthService } from 'src/app/_services/auth.service';
import { CoursesService } from 'src/app/_services/courses.service';
import { ProgressService } from 'src/app/_services/progress.service';

@Component({
  selector: 'app-catalog-all',
  templateUrl: './catalog-all.component.html',
  styleUrls: ['./catalog-all.component.css']
})
export class CatalogAllComponent implements OnInit{
  ongoingCourses: ProgressCourse[] = [];
  courses: Course[] = [];

  level: typeof Level = Level;
  subject: typeof Subject = Subject;
  language: typeof Language = Language;

  levels: string[] = Object.keys(Level).filter(item => isNaN(Number(item)));
  subjects: string[] = Object.keys(Subject).filter(item => isNaN(Number(item)));
  languages: string[] = Object.keys(Language).filter(item => isNaN(Number(item)));

  constructor(private coursesService: CoursesService,
    private progressService: ProgressService,
    private authService: AuthService){}

  ngOnInit(): void {
    this.coursesService.getCourses().subscribe(courses => {
      this.courses = courses;
    })

    this.progressService.getCourses(this.authService.getCurrentUser()!.email).subscribe(courses => {
      this.ongoingCourses = courses;

      console.log(this.ongoingCourses)
    })
  }


}
