import { Component, OnInit } from '@angular/core';
import { ShoppingcartService } from './../../services/shoppingcart.service'
import { CartItem } from 'src/app/model/cartItem';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})

export class CartComponent implements OnInit {
  cartItems = [];
  constructor(private cartService: ShoppingcartService) { }

  ngOnInit(): void {
    this.getCartItems();
  }

  getCartItems(): void {
    this.cartService.getCartItems().subscribe(cartItems => this.cartItems = this.cartItems);
  }

}
