import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TeacherService } from '../services/teacher.service';

@Component({
  selector: 'app-create-teacher',
  templateUrl: './create-teacher.component.html',
  styleUrls: ['./create-teacher.component.css']
})
export class CreateTeacherComponent {
  teacherObj: any;
  constructor(public teacherService:TeacherService, private router: Router) { }
  ngOnInit(): void {
   
  }
  
  addTeacher()
  {
    this.teacherService.addTeacher().subscribe(
      (res) =>{
        this.router.navigate(["/teachers"])
      },
      (err) => {
        alert("error")
      }
    );
  }

}
