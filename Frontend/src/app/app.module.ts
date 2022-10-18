import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CategoryComponent } from './components/category/category.component';
import { HomeComponent } from './pages/common/home/home.component';
import { BookComponent } from './pages/user/book/book.component';
import { LoginComponent } from './pages/common/login/login.component';
import { RegisterComponent } from './pages/common/register/register.component';
import { AdminDashComponent } from './pages/admin/admin-dash/admin-dash.component';
import { UserDashComponent } from './pages/user/user-dash/user-dash.component';
import { FooterComponent } from './components/footer/footer.component';
import { Navbar1Component } from './components/navbar1/navbar1.component';
import { HeaderComponent } from './components/header/header.component';
import { Navbar2Component } from './components/navbar2/navbar2.component';
import { Navbar3Component } from './components/navbar3/navbar3.component';
import { SiteHomeComponent } from './pages/common/site-home/site-home.component';
import { WishlistComponent } from './pages/user/wishlist/wishlist.component';
import { CartComponent } from './pages/user/cart/cart.component';
import { UserOrdersComponent } from './pages/user/user-orders/user-orders.component';
import { AdminOrdersComponent } from './pages/admin/admin-orders/admin-orders.component';
import { UsersComponent } from './pages/admin/users/users.component';
import { AdminBookComponent } from './pages/admin/admin-book/admin-book.component';
import { AdminCategoryComponent } from './pages/admin/admin-category/admin-category.component';
import { CategoryPageComponent } from './pages/user/category-page/category-page.component';
import { ErrorComponent } from './pages/common/error/error.component';
import { AboutComponent } from './pages/common/about/about.component';
import { ContactComponent } from './pages/common/contact/contact.component';
import { CategoryListComponent } from './components/category-list/category-list.component';
import { UserOptionsComponent } from './components/user-options/user-options.component';
import { AdminOptionsComponent } from './components/admin-options/admin-options.component';
import { AddressComponent } from './pages/user/address/address.component';
import { CouponComponent } from './pages/admin/coupon/coupon.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    HomeComponent,
    BookComponent,
    LoginComponent,
    RegisterComponent,
    AdminDashComponent,
    UserDashComponent,
    FooterComponent,
    Navbar1Component,
    HeaderComponent,
    Navbar2Component,
    Navbar3Component,
    SiteHomeComponent,
    WishlistComponent,
    CartComponent,
    UserOrdersComponent,
    AdminOrdersComponent,
    UsersComponent,
    AdminBookComponent,
    AdminCategoryComponent,
    CategoryPageComponent,
    ErrorComponent,
    AboutComponent,
    ContactComponent,
    CategoryListComponent,
    UserOptionsComponent,
    AdminOptionsComponent,
    AddressComponent,
    CouponComponent
    ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
