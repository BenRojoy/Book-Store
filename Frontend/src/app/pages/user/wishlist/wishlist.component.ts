import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service'

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  userId = localStorage.getItem('userid');
  books: any[] = [];
  status: any;

  constructor(private dataService: DataService) {     
    this.dataService.getWishlist(this.userId).subscribe((response: any) => {
    this.books = response;
    })
}
removeBook(id: any)
{
  this.dataService.deleteBookWishlist(id).subscribe(() =>
    this.status = 'Delete successful'
  );
  window.location.reload();
}

  ngOnInit(): void {
  }

}
