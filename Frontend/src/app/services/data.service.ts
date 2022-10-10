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

  addToCart(cart: any) {
    return this.http.post(`http://localhost:59512/api/cart`, cart);
  }

  addToWishlist(wishlist: any) {
    return this.http.post(`http://localhost:59512/api/wishlist`, wishlist);
  }

  getCart(id: any) {
    return this.http.get(`http://localhost:59512/api/cart/${id}`);
  }

  getWishlist(id: any) {
    return this.http.get(`http://localhost:59512/api/wishlist/${id}`);
  }

  deleteBookCart(id: any) {
    return this.http.delete(`http://localhost:59512/api/cart/${id}`);
  }
  
  deleteBookWishlist(id: any) {
    return this.http.delete(`http://localhost:59512/api/wishlist/${id}`);
  }

  adminUpdateUser(id: any, status: any)
  {
    return this.http.put(`http://localhost:59512/api/user?id=${id}&status=${status}`, null);
  }
}
