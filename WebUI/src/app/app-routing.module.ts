import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountsListComponent } from './components/accountList/accountList.component';
import { AccountDetailComponent } from './components/accountDetail/accountDetail.component';


const routes: Routes = [
  { path: 'accounts/:id', component: AccountDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
