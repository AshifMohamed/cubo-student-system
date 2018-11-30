import { Component, OnInit } from '@angular/core';
import {FormControl, Validators, FormBuilder, FormGroup} from '@angular/forms';
import { Lecturer } from '../Models/Lecturer';
import { Course } from '../Models/Course';
import { UserService } from '../Services/user.service';
import { LecturerService } from '../Services/lecturer.service';
import { StudentService } from '../Services/student.service';
import { Student } from '../Models/Student';
import { CourseService } from '../Services/course.service';

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


  lecturer:Lecturer;
  student:Student;
  course:Course;
  url:any;
  courses:any;

  constructor(fb: FormBuilder, private lecturerService: LecturerService, private studentService: StudentService,
  private courseService:CourseService) {
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

    this.course.courseName=this.lecturerForm.get("courseName").value;
    this.course.courseName="computing";


    this.lecturer.lecturerFirstName=this.lecturerForm.get("firstName").value;
    this.lecturer.lecturerLastName=this.lecturerForm.get("lastName").value;
    this.lecturer.lecturerSalary=this.lecturerForm.get("salary").value;
    this.lecturer.lecturerCourse=this.course;

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
        this.courses=<Course>data
      }
    );
    
  }

  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();

      reader.readAsDataURL(event.target.files[0]); // read file as data url

      reader.onload = (event) => { // called once readAsDataURL is completed

        this.url =(<FileReader> event.target).result;
      }
    }
  }

}
