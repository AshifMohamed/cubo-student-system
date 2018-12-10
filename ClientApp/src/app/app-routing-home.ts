import { Routes } from '@angular/router';
import { StudentProfileComponent } from './student-profile/student-profile.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

export const HOME_ROUTES: Routes = [
    { path: '', component: LoginComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent }

]