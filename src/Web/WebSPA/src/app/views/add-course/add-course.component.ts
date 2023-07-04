import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Chapter } from 'src/app/_models/chapter';
import { Course } from 'src/app/_models/course';
import { Lesson } from 'src/app/_models/lesson';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.css']
})
export class AddCourseComponent implements OnInit {
  course: Course;
  addingChapter: boolean = false;
  newChapter: Chapter = {} as Chapter;
  courseId = this.route.snapshot.paramMap.get('id') || '';

  constructor(private route: ActivatedRoute,
    private coursesService: CoursesService){}
  
  ngOnInit(): void {
    this.coursesService.getCourse(this.courseId).subscribe({
      next: response => {
        this.course = response;
        console.log(this.course)
      },
      error: error => console.log(error)
    })
  }

  newChapterClick(){
    this.addingChapter = true;
  }

  chapterAdded(){
    this.addingChapter = false;

    this.coursesService.addChapter(this.newChapter, this.courseId).subscribe((response) => {
      
    })

    this.newChapter = {} as Chapter;
  }
}


