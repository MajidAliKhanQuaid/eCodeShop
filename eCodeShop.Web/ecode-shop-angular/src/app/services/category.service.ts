import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_URL } from './../../environments/environment';
import { Observable } from "rxjs";
import { map, catchError } from "rxjs/operators";
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get(`${API_URL}/category/all`).pipe(map(result => {
      return <Category[]>result
    }),
      catchError(err => {
        console.log("Unable to load categories");
        return [];
      }));
  }
}
