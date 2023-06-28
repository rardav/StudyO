import { Section } from "./section"

export interface Lesson {
    id: string,
    title: string,
    image: string,
    order: string,
    sections: Section[]
}