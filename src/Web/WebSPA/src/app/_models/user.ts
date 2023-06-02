export interface User {
    email: string;
    token: string;
    firstName: string;
    lastName: string;
    role: number;
    dateOfRegister: Date;
    bio: string;
    location: string;
    githubUsername: string;
}