import { Component, AfterViewInit } from '@angular/core';
import { startWith, delay } from 'rxjs/operators';
import { Subscription } from 'rxjs';
import { Helpers } from './helpers/helper';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  title = 'ClientApp';
  subscription: Subscription;
  authentication: boolean;

  constructor(private helpers: Helpers) {

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

}
