import { Component, OnInit } from '@angular/core';
import {FormControl, Validators, FormBuilder, FormGroup} from '@angular/forms';
import { Lecturer } from '../Models/Lecturer';
import { Course } from '../Models/Course';
import { UserService } from '../Services/user.service';
import { LecturerService } from '../Services/lecturer.service';
import { StudentService } from '../Services/student.service';
import { Student } from '../Models/Student';
import { CourseService } from '../Services/course.service';
import { FileUploadService } from '../Services/file-upload.service';
import { Image } from '../Models/Image';
import { User } from '../Models/User';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  studentForm: FormGroup;
  lecturerForm: FormGroup;
  stFirstName = new FormControl("", Validators.required);
  stLastName = new FormControl("", Validators.required);
  stCourseName = new FormControl("", Validators.required);
  lcFirstName = new FormControl("", Validators.required);
  lcLastName = new FormControl("", Validators.required);
  lcCourseName = new FormControl("", Validators.required);
  salary = new FormControl("", Validators.required);

  user:User={userName:null,password:null,role:null};
  course:Course={courseId:null,courseName:null};
  image:Image={imageId:null,userImage:null};
  lecturer:Lecturer={lecturerId:null,lecturerFirstName:null,lecturerLastName:null,userName:null,
  lecturerCourse:null,lecturerSalary:null,course:this.course,image:this.image,lecturerImage:null,user:this.user};
  student:Student={studentId:null,studentFirstName:null,studentLastName:null,user:this.user,
  course:this.course,image:this.image,studentCourse:null,studentImage:null};

  url:any;
  courses:any[];
  fileFormatsSupported;
  fileSelected:File;

  constructor(fb: FormBuilder, private lecturerService: LecturerService, private studentService: StudentService,
  private courseService:CourseService,private fileUploadService:FileUploadService) {
    this.studentForm = fb.group({
        'stFirstName': this.stFirstName,
        'stLastName': this.stLastName,
        'stCourseName':this.stCourseName
    });

    this.lecturerForm = fb.group({
      'lcFirstName': this.lcFirstName,
      'lcLastName': this.lcLastName,
      'lcCourseName':this.lcCourseName,
      'salary':this.salary
  });
}

  ngOnInit() {

    this.getCourses();
    
  }

  addLecturer(){

    console.log("Came");
    console.log( this.lecturerForm.get("firstName").value+" "+
    this.lecturerForm.get("lastName").value+" "+
    this.lecturerForm.get("courseName").value+" "+
    this.lecturerForm.get("salary").value);

    this.lecturer.lecturerFirstName=this.lecturerForm.get("firstName").value;
    this.lecturer.lecturerLastName=this.lecturerForm.get("lastName").value;
    this.lecturer.lecturerSalary=this.lecturerForm.get("salary").value;
    this.lecturer.lecturerCourse=this.lecturerForm.get("lcCourseName").value;

  }

  addStudent(){

    console.log("Student Came");
    console.log( this.studentForm.get("stFirstName").value+" "+
    this.studentForm.get("stLastName").value+" "+
    this.studentForm.get("stCourseName").value+" ");

    // this.course.courseName=this.studentForm.get("stCourseName").value;
    // this.course.courseName="computing";
    // this.course.courseId="C1";

    this.student.studentFirstName=this.studentForm.get("stFirstName").value;
    this.student.studentLastName=this.studentForm.get("stLastName").value;
    this.student.studentCourse=this.studentForm.get("stCourseName").value;
    // this.student.studentCourse="C1";
    // this.student.studentId="ST01";
    this.student.image=this.image;
    this.student.studentImage=2;
    // this.student.studentId=this.studentForm.get("stCourseName").value;
    this.student.course=this.courses.find(f => f.courseId== this.student.studentCourse) as Course;

    console.log(this.courses.find(f => f.courseId== this.student.studentCourse) as Course);
    console.log(this.student.studentCourse);
    console.log(this.student.image.userImage);
    
    this.saveStudent();

  }

  saveLecturer(){

    this.lecturerService.postLecturer(this.lecturer).subscribe(data=>
    console.log(data),
    err=>console.log(err)
    ); 
    
  }

  saveStudent(){

    this.studentService.postStudent(this.student).subscribe(data=>
    console.log(data),
    err=>console.log(err)
    ); 
    
  }

  getCourses(){

    this.courseService.getCourses().subscribe(data=>{

       console.log(data);
        this.courses=<Course[]>data
      }
    );
    
  }

  public upload() {

    this.fileUploadService.uploadFiles(this.fileSelected).subscribe(
      response => console.log("set any success actions..." + response),
      error => {
        console.log("set any error actions..." + JSON.stringify(error));
      },
      () => {
        console.log("Sucessful");
      }
    );
     
      // window.location.href = 'http://localhost:4200/company';
  }

  onChange($event) {

    if ($event.target.files && $event.target.files[0]) {

      this.fileSelected=$event.target.files[0];

      var reader = new FileReader();
      var reader2=new FileReader();

      reader.readAsDataURL(this.fileSelected); // read file as data url

      reader.onload = (event) => { // called once readAsDataURL is completed

        this.url =(<FileReader> event.target).result;
        this.image.userImage =this.url as string;
        this.image.imageId=1;
        this.user.userName="test";
        this.user.password="test";
        this.user.role="Student";
        // console.log(this.url);
      }

    }

    // console.log(this.fileSelected.type);

    // console.log(this.url)
    // console.log(this.image.userImage)

      // if(!this.fileFormatsSupported.includes(this.fileSelected.type))
      // alert("File Format Not Supported");    
  }

}
