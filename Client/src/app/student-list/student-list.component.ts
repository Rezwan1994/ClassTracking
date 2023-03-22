import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IClass } from '../models/classmodel';
import { IOutputModel } from '../models/outputmodel';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css'],
})
export class StudentListComponent {
  studentList: any;
  classList: any;
  constructor(public studentService: StudentService, private router: Router) {}
  ngOnInit() {
    this.studentService.filterModel.search = '';
    this.studentService.filterModel.classId = '';
    this.getAllStudents();
    this.getAllClass();
  }
  getAllClass() {
    this.studentService.getAllClass().subscribe(
      (res) => {
        debugger;
        this.classList = res as IClass[];
      },
      (err) => {}
    );
  }
  getAllStudents() {
    debugger;

    this.studentService.getAllStudents().subscribe(
      (res) => {
        debugger;
        this.studentList = res as IOutputModel[];
      },
      (err) => {}
    );
  }
}
