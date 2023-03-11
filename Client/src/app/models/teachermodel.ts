export interface ITeacher {
 
    id:number;
    teacherId:string;
    name: string;
    designation: string;
    email: string;
    isAssaigned:boolean
}

export class Teacher implements ITeacher {
    id:number;
    teacherId:string;
    name: any;
    designation: string;
    email: string;
    isAssaigned:boolean
 
}