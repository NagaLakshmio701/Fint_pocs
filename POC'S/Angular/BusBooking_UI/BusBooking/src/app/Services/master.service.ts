import { HttpClient } from '@angular/common/http';
import { ReturnStatement } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { URL,Method } from '../pages/API_URLS';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MasterService {

  constructor(private http:HttpClient) {

   
   }
   GetBusLocations():Observable<any[]>{
    return this.http.get<any[]>(URL.API_URL + Method.API_METHOD.GET_BUS_LOCATIONS);
      
   }


   SearchBus(from:string,to:string,date:string):Observable<any[]>{
    return this.http.get<any[]>(`${URL.API_URL}searchBus?fromLocation=${from}&toLocation=${to}&travelDate=${date}`)


   }


}


