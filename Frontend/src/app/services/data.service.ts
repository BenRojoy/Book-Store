import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  
  getCategories() {
    return this.http.get('http://localhost:59512/api/category');
  }
  
  getBooksById(id: any) {
    return this.http.get(`http://localhost:59512/api/book?x=1&id=${id}`);
  }
  
  getBooksByCatId(id: any) {
    return this.http.get(`http://localhost:59512/api/book/${id}`);
  }

  getUsers() {
    return this.http.get(`http://localhost:59512/api/user`);
  }

  adminUpdateUser(id: any, status: any)
  {
    return this.http.put(`http://localhost:59512/api/book?id=${id}&status=${status}`, null);
  }
}
