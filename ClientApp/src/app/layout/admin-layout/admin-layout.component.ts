import { Component, OnInit } from '@angular/core';
import { Helpers } from '../../helpers/helper';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css']
})
export class AdminLayoutComponent implements OnInit {

  username:string;

  constructor(private helpers: Helpers, private route:Router) {

  }
  
  ngOnInit() {

    if(this.helpers.isAuthenticated){
      this.username=this.helpers.getUsername();
    }
  }

  onLogout(){

    console.log("Logout")
    this.helpers.logout();
    this.route.navigate(['/login']);
  }

}
