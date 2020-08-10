import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './../../app-routing.module';
import { IndexComponent } from "./index/index.component";
import { Routes, RouterModule, CanActivate } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatTableModule} from '@angular/material/table';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DefaultComponent } from './default/default.component';
import { Error404Component } from 'src/app/_components/error404/error404.component';

// modules import
import { CategoryModule } from "./category/category.module";
import { ProductModule } from "./product/product.module";
import { UserModule } from "./user/user.module";

@NgModule({
  declarations: [IndexComponent, DefaultComponent, Error404Component],
  imports: [
    CommonModule,
    AppRoutingModule,
    RouterModule,
    MatTableModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    FlexLayoutModule,
    ProductModule,
    CategoryModule,
    UserModule
  ],
  exports: [IndexComponent, DefaultComponent, Error404Component],
})
export class AdminModule { }
