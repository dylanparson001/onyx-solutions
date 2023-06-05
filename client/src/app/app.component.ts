import { HttpClient } from '@angular/common/http'
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Onyx Solutions';
  employees: any;

  constructor(private http: HttpClient) { }
  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/Employees').subscribe({
      next: response => this.employees = response,
      error: error => {console.log(error)},
      complete: () => {}
    }

    )
  }


}
