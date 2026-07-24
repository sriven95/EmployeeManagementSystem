import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Class } from '../../Models/Class';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClassServiceService {

  apiUrl = "https://localhost:7086/api/Classes"

  constructor(private http:HttpClient) { }

  getAllClasss():Observable<Class[]>{
    return this.http.get<Class[]>(this.apiUrl);
  }

  getClassById(id: string):Observable<Class> {
    return this.http.get<Class>(`${this.apiUrl}/${id}`);
  }

  addClass(ClassData:any):Observable<Class> {
    return this.http.post<Class>(this.apiUrl,ClassData);
  }

  updateClassById(id:string,updatedClass:any):Observable<Class> {
    return this.http.put<Class>(`${this.apiUrl}/${id}`,updatedClass)
  }

  deleteClassById(id: string):  Observable<Class> {
    return this.http.delete<Class>(`${this.apiUrl}/${id}`);
  }
}
