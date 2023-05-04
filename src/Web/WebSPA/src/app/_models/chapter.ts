import { Lesson } from "./lesson";

export interface Chapter {
    id: string;
    title: string;
    description: string;
    lessons: Lesson[];
}