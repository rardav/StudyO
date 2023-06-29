import { Section } from "./section"

export interface Lesson {
    id: string,
    title: string,
    image: string,
    orderNumber: string,
    sections: Section[]
}