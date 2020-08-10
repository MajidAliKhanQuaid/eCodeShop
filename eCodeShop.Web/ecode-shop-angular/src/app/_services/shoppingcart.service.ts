import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartItem } from './../_models/cartItem';
import { API_URL } from './../../environments/environment';
import { map, catchError } from "rxjs/operators";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShoppingcartService implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  addToCart(carItem: CartItem): void {
    console.log('ShoppingCartService - addToCart');
  }

  getCartItems = (): Observable<CartItem[]> => {
    return this.http.get(`${API_URL}/shoppingcart/cartitems`).pipe(map(result => {
      return <CartItem[]>result
    }),
      catchError(err => {
        return [];
      }));
  }

}
