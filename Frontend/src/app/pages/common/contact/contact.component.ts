import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  type: any;

  constructor() {
    this.type = localStorage.getItem('type');
   }

  ngOnInit(): void {
  }

}
