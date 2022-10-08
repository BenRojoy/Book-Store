import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service'

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any;
  

  constructor(private dataService: DataService) {
    this.dataService.getUsers().subscribe((data: any) => {
      this.users = data;
    })
   }

  activateUser(id: any, status: any){
    this.dataService.adminUpdateUser(id, status).subscribe((data: any) => {

    })
  }

  ngOnInit(): void {
  }

}
