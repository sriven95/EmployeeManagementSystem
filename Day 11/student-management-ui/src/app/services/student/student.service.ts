import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from '../../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  apiUrl = 'https://localhost:7094/api/students';
  constructor(private http: HttpClient) { }

  getStudents(){
    return this.http.get<Student[]>(this.apiUrl);
  }
  addStudent(studentdata:Student){
    return this.http.post<Student>(this.apiUrl,studentdata);
  }
  updateStudent(studentId:string,studentData:Student){
    const url = `${this.apiUrl}/${studentId}`;
    return this.http.put<Student>(url,studentData);
  }
  deleteStudent(studentId:string){
    const url = `${this.apiUrl}/${studentId}`;
    return this.http.delete(url);
  }
}
