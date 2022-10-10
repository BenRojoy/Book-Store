import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service'

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any;
  response: any;

  constructor(private dataService: DataService) {
    this.dataService.getUsers().subscribe((data: any) => {
      this.users = data;
    })
   }

  activateUser(id: any){
    this.dataService.adminUpdateUser(id, 1).subscribe((data: any) => {
      this.response = data;
    })
    window.location.reload();
  }
  deActivateUser(id: any){
    this.dataService.adminUpdateUser(id, 0).subscribe((data: any) => {
      this.response = data;
    })
    window.location.reload();
  }

  ngOnInit(): void {
  }

}
