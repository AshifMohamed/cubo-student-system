import { Routes } from '@angular/router';
import { CourseHomeComponent } from './course-home/course-home.component';
import { RegisterComponent } from './register/register.component';

export const ADMIN_ROUTES: Routes = [
    { path: '', redirectTo: 'course', pathMatch: 'prefix', },
    { path: 'course', component: CourseHomeComponent },
    { path: 'register',  component: RegisterComponent},

]