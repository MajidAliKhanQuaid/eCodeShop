import { Component, OnInit } from '@angular/core';
import { AuthService } from './../../_services/auth.service';
import { HttpClient } from '@angular/common/http';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'login',
  // template: '<h1>{{name}}</h1>',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  formGroup: FormGroup;
  constructor(private authService: AuthService, private router: Router) { }
  initForm() {
    this.formGroup = new FormGroup({
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }
  ngOnInit(): void {
    this.initForm();
  }
  loginProcess() {
    console.log("Requesting to submit form");
    if (this.formGroup.valid) {
      this.authService.logIn(this.formGroup.value).subscribe((result) => {
        console.log("Auth Service | SUCCESS");
        console.log(result);
        localStorage.setItem("token", result.accessToken);
        const user = this.authService.getCurrentUser();
        if(user){
          console.log("Used found !", user.role);
          console.log("user.role.indexOf('Admin')", user.role.indexOf('Admin'));
          if(user.role && user.role.indexOf('Admin') !== -1){
            this.router.navigate(['admin']);
            return;
          }
        }
        this.router.navigate(['']);
      }, (error) => {
        console.log("Auth Service | FAILURE");
        console.log(error);
      });
    }
  }
}
