import { Component, OnInit, Input } from '@angular/core';
import { Product } from './../../model/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  @Input() product: Product;
  constructor() { }

  ngOnInit(): void {
  }

  addToCart = (event, pId): void => {
    console.log('Add to Cart');
    console.log(event);
    console.log(pId);
  }

}
