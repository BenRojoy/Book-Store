import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  type: any;
  book: any;
  id: any;

  constructor(private dataservice: DataService, private activatedRoute: ActivatedRoute) {
    this.type = localStorage.getItem('type');
    
    this.id = this.activatedRoute.snapshot.paramMap.get('id');

    this.dataservice.getBooksById(this.id).subscribe((response: any) => {
      this.book = response;
    })
   }

  ngOnInit(): void {
  }

}
