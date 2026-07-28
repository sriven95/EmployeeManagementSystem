import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../../Models/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  apiUrl: string = 'https://localhost:7233/api/Employee';

  constructor(private http: HttpClient) { }

  getAllEmployees() {
    return this.http.get<Employee[]>(this.apiUrl);
  }

  getEmployeeById(id: string) {
    const url = this.apiUrl + '/' + id;
    return this.http.get<Employee>(url);
  }

  addEmployee(employee: Employee) {
    return this.http.post<Employee>(this.apiUrl, employee);
  }
  
}
