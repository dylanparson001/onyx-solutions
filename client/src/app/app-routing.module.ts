import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {ChatComponent} from "./chat/chat.component";
import {SchedulesComponent} from "./schedules/schedules.component";
import {InvoicesComponent} from "./invoices/invoices.component";
import {AuthGuard} from "./_guards/auth.guard";
import {TestErrorComponent} from "./errors/test-error/test-error.component";
import {NotFoundComponent} from "./errors/not-found/not-found.component";
import {ServerErrorComponent} from "./errors/server-error/server-error.component";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},

  // Set to use auth guard for these routes, avoids having to specify each authguard on every component
  {path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'chat', component: ChatComponent},
      {path: 'not-found', component: NotFoundComponent},
      {path: 'server-error', component: ServerErrorComponent},
      {path: 'schedules', component: SchedulesComponent},
      {path: 'invoices', component: InvoicesComponent}
    ],
  },
  {path: 'errors', component: TestErrorComponent },
  {path: '**', component: NotFoundComponent, pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
