import { Component, OnInit } from '@angular/core';
import { Course, Level, Language, Subject } from 'src/app/_models/course';
import { ProgressCourse } from 'src/app/_models/progressCourse';
import { AuthService } from 'src/app/_services/auth.service';
import { CoursesService } from 'src/app/_services/courses.service';
import { ProgressService } from 'src/app/_services/progress.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit{
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
    public authService: AuthService){}

  ngOnInit(): void {
    this.coursesService.getCourses().subscribe(courses => {
      this.courses = courses;
    })

    if (this.authService.getCurrentUser() == null) {
      return;
    }

    this.progressService.getCourses(this.authService.getCurrentUser()!.email).subscribe(courses => {
      this.ongoingCourses = courses;

      console.log(this.authService.getCurrentUser()!.role)
    })
  }

  ongoingLessonData(courseProgress: any): { lessonTitle: string | null, chapterNumber: number | null } {
    const lessonIdToFind = courseProgress.lessonId;

    let lessonTitle: string | null = null;
    let chapterNumber: number | null = null;

    courseProgress.course.chapters.forEach((chapter: any, chapterIndex: number) => {
      const lesson = chapter.lessons.find((lesson: any) => lesson.id === lessonIdToFind);
      if (lesson) {
        lessonTitle = lesson.title;
        chapterNumber = chapterIndex + 1; // Adding 1 to chapterIndex since it is 0-based
      }
    });

    return { lessonTitle, chapterNumber };
  }

  calculateProgress(courseProgress: any): number {
    const totalLessons = courseProgress.course.chapters
      .flatMap((chapter: any) => chapter.lessons);

    const totalLessonsCount = totalLessons.length;
    const currentLessonId = courseProgress.lessonId;
    let completedLessonsCount = 0;

    for (const lesson of totalLessons) {
      if (lesson.id === currentLessonId) {
        break; 
      }
      completedLessonsCount++;
    }

    const progress = (completedLessonsCount / totalLessonsCount) * 100;
    return Math.round(progress);
  }

  getUrl(id: string): string {
    return this.authService.getCurrentUser()!.role === 0 ? 'catalog/start/'+ id : 'add-course/' + id;
  }
}
