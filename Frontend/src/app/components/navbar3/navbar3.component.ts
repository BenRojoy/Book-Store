import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { Router } from '@angular/router'
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-navbar3',
  templateUrl: './navbar3.component.html',
  styleUrls: ['./navbar3.component.css']
})
export class Navbar3Component implements OnInit {

  categories: any;
  name: any;

  constructor(private dataService: DataService, private routerService: Router, private auth: AuthService) {
    this.dataService.getCategories().subscribe((data: any) => {
      this.categories = data;
    })
    this.name = localStorage.getItem('name');
  }

  logout()
  {
    this.auth.logout();

  }


  ngOnInit(): void {
  }

}
