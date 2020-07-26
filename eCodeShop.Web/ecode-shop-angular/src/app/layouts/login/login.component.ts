import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from './../../auth-service.service';
import { HttpClient } from '@angular/common/http';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
} from '@angular/forms';

@Component({
  selector: 'login',
  // template: '<h1>{{name}}</h1>',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  formGroup: FormGroup;
  constructor(private authService: AuthServiceService) {}
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
    if (this.formGroup.valid) {
      this.authService.logIn(this.formGroup.value).subscribe((result) => {
        console.log(result);
      });
    }
  }
}
