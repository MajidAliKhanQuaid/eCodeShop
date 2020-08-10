import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductNewComponent } from './product-new/product-new.component';
import { ProductListComponent } from './product-list/product-list.component';

import { Routes, RouterModule, CanActivate } from '@angular/router';

// angular material

import {MatSidenavModule} from '@angular/material/sidenav';
import {MatTableModule} from '@angular/material/table';
import {MatListModule} from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';

// angular flex

import { FlexLayoutModule } from '@angular/flex-layout';

// forms and http

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [ProductNewComponent, ProductListComponent],
  imports: [
    CommonModule,
    // Material
    MatSidenavModule,
    MatTableModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatToolbarModule,
    MatIconModule,
    MatPaginatorModule,
    // Flex
    FlexLayoutModule,
    // Router
    RouterModule,
    // forms
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [ProductNewComponent, ProductListComponent]
})
export class ProductModule { }
