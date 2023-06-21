import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ChatComponent } from './chat/chat.component';
import { SchedulesComponent } from './schedules/schedules.component';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';
import { InvoicesComponent } from './invoices/invoices.component';
import {ToastrModule} from "ngx-toastr";
import {SharedModule} from "./_modules/shared.module";
import { TestErrorComponent } from './errors/test-error/test-error.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    ChatComponent,
    SchedulesComponent,
    EmployeeDetailComponent,
    InvoicesComponent,
    TestErrorComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
