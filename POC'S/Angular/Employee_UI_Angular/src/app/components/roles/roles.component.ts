import { HttpClient } from '@angular/common/http';
import { Component,inject,OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IRole } from '../../Model/Interface/role';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-roles',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.css'
})
export class RolesComponent implements OnInit{

  RoleList:IRole[]=[];
  http=inject(HttpClient)  //to connect with api end points 

   ngOnInit(): void {
    console.log("hai welcome")
    console.log(this.RoleList)
    this.getAllRoles();
   }

   getAllRoles(){
    this.http.get<IRole[]>("https://localhost:7222/api/Roles/GetAllRoles").subscribe((res:IRole[])=>{
   this.RoleList=res;
    })
   }


































  // Fname:string="snl";
  // Date =new Date();
  // Itype:string="radio";
  // Select:string="";


  // alertmsg(){
  //   alert(`Welcome ${this.Fname}`)
  // }

  // alertmsgvtharg(msg:string){
  //   alert(`Welcome ${msg}`)
  // }

}
