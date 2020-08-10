import { Component, OnInit } from '@angular/core';
import { Product } from './../../_models/product';
import { ProductService } from './../../_services/product.service';
//import * as jwt_decode from "jwt-decode";
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  products: Array<Product>;
  constructor(private productService: ProductService) {
    productService.getProducts().subscribe(products => this.products = products);
  }

  ngOnInit(): void {
  }

}
