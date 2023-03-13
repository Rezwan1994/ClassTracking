import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IOutputModel } from '../models/outputmodel';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent {
  studentList:any;
  constructor(public studentService:StudentService, private router: Router) { }
  ngOnInit() {
   
    this.getAllStudents();
  }
  getAllStudents()
  {
    debugger;
    this.studentService.getAllStudents().subscribe(
      (res) => {
        debugger;
        this.studentList = res as IOutputModel[];
      },
      (err) => {}
    )
  }
}
