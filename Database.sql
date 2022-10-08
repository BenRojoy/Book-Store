create database BookStore

use bookstore

create table Category (
CategoryId int primary key identity,
CategoryName varchar(30),
Description varchar(500),
Image varchar(100),
Status bit,
Position int,
CreatedAt smalldatetime
);

create table Book (
BookId int primary key identity(10, 1),
CategoryId int references Category(CategoryId),
Title varchar(100),
Author varchar(50),
ISBN varchar(15),
Year int,
Price decimal(7, 2),
Description varchar(500),
Position int,
Status bit,
Image varchar(100)
);

create table Users(
UserId int primary key identity(100, 1),
Name varchar(40),
Username varchar(30),
Password varchar(30),
Email varchar(30),
Mobile bigint,
AccountStatus bit,
Type varchar(10)
);

create table Address (
AddressId int primary key identity(100, 1),
UserId int references Users(UserId),
HouseNo varchar(20),
Street varchar(50),
City varchar(30),
State varchar(30),
Pincode int
);

create table Wishlist (
WishlistId int primary key identity(1000, 1),
UserId int references Users(UserId),
BookId int references Book(BookId),
Quantity int
);

create table Cart (
CartId int primary key identity(10000, 1),
UserId int references Users(UserId),
BookId int references Book(BookId),
Quantity int
);

create table Orders (
OrderId int not null,
UserId int references Users(UserId),
BookId int references Book(BookId) not null,
Quantity int,
AddressId int references Address(AddressId),
Date smalldatetime not null,
constraint PK_Orders primary key (OrderId, BookId, Date)
);

create table Coupon (
CouponId int primary key identity(10000, 1),
Title varchar(20),
MinCartValue decimal(7, 2),
Discount decimal(7, 2)
);

select * from Category;

select * from book;

select * from admin;

select * from users;

select * from Address;

select * from wishlist;

select * from cart;

select * from orders;

select * from coupon;

