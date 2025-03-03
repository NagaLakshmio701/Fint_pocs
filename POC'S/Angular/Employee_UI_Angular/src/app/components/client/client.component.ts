import { Component, OnInit } from '@angular/core';
import { Client } from '../../Model/Class/client';
import { FormsModule } from '@angular/forms';
import { ClientService } from '../../services/client.service';
import { CommonModule, LowerCasePipe, UpperCasePipe } from '@angular/common';

@Component({
  selector: 'app-client',
  standalone: true,
  imports: [FormsModule,CommonModule,UpperCasePipe,LowerCasePipe],
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  fname:string="Angular 18"

  clientobj: Client = new Client();
  clientlist: Client[] = [];

  constructor(private clientservice: ClientService) {}

  ngOnInit(): void {
    this.loadclient();
  }

  loadclient() {
    this.clientservice.getAllClient().subscribe((res: Client[]) => {
      this.clientlist = res;
    });
  }

  // onSaveClient() {
  //   this.clientservice.addRole(this.clientobj).subscribe((res: any) => {
  //     if (res && res.roleId) { // Check if roleId exists as an indicator of success
  //       alert("Client created successfully");
  //       this.clientobj=new Client();
  //       this.loadclient();
  //       this.resetForm();
  //     } else {
  //       alert("FAIL");
  //     }
  //   });
    
    
  // }


  onSaveClient() {
    if (this.clientobj.roleId) {
      // If roleId exists, update the role
      this.clientservice.updateRole(this.clientobj).subscribe((res: any) => {
        alert("Client updated successfully");
        this.resetForm();
        this.loadclient();
      }, error => {
        alert("Update failed");
        console.error(error);
      });
    } else {
      // If no roleId, add a new role
      this.clientservice.addRole(this.clientobj).subscribe((res: any) => {
        alert("Client created successfully");
        this.resetForm();
        this.loadclient();
      }, error => {
        alert("Creation failed");
        console.error(error);
      });
    }
  }
  

  UpdateRole(data:Client){
    this.clientobj=data;
  
  
  }
    resetForm() {
      this.clientobj = new Client();
    }
deleteRole(roleId:number){
  
  this.clientservice.deleteRole(roleId).subscribe((res:any)=>{
  //  alert("Deleted Successfully")
   this.loadclient();
  })

}

}
