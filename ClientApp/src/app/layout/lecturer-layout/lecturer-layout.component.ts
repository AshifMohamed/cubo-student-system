import { Component, OnInit } from '@angular/core';
import { Helpers } from '../../helpers/helper';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lecturer-layout',
  templateUrl: './lecturer-layout.component.html',
  styleUrls: ['./lecturer-layout.component.css']
})
export class LecturerLayoutComponent implements OnInit {

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
