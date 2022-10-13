import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service';
import { Address } from '../../../models/address.model';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {

  addresses: any[] = [];
  id = localStorage.getItem("userid");
  userId: any;
  addressId: any;
  addressModel = new Address();
  editResponse: any;
  editClass: any;
  addResponse: any;
  addClass: any;

  constructor(private dataService: DataService) {

    if (this.id)
    {
      this.userId = this.id;
    }

    this.dataService.getAddressByUser(this.userId).subscribe((response: any) => {
      this.addresses = response;
    })

   }

   setUserId()
   {
    this.addressModel.UserId = this.userId;
   }

   setAddressId(id: any)
   {
    this.addressModel.AddressId = id;
   }

   deleteAddress(id: any)
   {
    this.dataService.deleteAddress(id).subscribe(() => {});
    window.location.reload();
   }

   onSubmit1(){
    // console.log(this.userModel);
    this.dataService.editAddress(this.addressModel).subscribe(
      (response: any) => {
        this.editResponse = 'Edited successfully!';
        this.editClass = 'alert-success';
        window.location.reload();
    },
    (error: any) => {
      console.log(error);
      this.editResponse = `Edit failed, ${error.error.message}, please try again!`;
      this.editClass = 'alert-danger';
      })
  }

  onSubmit2(){
    // console.log(this.userModel);
    this.dataService.addAddress(this.addressModel).subscribe(
      (response: any) => {
        console.log(response);
        this.addResponse = 'Added successfully!';
        this.addClass = 'alert-success';
        window.location.reload();
    },
    (error: any) => {
      console.log(error);
      this.addResponse = `Add failed, ${error.error.message}, please try again!`;
      this.addClass = 'alert-danger';
      })
  }

  ngOnInit(): void {
  }

}
