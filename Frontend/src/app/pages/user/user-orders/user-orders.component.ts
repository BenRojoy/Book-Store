import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service'

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css']
})

export class UserOrdersComponent implements OnInit {

  userId = localStorage.getItem('userid');
  books: any[] = [];
  status: any;

  constructor(private dataService: DataService) {     
    this.dataService.getOrderByUser(this.userId).subscribe((response: any) => {
    this.books = response;
    })
  }

  removeBookOrder(id: any)
  {
    this.dataService.deleteOrder(id).subscribe(() =>
      this.status = 'Delete successful'
    );
    window.location.reload();
  }

  ngOnInit(): void {
  }

}
