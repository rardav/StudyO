import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Course } from 'src/app/_models/course';
import { Lesson } from 'src/app/_models/lesson';
import { Progress } from 'src/app/_models/progress';
import { AuthService } from 'src/app/_services/auth.service';
import { CoursesService } from 'src/app/_services/courses.service';
import { ProgressService } from 'src/app/_services/progress.service';

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
    private progressService: ProgressService,
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

  private updateProgress(finished: boolean) {
    let progress = {} as Progress;
    progress.courseId = this.course.id;
    progress.studentEmail = this.authService.getCurrentUser()!.email;
    progress.lessonId = this.currentLesson.id;
    progress.courseFinished = finished;

    this.progressService.updateProgress(progress).subscribe(response => {
      console.log(response);
    });
  }

  switchLesson(lesson: Lesson) {
    this.currentLesson = lesson as Lesson;
    this.updateProgress(false);
  }

  nextLesson() {
    this.currentLesson = this.lessons[this.lessons.indexOf(this.currentLesson)+1];
    this.updateProgress(false);
  }

  finish() {
    this.updateProgress(true);

    this.router.navigate(['/review/' + this.course.id]);
  }

}
