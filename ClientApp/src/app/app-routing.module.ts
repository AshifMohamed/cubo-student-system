import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { StudentProfileComponent } from './student-profile/student-profile.component';
import { ViewStudentsComponent } from './view-students/view-students.component';
import { CourseHomeComponent } from './course-home/course-home.component';

const routes: Routes = [

{ path: '',  redirectTo: '/register', pathMatch: 'full' },
{ path: 'register',  component: RegisterComponent },
{ path: 'login',  component: LoginComponent },
{path: 'student', component:StudentProfileComponent},
{path:'view-students',component:ViewStudentsComponent},
{path:'course',component:CourseHomeComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
