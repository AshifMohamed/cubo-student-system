import { Component, OnInit } from '@angular/core';
import { CourseService } from '../Services/course.service';
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Course } from '../Models/Course';

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

  constructor(fb:FormBuilder, private courseService:CourseService) { 

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

      this.courseForm.setValue({courseId:"",courseName:""});

    },err=>console.log(err));
  }

}
