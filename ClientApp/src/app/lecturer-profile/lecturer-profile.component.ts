import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { User } from "../Models/User";
import { Student } from "../Models/Student";
import { Course } from '../Models/Course';
import { Image } from '../Models/Image';
import { StudentService } from '../Services/student.service';
import { UserService } from '../Services/user.service';


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
  student:Student={studentId:null,studentFirstName:null,studentLastName:null,user:this.user,
  course:this.course,image:this.image,studentCourse:null,studentImage:null};

  usernameValue:string;
  url:any;

  constructor(fb:FormBuilder,
    private studentService: StudentService,
    private userService: UserService
  ) {

    this.profileForm=fb.group({

    username:this.username,
    firstName:this.firstName,
    lastName:this.lastName,
    courseName:this.courseName,

    });
  }

  ngOnInit() {
    
    this.getStudent();
  }

   getUsername():string{

    this.userService.currentUser.subscribe( username => {
      
      this.usernameValue=username;
      console.log(username);
       return username;
      }
    );

    return  this.usernameValue;
  }

  getStudent() {

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
