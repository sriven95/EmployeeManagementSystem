import { Routes } from '@angular/router';
import { ClassComponent } from './Components/class/class.component';
import { StudentComponent } from './Components/student/student.component';

export const routes: Routes = [
{ path: '', redirectTo: 'classes', pathMatch: 'full' },
  { path: 'classes', component: ClassComponent },
  { path: 'students', component: StudentComponent }
];
