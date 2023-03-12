import { Injectable } from '@angular/core';
import { Teacher } from '../models/teachermodel';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GenericParams } from '../models/GenericParams';
@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  teacherModel = new Teacher();
  genParams = new GenericParams();
  constructor(private http: HttpClient) { }
  getGenParams(){
    return this.genParams;
  }
  setGenParams(genParams: GenericParams) {
    this.genParams = genParams;
  }
  getAllTeachers()
  {
    
    debugger;
    return this.http.get( 'https://localhost:7271/api/Teacher/getallteacher');
  }
  // getAllTeachers()
  // {
  //   let params = new HttpParams();
   
  //   params = params.append('sort', this.genParams.sort);
  //   params = params.append('pageIndex', this.genParams.pageIndex.toString());
  //   params = params.append('pageSize', this.genParams.pageSize.toString());
  //   debugger;
  //   return this.http.get<ITeacherPagination>('https://localhost:7271/api/Teacher/getallteacher', { observe: 'response', params })
  //   .pipe(
  //     map(response => {
  //       this.rptDepotLetter = [...this.rptDepotLetter, ...response.body.data]; 
  //       this.depotPagination = response.body;
  //       return this.depotPagination;
  //     })
  //   );
  //   return this.http.get( 'https://localhost:7271/api/Teacher/getallteacher');
  // }
  addTeacher()
  {
    debugger;
 
    return this.http.post( 'https://localhost:7271/api/Teacher/createteacher',this.teacherModel);
  }
}
