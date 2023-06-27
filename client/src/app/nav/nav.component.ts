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
  model: any = {}; // set through ngM
  user:any = '';

  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) {}

  ngOnInit(): void {}

  login(){
    // uses account service to login to application
    this.accountService.login(this.model).subscribe({
      next: () => this.router.navigateByUrl('/schedules')
    })
  }

  logout(){
    // log out and return to home
    this.accountService.logout();

    this.router.navigateByUrl('/home')

  }

}
