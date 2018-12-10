import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()

export class Helpers  {

    private authenticationChanged = new Subject<boolean>();

    constructor(private route:Router) {

    }

    public isAuthenticated():boolean {

        return (!(window.localStorage['token'] === undefined || 

            window.localStorage['token'] === null ||

            window.localStorage['token'] === 'null' ||

            window.localStorage['token'] === 'undefined' ||

            window.localStorage['token'] === ''));

    }

    public isAuthenticationChanged():any {

        return this.authenticationChanged.asObservable();

    }

    public getToken():any {

        if( window.localStorage['token'] === undefined || 

            window.localStorage['token'] === null ||

            window.localStorage['token'] === 'null' ||

            window.localStorage['token'] === 'undefined' ||

            window.localStorage['token'] === '') {

            return '';

        }

        let obj = JSON.parse(window.localStorage['token']);
        return obj;

    }

    public setToken(data:any):void {

        this.setStorageToken(JSON.stringify(data));

    }

    public failToken():void {

        this.setStorageToken(undefined);

    }

    public logout():void {

        this.setStorageToken(undefined);

    }

    private setStorageToken(value: any):void {

        window.localStorage['token'] = value;

        this.authenticationChanged.next(this.isAuthenticated());

    }

    public navigate(role: string):void{

        switch(role){
    
          case "student"    : this.route.navigate(['/student']);
                                break;
          case "lecturer"   : this.route.navigate(['/lecturer']);
                                break;
          case "admin"      : this.route.navigate(['/admin']);
                                break;
    
        }
    
      }

}