import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { Orders } from '../../../models/orders.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  userId = localStorage.getItem('userid');
  books: any[] = [];
  status: any;
  orderModel = new Orders;
  addresses: any[] = [];
  addressId: any;
  isSubmitted = false;

  constructor(private dataService: DataService, private fb: FormBuilder, private router: Router) {     
   
    this.dataService.getCart(this.userId).subscribe((response: any) => {
    this.books = response;
    })
   
    this.dataService.getAddressByUser(this.userId).subscribe((response: any) => {
      this.addresses = response;
    })
   
  }

  addressForm = this.fb.group({
    address: ['', [Validators.required]],
  });

  removeBook(id: any)
  {
    this.dataService.deleteBookCart(id).subscribe(() =>
      this.status = 'Delete successful'
    );
    window.location.reload();
  }

  changeAddress(e: any) {
    this.address?.setValue(e.target.value, {
      onlySelf: true,
    });
  }

  get address() {
    return this.addressForm.get('address');
  }

  onSubmit(): void {
    this.isSubmitted = true;
    if (!this.addressForm.valid) {
      false;
    } else {
      if (this.addressForm.value.address)
      {
        this.orderModel.AddressId = parseInt(this.addressForm.value.address);
      }
      
      if (this.userId)
      {
        this.orderModel.UserId = parseInt(this.userId);
      }
      
      for (let book in this.books)
      {
        this.orderModel.BookId = this.books[book].BookId;
        this.orderModel.Quantity = this.books[book].Quantity;
        this.dataService.placeOrder(this.orderModel).subscribe((response: any) => {})
      }
      
      this.router.navigateByUrl('orders');
    }
  }

  ngOnInit(): void {
  }

}
