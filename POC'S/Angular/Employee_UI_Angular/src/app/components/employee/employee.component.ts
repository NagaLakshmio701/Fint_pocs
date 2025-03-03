import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AsyncPipe, CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [AsyncPipe,CommonModule,FormsModule],
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'] // Fixed `styleUrls` here
})
export class EmployeeComponent implements OnInit {

  EmpList: any[] = []; // Specify array type for better readability

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get("https://freeapi.miniprojectideas.com/api/EmployeeApp/GetAllEmployee")
      .subscribe((res: any) => {
        console.log(res); // Log the response to check the structure
        // Assuming the actual array is within `res.data` or similar
        this.EmpList = Array.isArray(res) ? res : res.data; // Adjust based on structure
      });
  }
  
}
