import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
// 
import {Error404Component} from './_components/error404/error404.component';
import { LoginComponent } from './_layouts/login/login.component';
import { LogoutComponent } from './_layouts/logout/logout.component';
import { HomeComponent } from './_layouts/home/home.component';
// admin components
import { DefaultComponent as AdminDefault} from './_modules/admin/default/default.component';
import { IndexComponent as AdminIndex} from './_modules/admin/index/index.component';
import { UserListComponent as AdminUsersList } from './_modules/admin/user/user-list/user-list.component';
import { CategoryListComponent as AdminCategoryList } from './_modules/admin/category/category-list/category-list.component';
import { ProductListComponent as AdminProductList } from './_modules/admin/product/product-list/product-list.component';

import { AuthGuard } from './_guards/auth-guard';
import { AdminGuard } from './_guards/admin.guard';

import { CreateorupdateComponent } from './_layouts/admin/product/createorupdate/createorupdate.component';
import { UserNewComponent } from './_modules/admin/user/user-new/user-new.component';
import { ProductNewComponent } from './_modules/admin/product/product-new/product-new.component';
import { CategoryNewComponent } from './_modules/admin/category/category-new/category-new.component';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  {
    path: 'admin',
    component: AdminDefault,
    canActivate: [AuthGuard, AdminGuard],
    data: {
      roles: ['Admin']
    },
    children: [
      { path: '', component : AdminIndex},
      { path: 'users', component: AdminUsersList },
      { path: 'user/:id', component: UserNewComponent},
      { path: 'products', component: AdminProductList },
      { path: 'product/:id', component: ProductNewComponent},
      { path: 'categories', component: AdminCategoryList },
      { path: 'category/:id', component: CategoryNewComponent},
      {path: '**', component: Error404Component}
    ]
  },
  //{ path: 'admin/index', component: AdminHome },
  //{ path: 'admin/users', component: AdminUsersList },
  //{ path: 'admin/categories', component: AdminCategoryList },
  // { path: 'admin/products', component: AdminProductList },
   { path: 'admin/product/createorupdate', component: CreateorupdateComponent },
   { path: '**', component: Error404Component },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
