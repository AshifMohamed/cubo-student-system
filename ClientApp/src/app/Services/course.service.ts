import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Course } from '../Models/Course';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private headers: HttpHeaders;
  private coursesUrl: string ;

  constructor(private http: HttpClient, private api:ApiService) {
    this.headers = api.headers;
    this.coursesUrl=api.rootUrl+'Courses';
  }

   public postCourse(course:Course) {
    return this.http.post(this.coursesUrl, course, {headers: this.headers});
  }

  public getCourses() {
    return this.http.get(this.coursesUrl, {headers: this.headers});
  }

  public getCourse(courseId:any) {
    return this.http.get(this.coursesUrl + '/' + courseId, {headers: this.headers});
  }

  public deleteCourse(courseId:any) {
    return this.http.delete(this.coursesUrl + '/' + courseId, {headers: this.headers});
  }

  public updateCourse(courseId:any) {
    return this.http.put(this.coursesUrl + '/' + courseId, {headers: this.headers});
  }
}
