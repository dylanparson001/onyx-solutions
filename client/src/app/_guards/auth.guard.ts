import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import {map, Observable} from 'rxjs';
import {AccountService} from "../_services/account.service";
import {ToastrService} from "ngx-toastr";

// 'Guards' routes from clients that are not signed in, not 100% protected

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private toastr: ToastrService) {}

  canActivate(
    // generataed by angular
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    // can return any of the above types, will be using the account service observable to return a boolean
    return this.accountService.currentEmployee$.pipe(
      // pipe and map allow us to perform actions with the variable
      map((employee) => {
        // If the employee is signed in, they can access the routes, if they are not, they cannot access the routes
        if (employee) return true;
        else {
          this.toastr.error('Unauthorized')
          return false
        }
      })
    )
  }

}
