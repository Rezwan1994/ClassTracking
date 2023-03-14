import { Class } from "./classmodel";
import { IStudentModel } from "./studentmodel";
import { Teacher } from "./teachermodel";

export interface IOutputModel {
 
    teacher:Teacher;
    class:Class;
    studentList: IStudentModel[];
    totalStudent:number;
    maxStudent:number;
}

export class OutputModel implements IOutputModel {
    teacher:Teacher;
    class:Class;
    studentList: IStudentModel[];
    totalStudent:number;
    maxStudent:number;
}