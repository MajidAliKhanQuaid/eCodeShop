import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { apiUrl } from './../../../../../environments/environment';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
} from '@angular/forms';

@Component({
  selector: 'app-createorupdate',
  templateUrl: './createorupdate.component.html',
  styleUrls: ['./createorupdate.component.scss'],
})
export class CreateorupdateComponent implements OnInit {
  productForm: FormGroup;
  productImage: File;
  constructor(private http: HttpClient, private router: Router) { }
  initForm() {
    this.productForm = new FormGroup({
      name: new FormControl('', Validators.required),
      price: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      imageUrl: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.initForm();
  }

  imageChange = (evt): void => {
    this.productImage = <File>evt.target.files[0];
    console.log(this.productImage);
  };

  saveProduct = () => {
    const formData = new FormData();
    formData.append("name", this.productForm.controls["name"].value);
    formData.append("price", this.productForm.controls["price"].value);
    formData.append("description", this.productForm.controls["description"].value);
    formData.append("image", this.productImage);
    //
    console.log(formData.get("name"));
    this.http.post(`${apiUrl}/product/save`, formData).subscribe((result) => {
      console.log("Product Save | SUCCESS");
      console.log(result);
      this.router.navigate(['']);
    }, (error) => {
      console.log("Product Save | FAILURE");
      console.log(error);
    });
  };
}
