import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
// 
import { LoginComponent } from './layouts/login/login.component';
import { LogoutComponent } from './layouts/logout/logout.component';
import { HomeComponent } from './layouts/home/home.component';
// admin components
import { IndexComponent as AdminHome } from './views/admin/index/index.component';
import { UserListComponent as AdminUsersList } from './views/admin/user-list/user-list.component';
import { CategoryListComponent as AdminCategoryList } from './views/admin/category-list/category-list.component';
import { ProductListComponent as AdminProductList } from './views/admin/product-list/product-list.component';

import { AuthGuard } from './guards/auth-guard';
import { AdminGuard } from './guards/admin.guard';

import { CreateorupdateComponent } from './layouts/admin/product/createorupdate/createorupdate.component';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  {
    path: 'admin',
    component: AdminHome,
    canActivate: [AuthGuard, AdminGuard],
    data: {
      roles: ['Admin']
    },
    children: [
      { path: 'users', component: AdminUsersList },
      { path: 'products', component: AdminProductList },
      { path: 'categories', component: AdminCategoryList },
    ]
  },
  //{ path: 'admin/index', component: AdminHome },
  //{ path: 'admin/users', component: AdminUsersList },
  //{ path: 'admin/categories', component: AdminCategoryList },
  // { path: 'admin/products', component: AdminProductList },
   { path: 'admin/product/createorupdate', component: CreateorupdateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
