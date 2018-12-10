import { Component, OnInit } from '@angular/core';
import { Helpers } from '../../helpers/helper';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-layout',
  templateUrl: './student-layout.component.html',
  styleUrls: ['./student-layout.component.css']
})
export class StudentLayoutComponent implements OnInit {

  constructor(private helpers: Helpers, private route:Router) {

  }
  ngOnInit() {
  }

  onLogout(){

    console.log("Logout")
    this.helpers.logout();
    this.route.navigate(['/login']);
  }
}
