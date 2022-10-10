import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  userId = localStorage.getItem('userid');
  books: any[] = [];
  status: any;

  constructor(private dataService: DataService) {     
    this.dataService.getCart(this.userId).subscribe((response: any) => {
    this.books = response;
    })
}
removeBook(id: any)
{
  this.dataService.deleteBookCart(id).subscribe(() =>
    this.status = 'Delete successful'
  );
  window.location.reload();
}

  ngOnInit(): void {
  }

}
