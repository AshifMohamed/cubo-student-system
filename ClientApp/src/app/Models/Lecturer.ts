import { Course } from './Course';
import { User } from './User';
import { Image } from './Image';

export interface Lecturer{

    lecturerId : any;
    lecturerFirstName : string;
    lecturerLastName : string;
    lecturerSalary : any;
    user: User;
    userName: string;
    course: Course;
    lecturerCourse:string;
    image:Image;
    lecturerImage:number;
}