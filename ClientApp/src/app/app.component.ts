import { Component, AfterViewInit } from '@angular/core';
import { startWith, delay } from 'rxjs/operators';
import { Subscription } from 'rxjs';
import { Helpers } from './helpers/helper';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  title = 'ClientApp';
  subscription: Subscription;
  authentication: boolean;

  constructor(private helpers: Helpers, private route:Router) {

  }

  ngAfterViewInit() {

    this.subscription = this.helpers.isAuthenticationChanged().pipe(
      startWith(this.helpers.isAuthenticated()),delay(10)).subscribe((value) =>
        this.authentication = value
      );
      
  }

  ngOnDestroy() {

    this.subscription.unsubscribe();

  }

  onLogout(){

    console.log("Logout")
    this.helpers.logout();
    this.route.navigate(['/login']);
  }

}
