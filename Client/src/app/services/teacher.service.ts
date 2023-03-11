import { Injectable } from '@angular/core';
import { Teacher } from '../models/teachermodel';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  teacherModel = new Teacher();
  constructor(private http: HttpClient) { }
  getAllTeachers()
  {
    debugger;
    return this.http.get( 'https://localhost:7271/api/Teacher/getallteacher');
  }
  addTeacher()
  {
    debugger;
 
    return this.http.post( 'https://localhost:7271/api/Teacher/createteacher',this.teacherModel);
  }
}
