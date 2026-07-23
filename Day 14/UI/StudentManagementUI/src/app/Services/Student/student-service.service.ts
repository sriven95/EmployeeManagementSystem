import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from '../../Models/Student';

@Injectable({
  providedIn: 'root'
})
export class StudentServiceService {

  apiUrl="https://localhost:7086/api/Students";
  constructor(private http:HttpClient) { }

  getAllStudents(){
    return this.http.get<Student>(this.apiUrl);
  }

  getStudentById(id:string){
    const url=`${this.apiUrl}/${id}`;
    return this.http.get<Student>(url);
  }

  deleteStudentById(id:string){
    const url=`${this.apiUrl}/${id}`;
    return this.http.delete<Student>(url);
  }

  addStudent(newStudent:Student){
    return this.http.post<Student>(this.apiUrl,newStudent);
  }

   updateStudentById(id:string,updatedStudent:Student){
    const url=`${this.apiUrl}/${id}`;
    return this.http.put<Student>(url,updatedStudent);
  }
}
