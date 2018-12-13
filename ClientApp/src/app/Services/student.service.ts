import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Student } from '../Models/Student';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private headers: HttpHeaders;
  private studentsUrl: string;

  constructor(private http: HttpClient, private api:ApiService) {
    this.headers = this.headers= api.headers;   
    this.studentsUrl=api.rootUrl+'Students';
   }

   public postStudent(student:Student) {
    return this.http.post(this.studentsUrl, student, {headers: this.headers});
  }

  public getStudents() {
    return this.http.get(this.studentsUrl, {headers: this.headers});
  }

  public getStudent(studentId:any) {
    return this.http.get(this.studentsUrl + '/' + studentId, {headers: this.headers});
  }

  public deleteStudent(studentId:any) {
    return this.http.delete(this.studentsUrl + '/' + studentId, {headers: this.headers});
  }

  public updateStudent(userId:any) {
    return this.http.put(this.studentsUrl + '/' + userId, {headers: this.headers});
  }
}
