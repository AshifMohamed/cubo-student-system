import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './helpers/canActivateAuthGuard';

import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { LECTURER_ROUTES } from './app-routing-lecturer';
import { STUDENT_ROUTES } from './app-routing-student';
import { ADMIN_ROUTES } from './app-routing-admin';
import { LecturerLayoutComponent } from './layout/lecturer-layout/lecturer-layout.component';
import { StudentLayoutComponent } from './layout/student-layout/student-layout.component';
import { AdminLayoutComponent } from './layout/admin-layout/admin-layout.component';
import { HomeComponent } from './home/home.component';
import { RedirectAuthGuard } from './helpers/redirect-auth-guard.service';
import { HOME_ROUTES } from './app-routing-home';

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
  { path: '', redirectTo: '/home', pathMatch: 'full', },
  // { path: 'home',  component: HomeComponent,children: HOME_ROUTES,canActivate: [RedirectAuthGuard] },
  { path: 'login',  component: LoginComponent,canActivate: [RedirectAuthGuard] },
  { path: 'register',  component: RegisterComponent,canActivate: [RedirectAuthGuard] },
  { path: 'lecturer', component: LecturerLayoutComponent, data: { title: 'lecturer' }, children: LECTURER_ROUTES,canActivate: [AuthGuard] },
  { path: 'student', component: StudentLayoutComponent, data: { title: 'student' }, children: STUDENT_ROUTES,canActivate: [AuthGuard] },
  { path: 'admin', component: AdminLayoutComponent, data: { title: 'admin' }, children: ADMIN_ROUTES,canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
