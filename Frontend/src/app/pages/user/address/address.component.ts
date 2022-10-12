import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {

  addresses: any[] = [];
  id = localStorage.getItem("userid");

  constructor(private dataService: DataService) {

    this.dataService.getAddressByUser(this.id).subscribe((response: any) => {
      this.addresses = response;
    })
   }

  ngOnInit(): void {
  }

}
