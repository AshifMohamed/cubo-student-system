import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  headers = new HttpHeaders(
    {'Content-Type': 'application/json; charset=utf-8','Access-Control-Allow-Origin':'*'}
  );

  rootUrl = "https://localhost:44316/api/";
}
