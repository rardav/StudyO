import { Chapter } from "./chapter";
import { Faq } from "./faq";
import { Review } from "./review";

export interface Course {
    id: string,
    title: string,
    shortDescription: string,
    longDescription: string,
    timeToComplete: number,
    language: 0,
    level: 0,
    subject: 0,
    chapters: Chapter[],
    prerequisites: string[],
    reviews: Review[],
    faqs: Faq[]
}

export enum Subject {
    "Web Development" = 0,
    "Data Science" = 1,
    "AI" = 2
}

export enum Language {
    "C#" = 0,
    "Java" = 1,
    "JavaScript" = 2,
    "HTML" = 3,
    "Python" = 4,
    "C++" = 5,
    "SQL" = 6
}

export enum Level {
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2
}