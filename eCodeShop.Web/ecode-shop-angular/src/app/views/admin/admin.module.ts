import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './../../app-routing.module';
import { IndexComponent } from "./index/index.component";
import { UserListComponent } from './user-list/user-list.component';
import { ProductListComponent } from './product-list/product-list.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { Routes, RouterModule, CanActivate } from '@angular/router';

import {MatTableModule} from '@angular/material/table';

@NgModule({
  declarations: [IndexComponent, UserListComponent, ProductListComponent, CategoryListComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    RouterModule,
    MatTableModule
  ],
  exports: [IndexComponent, UserListComponent, ProductListComponent, CategoryListComponent],
})
export class AdminModule { }
