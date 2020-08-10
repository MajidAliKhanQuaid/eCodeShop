import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../_models/user';
import { API_URL } from './../../environments/environment';
import { Observable } from "rxjs";
import { map, catchError } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUsers = (): Observable<User[]> => {
    return this.http.get(`${API_URL}/user/all`).pipe(map(result => {
      return <User[]>result
    }),
      catchError(err => {
        console.log("Unable to load users");
        return [];
      }));
  }

}
