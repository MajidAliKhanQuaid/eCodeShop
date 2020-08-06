import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private authService: AuthService) {

  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const userData = this.authService.getCurrentUser();
    //console.log(userData);
    //console.log('Roles');
    //console.log(next.data.roles);

    //console.log('Filtered');
    //console.log(next.data.roles.filter(x => userData.role.includes(x)));

    if (next.data.roles && next.data.roles.length > 0 && next.data.roles.filter(x => userData.role.includes(x)).length == 0) {
      return false;
    }

    return true;
  }
  
}
