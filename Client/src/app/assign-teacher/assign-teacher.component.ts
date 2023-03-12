import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { IResultModel } from '../models/resultmodel';
import { AssignteacherService } from '../services/assignteacher.service';

@Component({
  selector: 'app-assign-teacher',
  templateUrl: './assign-teacher.component.html',
  styleUrls: ['./assign-teacher.component.css']
})
export class AssignTeacherComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { teacherId: string },
  public teacherMapService:AssignteacherService, 
  private router: Router,public dialogRef: MatDialogRef<AssignTeacherComponent>) { }
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
