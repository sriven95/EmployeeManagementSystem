import { Component, OnInit } from '@angular/core';
import { Employee } from '../../Models/Employee';
import { Department } from '../../Models/Department';
import { EmployeeService } from '../../Services/Employee/employee.service';
import { DepartmentService } from '../../Services/Department/department.service';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit{
  employees:Employee[]=[];
  departments:Department[]=[];
  editingId:string|null=null;
  employee={
    firstName: '',
    lastName: '',
    email: '',
    departmentId: ''
  }

  constructor(private employeeService:EmployeeService,private departmentService:DepartmentService){}

  ngOnInit():void{
    this.loadEmployees();
    this.loadDepartments();
  }


  loadEmployees(){
    this.employeeService.getAllEmployees().subscribe(data =>{
      this.employees=data;
    })
  }

  loadDepartments():void{

      this.departmentService.getAllDepartments().subscribe(data => {
        this.departments=data;
      });
  }

  saveEmployees(){
    if(!this.employee.firstName|| !this.employee.lastName|| !this.employee.email||!this.employee.departmentId){
      return;
    }

    if(this.editingId==null){
      this.employeeService.addEmployee(this.employees).subscribe(()=>{
        this.resetForm();
        this.loadEmployees();
      })
    }
    else{
       this.employeeService.updateEmployeeById(this.editingId,this.employees).subscribe(()=>{
        this.resetForm();
        this.loadEmployees();
      })
    }
  }

  editEmployee(item:Employee):void{
    this.editingId=item.employeeId;
    this.employee={
      firstName:item.firstName,
      lastName:item.lastName,
      email:item.email,
      departmentId:item.departmentId
    }
  }

  deleteEmployee(Id:string):void{
    this.employeeService.deleteEmployeeById(Id).subscribe(()=>{
        this.loadEmployees();
      })
  }

  resetForm():void{
    this.editingId=null;
    this.employee={
      firstName:'',
      lastName:'',
      email:'',
      departmentId:''
    }
   }

}
