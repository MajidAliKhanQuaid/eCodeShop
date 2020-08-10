import { Component, OnInit } from '@angular/core';
import { User } from '../../../../_models/user';
import { UserService } from '../../../../_services/user.service';

import { Routes, RouterModule, CanActivate } from '@angular/router';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'email', 'edit', 'delete'];
  users: Array<User>;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(users => this.users = users);
  }

}
