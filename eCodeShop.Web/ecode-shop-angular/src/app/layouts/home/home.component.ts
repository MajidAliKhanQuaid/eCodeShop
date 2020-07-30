import { Component, OnInit } from '@angular/core';
import { Product } from './../../model/product';
import { ProductService } from './../../services/product.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  products: Array<Product>;
  constructor(private productService: ProductService) {
    productService.getProducts().subscribe(products => this.products = products);

    // this.products.push({ id: 1, name: 'first', imageUrl: 'https://via.placeholder.com/150', description: 'This is first image', price: 100 });
    // this.products.push({ id: 2, name: 'second', imageUrl: 'https://via.placeholder.com/150', description: 'This is second image', price: 100 });
    // this.products.push({ id: 3, name: 'third', imageUrl: 'https://via.placeholder.com/150', description: 'This is third image', price: 100 });
    // this.products.push({ id: 4, name: 'fourth', imageUrl: 'https://via.placeholder.com/150', description: 'This is fourth image', price: 100 });
  }

  ngOnInit(): void {
  }

}
