import { Component } from '@angular/core';
import { RolesComponent } from '../roles/roles.component';
import { DesignationComponent } from '../designation/designation.component';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from '../employee/employee.component';

@Component({
  selector: 'app-master',
  standalone: true,
  imports: [RolesComponent,DesignationComponent,CommonModule,EmployeeComponent],
  templateUrl: './master.component.html',
  styleUrl: './master.component.css'
})
export class MasterComponent {

  CurrentComponent:string=" ";

  frole(cv:string){
    this.CurrentComponent=cv;
  }



}
