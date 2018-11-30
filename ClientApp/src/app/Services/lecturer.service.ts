import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Lecturer } from '../Models/Lecturer';

@Injectable({
  providedIn: 'root'
})
export class LecturerService {

  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44316/api/Lecturers';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8','Access-Control-Allow-Origin':'*'},
  );   }

   public postLecturer(lecturer:Lecturer) {
    return this.http.post(this.accessPointUrl, lecturer, {headers: this.headers});
  }

  public getLecturers() {
    return this.http.get(this.accessPointUrl, {headers: this.headers});
  }

  public getLecturer(lecturerId:any) {
    return this.http.get(this.accessPointUrl + '/' + lecturerId, {headers: this.headers});
  }

  public deleteLecturer(lecturerId:any) {
    return this.http.delete(this.accessPointUrl + '/' + lecturerId, {headers: this.headers});
  }

  public updateLecturer(lecturerId:any) {
    return this.http.put(this.accessPointUrl + '/' + lecturerId, {headers: this.headers});
  }
}
