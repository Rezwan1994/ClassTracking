import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateTeacherComponent } from './create-teacher/create-teacher.component';
import { EnrollStudentComponent } from './enroll-student/enroll-student.component';
import { HomeComponent } from './home/home.component';
import { StudentListComponent } from './student-list/student-list.component';
import { TeachersComponent } from './teachers/teachers.component';


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'enrollstudent', component: EnrollStudentComponent },
  { path: 'createteacher', component: CreateTeacherComponent },
  { path: 'teachers', component: TeachersComponent },
  { path: 'students', component: StudentListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
