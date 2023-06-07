import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

// Services live for the life of the application, currently this one will be used for http requests
// This is also useful for handling state that will want to continue throughout the application

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http:HttpClient) { }

  login(model: any){
    return this.http.post(this.baseUrl + 'account/login', model);
  }
}
