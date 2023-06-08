import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { Employee } from '../_models/employee';

// Services live for the life of the application, currently this one will be used for http requests
// This is also useful for handling state that will want to continue throughout the application

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';
  // From rxjs sets type of what we expect
  private currentEmployeeSource = new BehaviorSubject<Employee | null>(null);
  // Sets as an observable
  currentEmployee$ = this.currentEmployeeSource.asObservable();

  constructor(private http: HttpClient) {}

  login(model: any) {
    // <Employee> type of the response we expect back
    return this.http.post<Employee>(this.baseUrl + 'account/login', model).pipe(
      // map allows us to make changes to data as it comes in
      map((response: Employee) => {
        const employee = response;
        // if employee was returned place it into local storage (has username and token returned from api)
        if (employee) {
          localStorage.setItem('employee', JSON.stringify(employee));
          this.currentEmployeeSource.next(employee);
        }
      })
    );
  }

  register(model: any){
    return this.http.post<Employee>(this.baseUrl + 'account/register', model).pipe(
      map(employee => {
        if(employee){
          localStorage.setItem('employee', JSON.stringify(employee));
          this.currentEmployeeSource.next(employee)
        }
      })
    )
  }

  // sets the current employee returned from storage
  setCurrentEmployee(employee: Employee) {
    this.currentEmployeeSource.next(employee);
  }

  logout() {
    // removes from local storage, forcing login again
    localStorage.removeItem('employee');
    this.currentEmployeeSource.next(null);
  }

}
