import { Component, inject, OnInit } from '@angular/core';
import { MasterserviceService } from '../../services/masterservice.service';
import { IRole } from '../../Model/Interface/role';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-designation',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './designation.component.html',
  styleUrl: './designation.component.css'
})
export class DesignationComponent implements OnInit {
  RoleListService:IRole[]=[];
   isload:boolean=true;
 service=inject(MasterserviceService)

  ngOnInit(): void {
    this.service.getrolesbyservice().subscribe((result:IRole[])=>{
      this.RoleListService=result
      this.isload=false
    })
    
    
  }

}
