import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {ReactiveFormsModule} from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';

import {MatTabsModule} from '@angular/material/tabs';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatButtonModule} from '@angular/material/button';
import { UserService } from './Services/user.service';
import { LoginComponent } from './login/login.component';
import { CourseService } from './Services/course.service';
import { StudentService } from './Services/student.service';
import { LecturerService } from './Services/lecturer.service';
import { StudentProfileComponent } from './student-profile/student-profile.component';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import { LecturerHomeComponent } from './lecturer-home/lecturer-home.component';
import { ViewStudentsComponent } from './view-students/view-students.component';
import { CourseHomeComponent } from './course-home/course-home.component';
import {MatSidenavModule} from '@angular/material/sidenav';


@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    StudentProfileComponent,
    LecturerHomeComponent,
    ViewStudentsComponent,
    CourseHomeComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MatTabsModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCardModule,
    MatTableModule,
    MatSidenavModule
  ],
  providers: [UserService,CourseService,StudentService,LecturerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
