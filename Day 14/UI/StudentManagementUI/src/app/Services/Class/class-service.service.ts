import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Class } from '../../Models/Class';

@Injectable({
  providedIn: 'root'
})
export class ClassServiceService {

  apiUrl = "https://localhost:7086/api/Classes"

  constructor(private http:HttpClient) { }

  getAllClasss(){
    return this.http.get<Class[]>(this.apiUrl);
  }

  getClassById(id: number){
    return this.http.get<Class>(`${this.apiUrl}/${id}`);
  }

  addClass(ClassData:Class){
    return this.http.post<Class>(this.apiUrl,ClassData);
  }

  updateClassById(id:number,updatedClass:Class){
    return this.http.put<Class>(`${this.apiUrl}/${id}`,updatedClass)
  }

  deleteClassById(id: number){
    return this.http.delete<Class>(`${this.apiUrl}/${id}`);
  }
}
