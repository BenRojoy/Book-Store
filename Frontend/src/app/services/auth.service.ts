import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  loggedOut = false;
  userType: any;

  constructor(private http: HttpClient, private router: Router) {}

  register(user: any){
    return this.http.post('http://localhost:59512/api/user', user);
  }

  login(user: any){
    return this.http.post('http://localhost:59512/api/login', user);
  }

  logout() {
    localStorage.clear();
    this.router.navigateByUrl('login');
    this.loggedOut = true;
  }

  checkToken(){
    if(localStorage.getItem('token')){
      return true;
    } else {
      return false;
    }
  }

}
