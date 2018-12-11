import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { User } from "../Models/User";
import { Student } from "../Models/Student";
import { Course } from '../Models/Course';
import { Image } from '../Models/Image';
import { StudentService } from '../Services/student.service';
import { AuthService } from '../Services/auth.service';
import { LecturerService } from '../Services/lecturer.service';
import { Lecturer } from '../Models/Lecturer';
import { Helpers } from '../helpers/helper';
import { Router } from '@angular/router';


@Component({
  selector: 'app-lecturer-profile',
  templateUrl: './lecturer-profile.component.html',
  styleUrls: ['./lecturer-profile.component.css']
})
export class LecturerProfileComponent implements OnInit {

  username=new FormControl("",Validators.required);
  firstName=new FormControl("",Validators.required);
  lastName=new FormControl("",Validators.required);
  courseName=new FormControl("",Validators.required);

  profileForm:FormGroup;

  user:User={userName:null,password:null,role:null};
  course:Course={courseId:null,courseName:null};
  image:Image={imageId:null,userImage:null};
  lecturer:Lecturer={lecturerId:null,lecturerFirstName:null,lecturerLastName:null,lecturerSalary:this.user,
  course:this.course,image:this.image,lecturerCourse:null,lecturerImage:null,userName:null,user:null};

  usernameValue:string;
  url:any;

  constructor(fb:FormBuilder,
    private lecturerService: LecturerService,
    private userService: AuthService, private helpers: Helpers,
    private routes:Router
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
    this.getLecturer();
    }else{

      this.routes.navigate(['/login']);
    }
  }

   getUsername():string{

    this.usernameValue=this.helpers.getUsername();
    return this.usernameValue;
  }

  getLecturer() {

    this.lecturerService.getLecturer(this.getUsername()).subscribe(
      data => {
        console.log(data);
        this.lecturer = <Lecturer>data;
        console.log(this.lecturer);
        
        this.profileForm.setValue({username:this.usernameValue,firstName:this.lecturer.lecturerFirstName,
      lastName:this.lecturer.lecturerLastName,courseName:this.lecturer.course.courseName});
      this.url=this.lecturer.image.userImage;
       
      },
      err => console.log(err)
    );
  }

}
