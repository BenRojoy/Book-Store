import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { Router } from '@angular/router'

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories: any;

  constructor(private dataService: DataService, private routerService: Router) { 
    this.dataService.getCategories().subscribe((data: any) => {
      this.categories = data;
    })
   }

  onClickHandler(catId: any){
    this.routerService.navigate(['products', catId]);
  }

  ngOnInit(): void {
  }

}
