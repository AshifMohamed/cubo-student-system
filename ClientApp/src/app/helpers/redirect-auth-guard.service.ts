import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Helpers } from './helper';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RedirectAuthGuard implements CanActivate {

  constructor(private router: Router,private helper: Helpers) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {

    if (!this.helper.isAuthenticated()) {

      console.log("Not Logged IN");
      return true;

    }

    let user=this.helper.getToken();
    if(user != undefined){
    console.log(user.role);
    this.helper.navigate(user.role.toLowerCase());
    return false;
    }

    return true;

  }

}
