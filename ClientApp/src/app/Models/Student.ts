import { User } from './User';
import { Course } from './Course';
import { Image } from './Image';

export interface Student{

    user: User;
    studentId: string;
    studentFirstName: string;
    studentLastName: string;
    course: Course;
    studentCourse:string;
    image:Image;
    studentImage:number
}