import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { Employee } from './_models/employee';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Onyx Solutions';

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
   this.setCurrentEmployee();
  }

  setCurrentEmployee(){
    // gets employee from local storage if it exists
    const employeeString = localStorage.getItem("employee");
    // if it doesnt, return from function
    if(!employeeString) return;

    // gets employee parsed from string
    const employee: Employee = JSON.parse(employeeString);


    this.accountService.setCurrentEmployee(employee);
  }


}
