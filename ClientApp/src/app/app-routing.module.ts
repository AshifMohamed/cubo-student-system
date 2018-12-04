import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { StudentProfileComponent } from './student-profile/student-profile.component';
import { ViewStudentsComponent } from './view-students/view-students.component';
import { CourseHomeComponent } from './course-home/course-home.component';
import { LecturerHomeComponent } from './lecturer-home/lecturer-home.component';
import { LECTURER_ROUTES } from './app-routing-lecturer';
import { STUDENT_ROUTES } from './app-routing-student';
import { ADMIN_ROUTES } from './app-routing-admin';
import { LecturerLayoutComponent } from './layout/lecturer-layout/lecturer-layout.component';
import { StudentLayoutComponent } from './layout/student-layout/student-layout.component';
import { AdminLayoutComponent } from './layout/admin-layout/admin-layout.component';

// const routes: Routes = [

// { path: '',  redirectTo: '/register', pathMatch: 'full' },
// { path: 'register',  component: RegisterComponent },
// { path: 'login',  component: LoginComponent },
// {path: 'student', component:StudentProfileComponent},
// {path:'view-students',component:ViewStudentsComponent},
// {path:'course',component:CourseHomeComponent},
// {path:'lecturer',component:LecturerHomeComponent}

// ];

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full', },
  { path: 'login',  component: LoginComponent },
  { path: 'register',  component: RegisterComponent },
  { path: 'lecturer', component: LecturerLayoutComponent, data: { title: 'lecturer' }, children: LECTURER_ROUTES },
  { path: 'student', component: StudentLayoutComponent, data: { title: 'student' }, children: STUDENT_ROUTES },
  { path: 'admin', component: AdminLayoutComponent, data: { title: 'admin' }, children: ADMIN_ROUTES }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
