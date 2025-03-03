import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  standalone: true,
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  EmpList: any[] = []; // Store the list of employees here

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get("https://freeapi.miniprojectideas.com/api/EmployeeApp/GetAllEmployee")
      .subscribe((res: any) => {
        // Assuming the employee data is in `res.data`
        this.EmpList = res.data;
      });
  }
}
