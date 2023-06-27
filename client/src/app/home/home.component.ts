import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  registerMode = false;
  employees: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(){
    this.http.get('https://localhost:5001/api/Employees').subscribe({
      next: response => this.employees = response,
      error: error => {console.log(error)}
    })
  }
  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }

}
