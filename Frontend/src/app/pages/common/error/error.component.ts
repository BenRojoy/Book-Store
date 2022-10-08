import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {
  
  type: any;

  constructor() {
    this.type = localStorage.getItem('type');
   }

  ngOnInit(): void {
  }

}
