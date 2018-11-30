import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Student } from '../Models/Student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44316/api/Students';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8','Access-Control-Allow-Origin':'*'},
  );
   }

   public postStudent(student:Student) {
    return this.http.post(this.accessPointUrl, student, {headers: this.headers});
  }

  public getStudents() {
    return this.http.get(this.accessPointUrl, {headers: this.headers});
  }

  public getStudent(studentId:any) {
    return this.http.get(this.accessPointUrl + '/' + studentId, {headers: this.headers});
  }

  public deleteStudent(studentId:any) {
    return this.http.delete(this.accessPointUrl + '/' + studentId, {headers: this.headers});
  }

  public updateStudent(userId:any) {
    return this.http.put(this.accessPointUrl + '/' + userId, {headers: this.headers});
  }
}
