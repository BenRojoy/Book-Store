import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  type: any;

  constructor() {
    let obj = localStorage.getItem('type');
    if (obj)
    {
      this.type = true;
    }
    else
    {
      this.type = false;
    }
   }

  ngOnInit(): void {
  }

}
