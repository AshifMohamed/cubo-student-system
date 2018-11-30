import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SchoolServiceService {

  private headers: HttpHeaders;
  private accessPointUrl: string = 'http://localhost:53877/api/workouts';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
   }
  
   public add(payload) {
    return this.http.post(this.accessPointUrl, payload, {headers: this.headers});
  }
}
