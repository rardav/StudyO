import { Course } from "./course";

export interface ProgressCourse {
    id: string;
    courseId: string;
    studentEmail: string;
    lessonId: string;
    courseFinished: boolean;
    course: Course;
}
