import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StudentService } from '../services/student.service';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { IClass } from '../models/classmodel';
@Component({
  selector: 'app-enroll-student',
  templateUrl: './enroll-student.component.html',
  styleUrls: ['./enroll-student.component.css']
})
export class EnrollStudentComponent {
  bsConfig: Partial<BsDatepickerConfig>;
  bsValue: Date = new Date();
  classList:any;
  constructor(public studentService:StudentService, private router: Router) { }
  ngOnInit() {
    this.bsConfig = Object.assign({}, { containerClass: 'theme-blue' }, { dateInputFormat: 'DD/MM/YYYY' });
    this.bsValue = new Date();
    const currentDate = new Date();
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
  addStudent()
  {
    this.studentService.studentModel.enrollDate = new Date(this.studentService.studentModel.enrollDate );
    this.studentService.addStudent().subscribe(
      (res) =>{
        this.router.navigate(["/students"])
      },
      (err) => {
        alert("error")
      }
    );
  }
}
