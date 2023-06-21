import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {ChatComponent} from "./chat/chat.component";
import {SchedulesComponent} from "./schedules/schedules.component";
import {InvoicesComponent} from "./invoices/invoices.component";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'chat', component: ChatComponent},
  {path: 'schedules', component: SchedulesComponent},
  {path: 'invoices', component: InvoicesComponent},
  {path: '**', component: HomeComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
