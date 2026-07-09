import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Class } from '../../models/class.model';

@Injectable({
  providedIn: 'root'
})
export class ClassService {
    private apiUrl = 'https://localhost:7094/api/classes';
    
    constructor(private http: HttpClient) { }

    getClasses() {
      return this.http.get<Class[]> (this.apiUrl);
    }

    addClass(classData: {className: string}) {
      return this.http.post<Class>(this.apiUrl, classData);
    }

    updateClass(classId: string, classData: {className: string}) {
      const url = `${this.apiUrl}/${classId}`;
      return this.http.put<Class>(url, classData);
    }

    deleteClass(classId: string) {
      const url = `${this.apiUrl}/${classId}`;
      return this.http.delete(url);
    }

}
