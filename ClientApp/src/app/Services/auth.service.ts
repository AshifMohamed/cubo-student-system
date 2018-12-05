import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { User } from '../Models/User';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private usernameSource = new BehaviorSubject<User>(null);
  currentUser = this.usernameSource.asObservable();

  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44316/api/Users';
  private loginAccessPointUrl: string = 'https://localhost:44316/api/Login';

  changeUser(user: User) {
    this.usernameSource.next(user);
  }

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8','Access-Control-Allow-Origin':'*'},
    );
   }

   public postUser(user:User) {
    return this.http.post(this.accessPointUrl, user, {headers: this.headers});
  }

  public loginUser(user:User) {
    return this.http.post(this.loginAccessPointUrl, user, {headers: this.headers});
  }

  public getUsers() {
    return this.http.get(this.accessPointUrl, {headers: this.headers});
  }

  public getUser(userId:any) {
    return this.http.get(this.accessPointUrl + '/' + userId, {headers: this.headers});
  }

  public deleteUser(userId:any) {
    return this.http.delete(this.accessPointUrl + '/' + userId, {headers: this.headers});
  }

  public updateUser(userId:any) {
    return this.http.put(this.accessPointUrl + '/' + userId, {headers: this.headers});
  }

}
