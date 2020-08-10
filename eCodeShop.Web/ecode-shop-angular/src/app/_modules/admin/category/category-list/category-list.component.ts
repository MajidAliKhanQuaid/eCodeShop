import { Component, OnInit } from '@angular/core';
import { Category } from '../../../../_models/category';
import { CategoryService } from '../../../../_services/category.service';
@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {
  displayedColumns: string[] = [ 'name', 'edit', 'delete'];
  categories: Array<Category>;
  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(categories => this.categories = categories);
  }

}
