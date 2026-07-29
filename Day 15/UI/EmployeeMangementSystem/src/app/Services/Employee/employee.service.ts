import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../../Models/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  apiUrl="https://localhost:7233/api/employees";

  constructor(private http: HttpClient) {
  }

  getAllEmployees(){
    return this.http.get<Employee[]>(this.apiUrl);
  }

  getEmployeeById(Id:string){
    const Url = `${this.apiUrl}/${Id}`;
    return this.http.get<Employee[]>(Url);
  }

  addEmployee(EmployeeData:Employee[]){
    return this.http.post<Employee[]>(this.apiUrl,EmployeeData);
  }

  updateEmployeeById(Id:string,EmployeeData:Employee[]){
    const Url = `${this.apiUrl}/${Id}`;
    return this.http.put<Employee[]>(this.apiUrl,EmployeeData);
  }

   deleteEmployeeById(Id:string){
    const Url = `${this.apiUrl}/${Id}`;
    return this.http.delete<Employee[]>(Url);
  }
}
