import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './layouts/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';

import { FlexLayoutModule } from '@angular/flex-layout';
import { HomeComponent } from './layouts/home/home.component';
import { LogoutComponent } from './layouts/logout/logout.component';
import { ProductComponent } from './components/product/product.component';
import { CreateorupdateComponent } from './layouts/admin/product/createorupdate/createorupdate.component';
import { ListComponent } from './layouts/admin/product/list/list.component';
import { CartComponent } from './components/cart/cart.component';
import { NavbarComponent } from './components/navbar/navbar.component';


import { TokenInterceptor } from './interceptors/token-interceptor';
import { ErrorInterceptor } from './interceptors/error-interceptor';
import { AdminModule } from './views/admin/admin.module';
// import { IndexComponent } from './views/admin/index/index.component';
// import { ProductListComponent } from './views/admin/product-list/product-list.component';
// import { CategoryListComponent } from './views/admin/category-list/category-list.component';
// import { UserListComponent } from './views/admin/user-list/user-list.component';

@NgModule({
  declarations: [AppComponent, LoginComponent, HomeComponent, LogoutComponent, ProductComponent, CreateorupdateComponent, ListComponent, CartComponent, NavbarComponent],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatToolbarModule,
    MatIconModule,
    MatPaginatorModule,
    AdminModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
