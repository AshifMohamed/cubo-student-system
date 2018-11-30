import { Component, OnInit } from '@angular/core';
import { StudentService } from '../Services/student.service';

@Component({
  selector: 'app-view-students',
  templateUrl: './view-students.component.html',
  styleUrls: ['./view-students.component.css']
})
export class ViewStudentsComponent implements OnInit {

  displayedColumns: string[] = ['Student Id', 'First Name', 'Last Name'];
  dataSource:any;

  constructor(private studentService: StudentService) { }

  ngOnInit() {

    this.getAllStudents();
  }

  getAllStudents(){

    this.studentService.getStudents().subscribe(data=>{

      console.log(data);
      this.dataSource=data;

    },err=>console.log(err));
      
  }

}
