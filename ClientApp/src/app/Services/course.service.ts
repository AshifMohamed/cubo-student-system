import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Course } from '../Models/Course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44316/api/Courses';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8','Access-Control-Allow-Origin':'*'},
  );   }

   public postCourse(course:Course) {
    return this.http.post(this.accessPointUrl, course, {headers: this.headers});
  }

  public getCourses() {
    return this.http.get(this.accessPointUrl, {headers: this.headers});
  }

  public getCourse(courseId:any) {
    return this.http.get(this.accessPointUrl + '/' + courseId, {headers: this.headers});
  }

  public deleteCourse(courseId:any) {
    return this.http.delete(this.accessPointUrl + '/' + courseId, {headers: this.headers});
  }

  public updateCourse(courseId:any) {
    return this.http.put(this.accessPointUrl + '/' + courseId, {headers: this.headers});
  }
}
