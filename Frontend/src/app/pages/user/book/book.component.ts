import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Cart } from 'src/app/models/cart.model';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  type: any;
  book: any;
  id: any;
  user = localStorage.getItem('userid');
  userId: any;
  cart = new Cart();

  constructor(private dataservice: DataService, private activatedRoute: ActivatedRoute, private router: Router) {
    this.type = localStorage.getItem('type');
    
    this.id = this.activatedRoute.snapshot.paramMap.get('id');

    this.dataservice.getBooksById(this.id).subscribe((response: any) => {
      this.book = response;
    })

    if (this.user != null)
    {
      this.userId =  parseInt(this.user, 10);
    }
    this.cart.UserId = this.userId;
    this.cart.Quantity = 1;
   }

   addWishlist(bookId: any)
   {
    this.cart.BookId = bookId;
    this.dataservice.addToWishlist(this.cart).subscribe((response: any) => {
      this.router.navigateByUrl('wishlist');
    })
   }

   addCart(bookId: any)
   {
    this.cart.BookId = bookId;
      this.dataservice.addToCart(this.cart).subscribe((response: any) => {
        this.router.navigateByUrl('cart');
      })
   }

  ngOnInit(): void {
  }

}
