export interface ITeacherClassMap {
 
    id:number;
    teacherId:string;
    classId: string;
    teacherName: string;

}

export class TeacherClassMap implements ITeacherClassMap {
    id:number;
    teacherId:string;
    classId: string;
    teacherName: string;
 
}

