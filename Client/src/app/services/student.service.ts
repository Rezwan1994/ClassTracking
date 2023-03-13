import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StudentModel } from '../models/studentmodel';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  studentModel = new StudentModel();
  constructor(private http: HttpClient) { }
  addStudent()
  {
    debugger;
 
    return this.http.post( 'https://localhost:7271/api/Student/createstudent',this.studentModel);
  }
  getAllClass()
  {
    
    debugger;
    return this.http.get( 'https://localhost:7271/api/Student/getallclass');
  }
  getAllStudents()
  {
    
    debugger;
    return this.http.get( 'https://localhost:7271/api/Student/getallstudents');
  }
}
