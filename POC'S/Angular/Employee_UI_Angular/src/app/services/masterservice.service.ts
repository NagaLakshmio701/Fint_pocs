import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRole } from '../Model/Interface/role';

@Injectable({
  providedIn: 'root'
})
export class MasterserviceService {

  constructor(private http:HttpClient) {
  
   }
   getrolesbyservice():Observable<IRole[]>{
    return this.http.get<IRole[]>("https://localhost:7222/api/Roles/GetAllRoles") 
   }
}
