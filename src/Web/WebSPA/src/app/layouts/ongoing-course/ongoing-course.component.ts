import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/_models/course';
import { Lesson } from 'src/app/_models/lesson';
import { AuthService } from 'src/app/_services/auth.service';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-ongoing-course',
  templateUrl: './ongoing-course.component.html',
  styleUrls: ['./ongoing-course.component.css']
})
export class OngoingCourseComponent implements OnInit {
  course: Course = {} as Course;
  lessons: Lesson[] = [];
  currentLesson: Lesson;

  constructor(private route: ActivatedRoute,
    private coursesService: CoursesService,
    public authService: AuthService,
    private router: Router) {
      
    }

  ngOnInit(): void {
    let courseId = this.route.snapshot.paramMap.get('id') || '';

    this.coursesService.getCourse(courseId).subscribe({
      next: response => {
        this.course = response;
        
        this.course.chapters.forEach(chapter => {
          chapter.lessons.forEach(lesson => {
            this.lessons.push(lesson);
          })
        });

        this.currentLesson = this.lessons[0];
        console.log(this.lessons)
      },
      error: error => console.log(error)
    })

  }

  ngOnDestroy() {
    console.log('destroyed')
  }

  switchLesson(lesson: Lesson) {
    this.currentLesson = lesson as Lesson;
  }

  nextLesson() {
    this.currentLesson = this.lessons[this.lessons.indexOf(this.currentLesson)+1];
  }

  finish() {
    this.router.navigate(['/review/' + this.course.id]);
  }

}
