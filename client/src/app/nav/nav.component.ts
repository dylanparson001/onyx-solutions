import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Employee } from '../_models/employee';
import { Observable, of } from 'rxjs';
import {provideRouter, Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  user:any = '';

  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) {}

  ngOnInit(): void {}

  login(){
    // uses account service to login to application
    this.accountService.login(this.model).subscribe({
      next: () => this.router.navigateByUrl('/schedules'),
      error: error => {
        console.log(error)
        this.toastr.error('Failed to login', error.error)
      }
    })
    // returns user name to display
    this.user = 'User';
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/home')

  }

}
