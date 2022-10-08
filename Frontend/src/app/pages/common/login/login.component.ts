import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginResponse = '';
  loginClass = '';

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }

  loginForm = this.fb.group({
    username: [null, [Validators.required]],
    password: [null, [Validators.required]]
  })

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }
  
  onSubmit(){
    this.auth.login(this.loginForm.value).subscribe(
      (response: any) => {
      console.log(response);
      this.loginResponse = 'Logged in successfully!';
      this.loginClass = 'alert-success';
      localStorage.setItem('name', response[0]);
      localStorage.setItem('type', response[1]);
      this.router.navigateByUrl('home');
  },
  (error: any) => {
    console.log(error);
    this.loginResponse = `Login failed, ${error.error.message}, please try again!`;
    this.loginClass = 'alert-danger';
  })
}

  ngOnInit(): void {
  }

}
