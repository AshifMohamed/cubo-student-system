import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { User } from '../Models/User';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';
import { Helpers } from '../helpers/helper';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../error-dialog/error-dialog.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  username= new FormControl("",Validators.required);
  password = new FormControl("", Validators.required);

  user:User={userName:null,password:null,role:null};
  test:any;

  constructor(fb:FormBuilder, private userService:AuthService, private route:Router,
    private helpers: Helpers,private dialog: MatDialog) {
    this.loginForm = fb.group({
      'username': this.username,
      'password': this.password
  });
   }

  ngOnInit() {
  }

  login(){

    console.log("Came");
    this.user.userName=this.loginForm.get("username").value;
    this.user.password=this.loginForm.get("password").value;
    
    this.userService.loginUser(this.user).subscribe(data=>{
      console.log(data);
      if(data != null){

        this.user=<User>data;
        console.log(this.user);
        this.userService.changeUser(this.user);
        this.helpers.setToken(this.user);
        this.helpers.navigate(this.user.role.toLowerCase());
      }
      else{
        let errorMsg="Invalid Username or Password";
        console.log(errorMsg); 
        this.helpers.openErrorDialog(errorMsg);
        // this.route.navigate(['/login']);
      }
    },
      err=>{
        console.log(err);
        this.route.navigate(['/login']);
      }); 

  }

  // openErrorDialog(){

  //   const dialogRef = this.dialog.open(ErrorDialogComponent, {
  //     width: '300px',
  //     data:this.errorMsg
  //   });

  //   dialogRef.afterClosed().subscribe(result => {
  //     console.log('The dialog was closed');
  //   });
  // }

  }

