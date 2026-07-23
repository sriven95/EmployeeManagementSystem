import { Component,OnInit } from '@angular/core';
import { Class } from '../../Models/Class';
import { ClassService } from '../../Services/class.service';

@Component({
  selector: 'app-class',
  standalone: true,
  imports: [],
  templateUrl: './class.component.html',
  styleUrl: './class.component.css'
})
export class ClassComponent implements OnInit {

  classes:Class[]=[];
  className='';
  editingId:string|null = null;

  constructor(private classService:ClassService){}

  ngOnInit(): void {
    this.loadClasses();
  }
  loadClasses() {

  }


}
