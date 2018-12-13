import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { User } from '../Models/User';
import { BehaviorSubject } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private usernameSource = new BehaviorSubject<User>(null);
  currentUser = this.usernameSource.asObservable();

  private headers: HttpHeaders;
  private usersUrl: string;
  private loginUrl: string;

  changeUser(user: User) {
    this.usernameSource.next(user);
  }

  constructor(private http: HttpClient,private api:ApiService) {
    this.headers = this.api.headers;

    this.usersUrl=this.api.rootUrl+'Users';
    this.loginUrl=this.api.rootUrl+'Login';

   }

   public postUser(user:User) {
    return this.http.post(this.usersUrl, user, {headers: this.headers});
  }

  public loginUser(user:User) {
    return this.http.post(this.loginUrl, user, {headers: this.headers});
  }

  public getUsers() {
    return this.http.get(this.usersUrl, {headers: this.headers});
  }

  public getUser(userId:any) {
    return this.http.get(this.usersUrl + '/' + userId, {headers: this.headers});
  }

  public deleteUser(userId:any) {
    return this.http.delete(this.usersUrl + '/' + userId, {headers: this.headers});
  }

  public updateUser(userId:any) {
    return this.http.put(this.usersUrl + '/' + userId, {headers: this.headers});
  }

}
