import { API_URL } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) { }

  logIn = (data): Observable<any> => {
    return this.http.post(`${API_URL}/authentication/token`, data);
  };

  isAuthenticated = (): Boolean => {
    return localStorage.getItem('token') != null;
    // return localStorage.getItem('token') != null;
  };

  getCurrentUser = (): any => {
    if (this.isAuthenticated()) {
      const token = localStorage.getItem('token');
      if (token) {
        return jwt_decode(token);
      }
    }
    return null;
  }

  getToken = (): string => {
    return localStorage.getItem('token');
  };

  logout = (): void => {
    localStorage.removeItem('token');
  };
}
