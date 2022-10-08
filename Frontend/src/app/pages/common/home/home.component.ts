import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  type: any;

  constructor() {
    this.type = localStorage.getItem('type');
   }

  ngOnInit(): void {
  }

}
