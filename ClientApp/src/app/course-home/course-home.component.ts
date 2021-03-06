import { Component, OnInit } from '@angular/core';
import { CourseService } from '../Services/course.service';
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Course } from '../Models/Course';
import { Helpers } from '../helpers/helper';

@Component({
  selector: 'app-course-home',
  templateUrl: './course-home.component.html',
  styleUrls: ['./course-home.component.css']
})
export class CourseHomeComponent implements OnInit {

  courseForm:FormGroup;
  courseId=new FormControl("",Validators.required);
  courseName=new FormControl("",Validators.required);

  displayedColumns: string[] = ['Course Id', 'Course Name'];
  dataSource:any;
  isProcessing=false;
  course:Course={courseId:null,courseName:null};

  constructor(fb:FormBuilder, private courseService:CourseService, private helpers:Helpers) { 

    this.courseForm = fb.group({
      courseId: this.courseId,
      courseName: this.courseName,
  });
  }

  ngOnInit() {
    this.getAllCourses();
  }

  getAllCourses(){

    this.courseService.getCourses().subscribe(data=>{

      console.log(data);
      this.dataSource=data;
      console.log(this.dataSource);

    },err=>console.log(err));
      
  }

  viewCourseForm(){
    this.isProcessing=!this.isProcessing;
  }

  addCourse(){

    this.course.courseId=this.courseForm.get("courseId").value;
    this.course.courseName=this.courseForm.get("courseName").value;
    this.saveCourse();
  }

  saveCourse(){

    this.courseService.postCourse(this.course).subscribe(data=>{
      console.log(data);
      // this.dataSource.push(data);
      // this.courseForm.setValue({courseId:"",courseName:""});
      window.location.href = "http://localhost:4200/admin/course"

    },err=>{
      console.log(err)

      if(err.status && err.status == 409 ){

        let msg='Course Already Exists'
        this.helpers.openErrorDialog(msg);

      }else{
      this.helpers.openErrorDialog(err);
      }

    });
  }

}
