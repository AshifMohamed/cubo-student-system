import { Course } from './Course';

export interface Lecturer{

    lecturerId : any;
    lecturerFirstName : string;
    lecturerLastName : string;
    lecturerSalary : any;
    userName: string;
    lecturerCourse:Course;
}