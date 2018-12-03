import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { StudentService } from "../Services/student.service";
import { UserService } from "../Services/user.service";
import { User } from "../Models/User";
import { Student } from "../Models/Student";
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Course } from '../Models/Course';
import { Image } from '../Models/Image';

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

  usernameValue;

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

    // this.getUsername();
   // console.log(this.getUsername());
    this.studentService.getStudent(this.getUsername()).subscribe(
      data => {
        console.log(data);
        this.student = <Student>data;
        console.log(this.student);
        
        this.profileForm.setValue({username:this.usernameValue,firstName:this.student.studentFirstName,
      lastName:this.student.studentLastName,courseName:""});
        this.setProfileDetails();
       
      },
      err => console.log(err)
    );
  }

  setProfileDetails(){   
    console.log("set Profile");
    // this.profileForm.controls["username"].setValue(
    //   this.usernameValue
    // );

    // this.profileForm.setValue({username:this.usernameValue,firstName:'this.student.StudentFirstName',
    //   lastName:'this.student.StudentLastName',courseName:""});

    // this.firstName.setValue(this.student.StudentFirstName);
    // this.lastName.setValue(this.student.StudentLastName);
    // this.courseName.setValue(this.student.)
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