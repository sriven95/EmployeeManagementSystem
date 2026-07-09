import { Routes } from '@angular/router';
import { ClassesComponent } from './components/classes/classes.component';
import { StudentsComponent } from './components/students/students.component';

export const routes: Routes = [
{path:'',redirectTo:'classes',pathMatch:'full'},
{path:'classes', component: ClassesComponent},
{path:'students', component: StudentsComponent}

];


