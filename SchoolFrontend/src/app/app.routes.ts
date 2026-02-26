import { Routes } from '@angular/router';
import { Student } from './student/student/student';

export const routes: Routes = [
    { path: '', redirectTo: 'students', pathMatch: 'full' },
    { path: 'students', component: Student },
    
];
