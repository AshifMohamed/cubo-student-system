import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Lecturer } from '../Models/Lecturer';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class LecturerService {

  private headers: HttpHeaders;
  private lecturersUrl: string;

  constructor(private http: HttpClient, private api:ApiService) {
    this.headers= api.headers;   
    this.lecturersUrl=api.rootUrl+'Lecturers';
}

   public postLecturer(lecturer:Lecturer) {
    return this.http.post(this.lecturersUrl, lecturer, {headers: this.headers});
  }

  public getLecturers() {
    return this.http.get(this.lecturersUrl, {headers: this.headers});
  }

  public getLecturer(lecturerId:any) {
    return this.http.get(this.lecturersUrl + '/' + lecturerId, {headers: this.headers});
  }

  public deleteLecturer(lecturerId:any) {
    return this.http.delete(this.lecturersUrl + '/' + lecturerId, {headers: this.headers});
  }

  public updateLecturer(lecturerId:any) {
    return this.http.put(this.lecturersUrl + '/' + lecturerId, {headers: this.headers});
  }
}
