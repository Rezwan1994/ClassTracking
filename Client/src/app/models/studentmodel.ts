export interface IStudentModel{
 
    studentId:string;
    name:string;
    fatherName:string;
    motherName:string;
    nationality:string;
    enrollDate: Date;
    sessionYear:string;
    classId:string;
}

export class StudentModel implements IStudentModel {
    studentId:string;
    name:string;
    fatherName:string;
    motherName:string;
    nationality:string;
    enrollDate: Date;
    sessionYear:string;
    classId:string;
 
}