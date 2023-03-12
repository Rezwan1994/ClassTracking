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
  configs: any;
  totalCount = 0;
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
      width: '500px',
      height: '200px'
    });
  }
  ViewData() {
    this.teacherService.getAllTeachers().subscribe(response => {
      const params = this.teacherService.getGenParams();
      // this.teacherList = response.data;  
      // this.totalCount = response.count; 
      this.configs = {
        currentPage: params.pageIndex,
        itemsPerPage: 100,
        totalItems:this.totalCount,
        };
    }, error => {
      console.log(error);
    });
  }
  onPageChanged(event: any){
    const params = this.teacherService.getGenParams();
    if (params.pageIndex !== event)
    {
      params.pageIndex = event;
      params.pageSize = 100;
      this.teacherService.setGenParams(params);
      this.ViewData();
    }
  }
}
