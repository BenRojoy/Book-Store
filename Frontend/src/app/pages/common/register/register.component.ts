import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private auth: AuthService, private router: Router) { }

  userModel = new User();
  registerResponse: any;
  registerClass: any;

  onSubmit(){
    // console.log(this.userModel);
    this.auth.register(this.userModel).subscribe(
      (response: any) => {
        console.log(response);
        this.registerResponse = 'Registered successfully!';
        this.registerClass = 'alert-success';
        this.router.navigateByUrl('login');
    },
    (error: any) => {
      console.log(error);
      this.registerResponse = `Registration failed, ${error.error.message}, please try again!`;
      this.registerClass = 'alert-danger';
      })
  }

  ngOnInit(): void {
  }

}
