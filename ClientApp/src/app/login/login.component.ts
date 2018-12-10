import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { User } from '../Models/User';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';
import { Helpers } from '../helpers/helper';

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
    private helpers: Helpers) {
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
        this.route.navigate(['/login']);
      }
    },
      err=>{
        console.log(err);
        this.route.navigate(['/login']);
      }); 

  }

  // navigate(role: string):void{

  //   switch(role){

  //     case "student" :  this.route.navigate(['/student']);
  //                       break;
  //     case "lecturer" :  this.route.navigate(['/lecturer']);
  //                       break;
  //     case "admin" :  this.route.navigate(['/admin']);
  //                       break;

  //   }

  // }

}
