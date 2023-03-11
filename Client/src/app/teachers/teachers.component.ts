import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ITeacher } from '../models/teachermodel';
import { TeacherService } from '../services/teacher.service';
import { MatDialog } from '@angular/material/dialog';
import { AssignTeacherComponent } from '../assign-teacher/assign-teacher.component';
@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent {
  teacherList: any;
  constructor(public teacherService:TeacherService, private router: Router,private dialog: MatDialog) { }
  ngOnInit(): void {
    this.getAllTeacherList()
  
  }
  getAllTeacherList()
  {
    this.teacherService.getAllTeachers().subscribe(

      (res) => {
        debugger;
        this.teacherList = res as ITeacher[];
      },
      (err) => {}
    )
  }

  openDialog(teacherId:string) {
    this.dialog.open(AssignTeacherComponent, {
      data: { teacherId: teacherId },
      width: '800px',
      height: '400px'
    });
  }
}
