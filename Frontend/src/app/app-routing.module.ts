import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/common/home/home.component'
import { SiteHomeComponent } from './pages/common/site-home/site-home.component'
import { RegisterComponent } from './pages/common/register/register.component'
import { LoginComponent } from './pages/common/login/login.component'
import { CategoryPageComponent } from './pages/common/category-page/category-page.component'
import { BookComponent } from './pages/common/book/book.component'
import { AboutComponent } from './pages/common/about/about.component'
import { ContactComponent } from './pages/common/contact/contact.component'
import { ErrorComponent } from './pages/common/error/error.component'
import { AdminBookComponent } from './pages/admin/admin-book/admin-book.component'
import { AdminCategoryComponent } from './pages/admin/admin-category/admin-category.component'
import { AdminDashComponent } from './pages/admin/admin-dash/admin-dash.component'
import { AdminOrdersComponent } from './pages/admin/admin-orders/admin-orders.component'
import { CouponComponent } from './pages/admin/coupon/coupon.component'
import { UsersComponent } from './pages/admin/users/users.component'
import { CartComponent } from './pages/user/cart/cart.component'
import { UserDashComponent } from './pages/user/user-dash/user-dash.component'
import { UserOrdersComponent } from './pages/user/user-orders/user-orders.component'
import { WishlistComponent } from './pages/user/wishlist/wishlist.component'
import { AddressComponent } from './pages/user/address/address.component'

const routes: Routes = [
  { path: '', redirectTo:'site-home', pathMatch: 'full' },
  { path: 'site-home', component: SiteHomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'category/:id', component: CategoryPageComponent },
  { path: 'book/:id', component: BookComponent },
  { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'admin/book', component: AdminBookComponent },
  { path: 'admin/category', component: AdminCategoryComponent },
  { path: 'admin', component: AdminDashComponent },
  { path: 'admin/orders', component: AdminOrdersComponent },
  { path: 'admin/users', component: UsersComponent },
  { path: 'coupon', component: CouponComponent },
  { path: 'cart', component: CartComponent },
  { path: 'account', component: UserDashComponent },
  { path: 'orders', component: UserOrdersComponent },
  { path: 'wishlist', component: WishlistComponent },
  { path: 'address', component: AddressComponent },
  { path: '**', component: ErrorComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
