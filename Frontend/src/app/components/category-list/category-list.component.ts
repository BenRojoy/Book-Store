import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  
  categories: any[] = [];

  constructor(private dataService: DataService) {
    
    this.dataService.getCategories().subscribe((response: any) => {
      this.categories = response;
    })
  }

  ngOnInit(): void {
  }

}
