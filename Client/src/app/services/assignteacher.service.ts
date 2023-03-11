import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TeacherClassMap } from '../models/assignteachermodel';

@Injectable({
  providedIn: 'root'
})
export class AssignteacherService {

  teacherMapModel = new TeacherClassMap();
  constructor(private http: HttpClient) { }
  addTeacherMapping()
  {
    debugger;
 
    return this.http.post( 'https://localhost:7271/api/Teacher/createteachermapping',this.teacherMapModel);
  }
}
