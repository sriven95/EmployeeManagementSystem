import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Department } from '../../Models/Department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  apiUrl="https://localhost:7233/api/departments"
  constructor(private http:HttpClient) { }

  getAllDepartments(){
    return this.http.get<Department[]>(this.apiUrl);
  }

  getDepartmentById(Id:string){
    const url = `${this.apiUrl}/${Id}`;
    return this.http.get<Department[]>(url);

  }

  deleteDepartmentById(Id:string){
    const url = `${this.apiUrl}/${Id}`;
    return this.http.delete<Department[]>(url);

  }

  addDepartment(department:{departmentName:string}){
    return this.http.post<Department[]>(this.apiUrl,department);
  }

  updateDepartment(Id:string,department:{departmentName:string}){
     const url = `${this.apiUrl}/${Id}`;
    return this.http.put<Department[]>(url,department);
  }
}
