import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from '../Model/Class/client';
import { environment } from '../../environments/environment.development';
import { constant } from '../constants/endpoints';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private http:HttpClient)  { }

getAllClient():Observable<Client[]>
{
return this.http.get<Client[]>(environment.API_URL+constant.API_METOD.GET_CLIENTS)
}

addRole(obj:Client):Observable<Client[]>
{
return this.http.post<Client[]>(environment.API_URL+constant.API_METOD.ADD_CLIENT,obj)
}

updateRole(obj:Client):Observable<Client[]>
{
return this.http.put<Client[]>(environment.API_URL+constant.API_METOD.UPDATE_CLIENT,obj)
}

deleteRole(id: number): Observable<Client[]> {
  return this.http.delete<Client[]>(`${environment.API_URL}${constant.API_METOD.DELETE_CLIENT}${id}`);
}

}