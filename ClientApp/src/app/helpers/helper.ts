import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../error-dialog/error-dialog.component';
import { SuccessDialogComponent } from '../success-dialog/success-dialog.component';

@Injectable()

export class Helpers  {

    private authenticationChanged = new Subject<boolean>();

    constructor(private route:Router,private dialog: MatDialog) {

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

    public getUsername():string {

        if( window.localStorage['token'] === undefined || 

            window.localStorage['token'] === null ||

            window.localStorage['token'] === 'null' ||

            window.localStorage['token'] === 'undefined' ||

            window.localStorage['token'] === '') {

            return '';

        }

        let obj = JSON.parse(window.localStorage['token']);
        return obj.userName;
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

      openErrorDialog(errorMsg){

        const dialogRef = this.dialog.open(ErrorDialogComponent, {
          width: '300px',
          data:errorMsg
        });
    
        dialogRef.afterClosed().subscribe(result => {
          console.log('The dialog was closed');
        });
      }

      openSuccessDialog(successMsg){

        const dialogRef = this.dialog.open(SuccessDialogComponent, {
          width: '300px',
          data:successMsg
        });
    
        dialogRef.afterClosed().subscribe(result => {
          console.log('The dialog was closed');
        });
      }

}