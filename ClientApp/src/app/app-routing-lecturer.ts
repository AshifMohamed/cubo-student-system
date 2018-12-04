import { Routes } from '@angular/router';
import { ViewStudentsComponent } from './view-students/view-students.component';
import { LecturerProfileComponent } from './lecturer-profile/lecturer-profile.component';

export const LECTURER_ROUTES: Routes = [
    { path: '', component: LecturerProfileComponent },
    { path: 'view-students', component: ViewStudentsComponent}
]