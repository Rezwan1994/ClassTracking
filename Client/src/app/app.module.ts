import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TopNavComponent } from './mastertheme/top-nav/top-nav.component';
import { AsideNavComponent } from './mastertheme/aside-nav/aside-nav.component';
import { FooterNavComponent } from './mastertheme/footer-nav/footer-nav.component';
import { EnrollStudentComponent } from './enroll-student/enroll-student.component';
import { CreateTeacherComponent } from './create-teacher/create-teacher.component';
import { AssignTeacherComponent } from './assign-teacher/assign-teacher.component';
import { StudentListComponent } from './student-list/student-list.component';
import { TeachersComponent } from './teachers/teachers.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClientModule } from '@angular/common/http';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    TopNavComponent,
    AsideNavComponent,
    FooterNavComponent,
    EnrollStudentComponent,
    CreateTeacherComponent,
    AssignTeacherComponent,
    StudentListComponent,
    TeachersComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    NgxPaginationModule,
    HttpClientModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
