import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-page',
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.css']
})
export class CategoryPageComponent implements OnInit {

  books: any[] = [];
  catId: any;
  type: any;

  constructor(private dataService: DataService, private activatedRoute: ActivatedRoute) {
    
    this.type = localStorage.getItem('type');
    
    this.catId = this.activatedRoute.snapshot.paramMap.get('id');
    
    this.dataService.getBooksByCatId(this.catId).subscribe((response: any) => {
      this.books = response;
})
  }

  ngOnInit(): void {
  }

}
