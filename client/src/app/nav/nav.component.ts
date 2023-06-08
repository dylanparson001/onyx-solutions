import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Employee } from '../_models/employee';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  user:any = '';


  constructor(public accountService: AccountService) {}

  ngOnInit(): void {
  }

  login(){
    // uses account service to login to application
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
      },
      error: error => console.log(error)
    })
    // returns user name to display
    this.user = 'User';
  }

  logout(){
    this.accountService.logout();
  }

}
