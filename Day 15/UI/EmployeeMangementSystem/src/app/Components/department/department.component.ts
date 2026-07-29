import { Component, OnInit } from '@angular/core';
import { Department } from '../../Models/Department';
import { DepartmentService } from '../../Services/Department/department.service';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-department',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './department.component.html',
  styleUrl: './department.component.css'
})
export class DepartmentComponent implements OnInit{
    departments:Department[]=[];
    editingId:string | null = null;
    departmentName='';
    constructor(private departmentService:DepartmentService){

    }

    ngOnInit():void{
      this.loadDepartments();
    }

    loadDepartments():void{

      this.departmentService.getAllDepartments().subscribe(data => {
        this.departments=data;
      });
    }

    saveDepartment():void{
      if(!this.departmentName.trim()){
        return;
      }
      
      if(this.editingId==null){
        this.departmentService.addDepartment({departmentName:this.departmentName}).subscribe(()=>{
          this.resetForm();
          this.loadDepartments();
        }
        )
      }
      else{
        this.departmentService.updateDepartment(this.editingId,{departmentName:this.departmentName}).subscribe(()=>{
          this.resetForm();
          this.loadDepartments();
        })
      }
    }

    editDepartment(item:Department):void{
      this.editingId=item.departmentId ??null;
      this.departmentName=item.departmentName;
    }

    deleteDepartment(id:string):void{
      this.departmentService.deleteDepartmentById(id).subscribe(()=>{
        this.loadDepartments();
      })
    }

    resetForm():void{
      this.departmentName='';
      this.editingId=null;
    }
}
