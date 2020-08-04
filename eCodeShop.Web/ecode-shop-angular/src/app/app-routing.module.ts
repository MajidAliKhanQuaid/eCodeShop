import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { LoginComponent } from './layouts/login/login.component';
import { LogoutComponent } from './layouts/logout/logout.component';
import { HomeComponent } from './layouts/home/home.component';
import { AuthGuard } from './guards/auth-guard';
import { CreateorupdateComponent } from './layouts/admin/product/createorupdate/createorupdate.component';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  { path: 'admin/product/createorupdate', component: CreateorupdateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
