import { Component, OnInit } from '@angular/core';
import { Product } from '../../../../_models/product';
import { ProductService } from '../../../../_services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'price', 'edit', 'delete'];
  products: Array<Product>;
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(products => this.products = products);
  }

}
