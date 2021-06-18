import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserDetailsComponent } from './components/user/user-details/user-details.component';
import { UserListComponent } from './components/user/user-list/user-list.component';
import { UserComponent } from './components/user/user.component';

const routes: Routes = [
  {
    path: 'user', redirectTo: 'user/list'
  },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'details/:id', component: UserDetailsComponent },
      { path: 'details', component: UserDetailsComponent },
      { path: 'list', component: UserListComponent }
    ]
  },
  {
    path: '', redirectTo: 'user/list', pathMatch: 'full'
  },
  {
    path: '**', redirectTo: 'user/list', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
