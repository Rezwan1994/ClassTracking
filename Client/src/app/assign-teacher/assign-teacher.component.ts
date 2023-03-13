import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { IClass } from '../models/classmodel';
import { IResultModel } from '../models/resultmodel';
import { AssignteacherService } from '../services/assignteacher.service';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-assign-teacher',
  templateUrl: './assign-teacher.component.html',
  styleUrls: ['./assign-teacher.component.css']
})
export class AssignTeacherComponent {
  classList:any;
  constructor(@Inject(MAT_DIALOG_DATA) public data: { teacherId: string },
  public teacherMapService:AssignteacherService, public studentService:StudentService,
  private router: Router,public dialogRef: MatDialogRef<AssignTeacherComponent>) { }
  ngOnInit() {
    this.getAllClass();
  }
  getAllClass()
  {
    this.studentService.getAllClass().subscribe(
      (res) => {
        debugger;
        this.classList = res as IClass[];
      },
      (err) => {}
    )
  }
  addTeacher()
  {
    this.teacherMapService.teacherMapModel.teacherId = this.data.teacherId;
    this.teacherMapService.teacherMapModel.teacherName = "";
    this.teacherMapService.addTeacherMapping().subscribe(
      (res) =>{
        debugger;
        var result = res as IResultModel;
        alert(result.message);
        this.dialogRef.close();
        window.location.reload()
      },
      (err) => {
        alert("error")
      }
    );
  }
}
