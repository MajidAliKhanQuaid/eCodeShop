import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../model/product';
import { apiUrl } from './../../environments/environment';
import { Observable } from "rxjs";
import { map, catchError } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ProductService implements OnInit {

  constructor(private http: HttpClient) { }
  ngOnInit(): void {

  }

  findProductById(id): Observable<Product | any> {
    return this.http.post(`${apiUrl}/product/find`, { id: id }).pipe(map(result => result));
  }

  getProducts(): Observable<Product[]> {
    return this.http.get(`${apiUrl}/product/all`).pipe(map(result => {
      return <Product[]>result
    }),
      catchError(err => {
        return [];
      }));
  }

  saveProduct(product): Observable<Product | any> {
    return this.http.post(`${apiUrl}/product/save`, product).pipe(map(result => result));
  }

  updateProduct(): Product {
    return null;
  }

}
