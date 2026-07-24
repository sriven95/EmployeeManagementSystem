import { ClassServiceService } from './../../Services/Class/class-service.service';
import { Component,OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Class } from '../../Models/Class';
// corrected service import: use the service defined under Services/Class

@Component({
  selector: 'app-class',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './class.component.html',
  styleUrls: ['./class.component.css']
})
export class ClassComponent implements OnInit {
    classes:Class[]=[];
    className='';
    editingId:string|null=null;

    constructor(private classService:ClassServiceService ){}
    ngOnInit():void{
      this.loadClasses();
    }

    loadClasses():void{
      this.classService.getAllClasss().subscribe(data =>{
        this.classes = data;
      });
    }

    saveClass():void{
      if(!this.className.trim()){
        return;
      }

      if(this.editingId!==null){
        this.classService.updateClassById(this.editingId,{className:this.className}).subscribe(()=>{
          this.resetForm();
          this.loadClasses();
        });
      }
      else{
        this.classService.addClass({className:this.className}).subscribe(()=>{
          this.resetForm();
          this.loadClasses();
        })
      }
    }

    editClass(item:Class):void{
      this.editingId=item.ClassId ?? null;
      this.className=item.ClassName;
    }
    
    deleteClass(id:string):void{
      this.classService.deleteClassById(id).subscribe(()=>{
        this.loadClasses();
    });
    }

    resetForm():void{
      this.className='';
      this.editingId=null;
    }



}