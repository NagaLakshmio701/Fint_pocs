import { Component, inject, OnInit } from '@angular/core';
import { MasterService } from '../../Services/master.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AsyncPipe, CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [AsyncPipe,FormsModule,CommonModule,DatePipe,RouterLink],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent implements OnInit{
  
  locationList$:Observable<any[]> = new Observable<any[]>
  masterService=inject(MasterService)
  searchResult:any[]=[];

  searchobj:any={
    fromLocation:"",
    toLocation:"",
    travelDate:""


  }

  ngOnInit(): void {
    this.getBusLocation();
    
  }

  getBusLocation(){
   this.locationList$=this.masterService.GetBusLocations();
  }

  searchBus() {
    const { fromLocation, toLocation, travelDate } = this.searchobj;
    if (fromLocation && toLocation && travelDate) {
      this.masterService.SearchBus(fromLocation, toLocation, travelDate).subscribe((res) => {
        console.log(res);
        this.searchResult=res
      });
    } else {
      alert('Please fill all fields!');
    }
  }



}
