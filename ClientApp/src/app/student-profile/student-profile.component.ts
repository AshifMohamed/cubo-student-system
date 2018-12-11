import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { StudentService } from "../Services/student.service";
import { AuthService } from "../Services/auth.service";
import { User } from "../Models/User";
import { Student } from "../Models/Student";
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Course } from '../Models/Course';
import { Image } from '../Models/Image';
import { Helpers } from '../helpers/helper';
import { Router } from '@angular/router';

@Component({
  selector: "app-student-profile",
  templateUrl: "./student-profile.component.html",
  styleUrls: ["./student-profile.component.css"]
})
export class StudentProfileComponent implements OnInit {

  username=new FormControl("",Validators.required);
  firstName=new FormControl("",Validators.required);
  lastName=new FormControl("",Validators.required);
  courseName=new FormControl("",Validators.required);

  profileForm:FormGroup;

  user:User={userName:null,password:null,role:null};
  course:Course={courseId:null,courseName:null};
  image:Image={imageId:null,userImage:null};
  student:Student={studentId:null,studentFirstName:null,studentLastName:null,user:this.user,
  course:this.course,image:this.image,studentCourse:null,studentImage:null};

  usernameValue:string;
  url:any;

  constructor(fb:FormBuilder,
    private studentService: StudentService,
    private userService: AuthService,private helpers:Helpers,
    private routes : Router
  ) {

    this.profileForm=fb.group({

    username:this.username,
    firstName:this.firstName,
    lastName:this.lastName,
    courseName:this.courseName,

    });
  }

  ngOnInit() {
    
    if(this.helpers.isAuthenticated()){
    this.getStudent();
    }else{
      this.routes.navigate(['/login']);
    }
  }

   getUsername():string{
     this.usernameValue=this.helpers.getUsername();
    return  this.usernameValue;
  }

  getStudent() {

    // this.getUsername();
   // console.log(this.getUsername());
    this.studentService.getStudent(this.getUsername()).subscribe(
      data => {
        console.log(data);
        this.student = <Student>data;
        console.log(this.student);
        
        this.profileForm.setValue({username:this.usernameValue,firstName:this.student.studentFirstName,
      lastName:this.student.studentLastName,courseName:this.student.course.courseName});
      this.url=this.student.image.userImage;
       
      },
      err => console.log(err)
    );
  }
}







 // @ViewChild("usernameInput") usernameInputRef: ElementRef;
  // @ViewChild("firstNameInput") firstNameInputRef: ElementRef;
  // @ViewChild("lastNameInput") lastNameInputRef: ElementRef;
  // @ViewChild("course") courseInputRef: ElementRef;

// ngAfterViewInit() {
  //   console.log("came to viewInit :");
  //   this.getUser();
  // }


   // this.usernameInputRef.nativeElement.value = this.username;
        // this.firstNameInputRef.nativeElement.value = this.student.StudentFirstName;
        // this.lastNameInputRef.nativeElement.value = this.student.StudentLastName;
        // this.courseInputRef.nativeElement.value = "Computing";

        // console.log(this.firstNameInputRef.nativeElement.value);