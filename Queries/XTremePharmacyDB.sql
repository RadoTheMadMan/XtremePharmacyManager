﻿
/* This is the start of the XTremePharmacyDB. Here will be the whole code for the database */
/* Use the Cyrilic_General_CI_AS collation for cyrilic letters
uncomment this line to execute it if you want cyrilic letters
create database XTremePharmacyDB collate Cyrillic_General_CI_AS;
*/
/* I checked in the internet for many thing here including the create database if not exists.
So it checks if it is null and if it is creates it if it is not uses it*/
if(DB_ID('XTremePharmacyDB') is null)
begin
create database XTremePharmacyDB collate Cyrilic_General_CI_AS;
end
else
begin
use XTremePharmacyDB;
end
/* tables */
/* Users table, the username and password fields have unique constraints so no dublicates allowed */
/* User roles: a is for admin, e is for employee and c is for client */
create table Users(
ID int identity primary key not null,
UserName varchar(50) unique not null,
UserPassword varchar(100) unique not null,
UserDisplayName varchar(100) not null default 'Insert a display name here',
UserBirthDate date not null default getdate(),
UserPhone varchar(100) not null default 'Insert phone here',
UserEmail varchar(100) not null default 'Insert email here',
UserAddress varchar(250) not null default 'Insert address here',
UserProfilePic varbinary(max) not null default 0x2039292,
UserBalance money not null default 0,
UserDiagnose varchar(max) not null default 'Insert diagnose here',
UserDateOfRegister date not null default getdate(),
UserRole int not null default 1
);
/* add a dummy user with no login at id of -1 so no one can use it */
set identity_insert Users on;
insert into Users(ID,UserName,UserPassword) values(-1,'default','123456');
set identity_insert Users off;
select * from Users;
/* Product Brands, a table that defines the brands of the product for easy selection */
create table ProductBrands(
ID int identity primary key not null,
BrandName varchar(200) not null default 'Undefined'
);
/* add a dummy value to the brands table so the products table can work */
set identity_insert ProductBrands on;
insert into ProductBrands(ID, BrandName) values(-1,'Default');
set identity_insert ProductBrands off;
select * from ProductBrands;
/* Products table, this is a very concerning table to make and one mistake can lead to downfall*/
create table Products(
ID int identity primary key not null,
ProductName varchar(100) not null default 'Undefined',
BrandID int foreign key references ProductBrands(ID) on update cascade on delete set default default -1,
ProductDescription varchar(200) not null default 'Add description',
ProductQuantity int not null default 0,
ProductPrice money not null default 0,
ProductExpiryDate date not null default getdate(),
ProductRegNum varchar(max) not null default 'Insert Registration Number',
ProductPartNum varchar(max) not null default 'Insert Partitude Number',
ProductStorageLocation varchar(max) not null default 'Insert Storage Location'
);
/* add a dummy value to the products table */
set identity_insert Products on;
insert into Products(ID) values(-1);
set identity_insert Products off;
select * from Products;
/* Delivery Services table, a table to list delivery services with their price */
create table DeliveryServices(
ID int identity primary key not null,
ServiceName varchar(200) not null default 'Undefined',
ServicePrice money not null default 0
)
/* add a dummy value to the delivery services table */
set identity_insert DeliveryServices on;
insert into DeliveryServices(ID,ServiceName) values(-1,'Default Delivery Service');
set identity_insert DeliveryServices off;
select * from DeliveryServices;
/* Payment Methods table, a table to list payment methods */
create table PaymentMethods(
ID int identity primary key not null,
MethodName varchar(200) not null default 'Undefined'
)
/* add a dummy value to the payment methods table */
set identity_insert PaymentMethods on;
insert into PaymentMethods(ID,MethodName) values(-1, 'Default Payment Method');
set identity_insert PaymentMethods off;
select * from PaymentMethods;
/* Here the complex tables start */
/* Product Images table, references products and has unique image name, a product id reference and an image is stored in binary format */
/* If a product is deleted the image will be set to the undefined product and can get assigned to a product again  or deleted 
by default the image name is *insert image name here* but you can add image name as well but they are unique*/
create table ProductImages(
ID int identity primary key not null,
ProductID int foreign key references Products(ID) on update cascade on delete set default default -1,
ImageName varchar(100) unique not null default 'Insert Image Name',
ImageData varbinary(max) not null default 0x12345
);
/* insert a dummy image at -1 before making anything else */
set identity_insert ProductImages on;
insert into ProductImages(ID,ProductID) values(-1,-1);
set identity_insert ProductImages off;
select * from ProductImages;
/* Product Orders table, idk what to put here, it is better to have an array of product IDs, in the previous project
I have made so that an order has one product per order */
/* decided, one product per order */
/* so let me get this straight, ClientID is for users that have  role of 2, i.e. clients and EmployeeID is for users that have  role of 1, i.e. Employees
if an user with 2 is set as EmployeeID it will be rolled back and so if an user with 1 is set as a ClientID it will be rolled back so yes */
/* by default the order price will be calculated automatically by the desired quantity times the price of the product
DateAdded is when the order is added, DateModified is when the order is modified and the reason is just plain text to explain what the order is for :) */
/* Due to multiple cascade paths errors I will make the triggers check what orders are for which products/employees/clients and set the fields
to their new IDs if the IDs get modified which will be unlikely with the stored procedures I will make */
create table ProductOrders(
ID int identity primary key not null,
ProductID int foreign key references Products(ID) on update cascade on delete set default default -1,
DesiredQuantity int not null default 0,
OrderPrice money not null default 0,
ClientID int foreign key references Users(ID) on update no action on delete no action default -1,
EmployeeID int foreign key references Users(ID) on update no action on delete no action default -1,
DateAdded date not null default getdate(),
DateModified date not null default getdate(),
OrderStatus int not null default 0,
OrderReason varchar(max) not null default 'Type here the reason the order was added/modified'
);
/* now insert a dummy order value that has nothing and is just a template */
set identity_insert ProductOrders on;
insert into ProductOrders(ID) values(-1);
set identity_insert ProductOrders off;
select * from ProductOrders;
/* Deliveries table, it has reference to the orders, delivery services and payment methods and the total price is
automatically calculated */
create table OrderDeliveries(
ID int identity primary key not null,
OrderID int foreign key references ProductOrders(ID) on update cascade on delete set default default -1,
DeliveryServiceID int foreign key references DeliveryServices(ID) on update cascade on delete set default default -1,
PaymentMethodID int foreign key references PaymentMethods(ID) on update cascade on delete set default default -1,
TotalPrice money not null default 0,
DateAdded date not null default getdate(),
DateModified date not null default getdate(),
DeliveryStatus int not null default 0,
DeliveryReason varchar(max) not null default 'Type here the reason the delivery was added/modified'
)
/* now by tradition add a dummy order delivery at -1 so it can be default and not used by anything */
set identity_insert OrderDeliveries on;
insert into OrderDeliveries(ID) values(-1);
set identity_insert OrderDeliveries off;
select * from OrderDeliveries;
/* the Logs table, there will be all the logs stored with log date, log title, log message
and additional information */
create table Logs(
ID int identity primary key not null,
LogDate date not null default getdate(),
LogTitle varchar(50) not null default 'Log Title',
LogMessage varchar(max) not null default 'Log Message',
AdditionalLogInformation varchar(max) not null default 'Additional Log Information'
);
/* now insert dummy value to the logs as a tradition */
set identity_insert Logs on;
insert into Logs(ID) values(-1);
set identity_insert Logs off;
select * from Logs;
/* end of tables */
/* stored procedures */
/* so there aren't thousands of stored procedures each table will have 4 or 5 stored procedures related to it */
/* Add User stored procedure, it will be for securely adding users to the users table */
go
create or alter procedure AddUser(
@username varchar(50), 
@password varchar(100),
@displayname varchar(100),
@birthdate date, 
@phone varchar(100), 
@email varchar(100), 
@address varchar(250), 
@profilepic varbinary(max),
@balance money,
@diagnose varchar(max),
@role int
)
as
begin
/* If role isn't admin, employee or client, i.e. different char than 0 for admin, 1 for employee and 2 for client then
the user will be an employee */
if @role != 0 and @role != 1 and @role != 2
begin
select 'Invalid value for user role. Accepted values are 0 for admin, 1 for employee and 2 for client. Added user will be employee';
set @role = 1;
end
insert into Users(UserName,UserPassword,UserDisplayName,UserBirthDate,UserPhone,UserEmail,UserAddress,UserProfilePic,UserBalance,UserDiagnose,UserRole)
values(@username,@password,@displayname,@birthdate,@phone,@email,@address,@profilepic,@balance,@diagnose,@role);
end
go
/* Get User stored procedure, if blank parameters are put it is supposed to return everything, if specific parameters
are provided it will return by the parameter criterias  and if not all criterias are valid all users will be returned instead*/
go
create or alter procedure GetUser(
@id int, 
@username varchar(50),
@password varchar(100),
@displayname varchar(100),
@birthdatefrom date,
@birthdateto date,
@phone varchar(100),
@email varchar(100),
@address varchar(250),
@balance money,
@diagnose varchar(max),
@registerdatefrom date,
@registerdateto date,
@role int)
as
begin
if @id >= 0 and @username != '' and @password != '' and @birthdatefrom != '' and @birthdateto != '' and @phone != '' and @email != ''
and @address != '' and @balance >= 0 and @diagnose != '' and @registerdatefrom != '' and @registerdateto != '' and @role >= 0
begin
select * from Users where ID = ID and UserName like '%'+@username+'%' and UserPassword like '%'+@password+'%' and UserDisplayName like '%'+@displayname+'%'
and UserBirthDate between @birthdatefrom and @birthdateto and UserPhone like '%'+@phone+'%' and UserEmail like '%'+@email+'%' and UserAddress like '%'+@address+'%' 
and (UserBalance >= @balance or UserBalance <= @balance) and UserDiagnose like '%'+@diagnose+'%' 
and UserDateOfRegister between @registerdatefrom and @registerdateto and UserRole = @role;
end
else
begin
select * from Users;
end
end
go
/* Update User by ID procedure, updates safely an user by ID and validates if the ID is not a dummy value */
/* by default IDs and register dates aren't to be edited via the stored procedures and this is for security reasons */
/* also if the ID is dummy entry it won't be edited and if the parameters are null, blank or invalid the old parameters will be preserved */
go
create or alter procedure UpdateUserByID(
@id int, 
@new_user_name varchar(50),
@new_password varchar(100),
@new_display_name varchar(100),
@new_birth_date date,
@new_phone varchar(100),
@new_email varchar(100),
@new_address varchar(250),
@new_profile_pic varbinary(max),
@new_balance money,
@new_diagnose varchar(max),
@new_role int
)
as
begin
/* first check get old entry values and check if the ID is the dummy, if it is the dummy value do nothing */
/* select the current values from the table entry if it is found */
declare @old_username as varchar(50);
select @old_username = UserName from Users where ID = @id;
declare @old_password as varchar(100);
select @old_password = UserPassword from Users where ID = @id;
declare @old_display_name as varchar(100);
select @old_display_name = UserDisplayName from Users where ID = @id;
declare @old_birth_date as date;
select @old_birth_date = UserBirthDate from Users where ID = @id;
declare @old_phone as varchar(100);
select @old_phone = UserPhone from Users where ID = @id;
declare @old_email as varchar(100);
select @old_email = UserEmail from Users where ID = @id;
declare @old_address as varchar(250);
select @old_address = UserAddress from Users where ID = @id;
declare @old_profile_pic as varbinary(max);
select @old_profile_pic = UserProfilePic from Users where ID = @id;
declare @old_balance as money;
select @old_balance = UserBalance from Users where ID = @id;
declare @old_diagnose as varchar(max);
select @old_diagnose = UserDiagnose from Users where ID = @id;
declare @old_role as int;
select @old_role = UserRole from Users where ID = @id;
if @id < 0
begin
select 'Dummy entries shall not be edited!';
end
else
begin
if @new_user_name is null or @new_user_name = ''
begin
set @new_user_name = @old_username;
end
if @new_password is null or @new_password = ''
begin
set @new_password = @old_password;
end
if @new_display_name is null or @new_display_name = ''
begin
set @new_display_name = @old_display_name;
end
if @new_birth_date is null or @new_birth_date = ''
begin
set @new_birth_date = @old_birth_date;
end
if @new_phone is null or @new_phone = ''
begin
set @new_phone = @old_phone;
end
if @new_email is null or @new_email = ''
begin
set @new_email = @old_email;
end
if @new_address is null or @new_address = ''
begin
set @new_address = @old_address;
end
if @new_profile_pic is null
begin
set @new_profile_pic = @old_profile_pic;
end
if @new_balance is null or @new_balance <= 0
begin
set @new_balance = @old_balance;
end
if @new_diagnose is null or @new_diagnose = ''
begin
set @new_diagnose = @old_diagnose;
end
if @new_role is null or @new_role not between 0 and 2
begin
set @new_role = @old_role;
end
update Users set UserName = @new_user_name, UserPassword = @new_password,UserDisplayName = @new_display_name, UserBirthDate = @new_birth_date, UserPhone = @new_phone, 
UserEmail = @new_email, UserAddress = @new_address, UserProfilePic = @new_profile_pic, UserBalance = @new_balance, UserDiagnose = @new_diagnose,
UserRole = @new_role where ID = @id;
end
end
go
/* Delete User procedure, it will have almost the same manner as the Get User procedure but will delete stuff,
if all the values are invalid then it will delete everything, if all the values are valid it will delete anything
that is coresponding to these parameters */
go
create or alter procedure DeleteUser(
@id int, 
@username varchar(50),
@password varchar(100),
@displayname varchar(100),
@birthdatefrom date,
@birthdateto date,
@phone varchar(100),
@email varchar(100),
@address varchar(250),
@balance money,
@diagnose varchar(max),
@registerdatefrom date,
@registerdateto date,
@role int)
as
begin
if @id >= 0 and @username != '' and @password != '' and @displayname != '' and @birthdatefrom != '' and @birthdateto != '' and @phone != '' and @email != ''
and @address != '' and @balance >= 0 and @diagnose != '' and @registerdatefrom != '' and @registerdateto != '' and @role >= 0
begin
delete from Users where ID = ID and UserName like '%'+@username+'%' and UserPassword like '%'+@password+'%' and UserDisplayName like '%'+@displayname+'%'  and UserBirthDate between @birthdatefrom and @birthdateto
and UserPhone like '%'+@phone+'%' and UserEmail like '%'+@email+'%' and UserAddress like '%'+@address+'%' and (UserBalance >= @balance or UserBalance <= @balance) and 
UserDiagnose like '%'+@diagnose+'%' and UserDateOfRegister between @registerdatefrom and @registerdateto and UserRole = @role;
end
else
begin
delete from Users;
end
end
go
go
/* Delete User by ID, only for deleting by ID, will be mapped using Entity Model, if you want to delete specific user or all users 
use DeleteUser*/
create or alter procedure DeleteUserByID(
@id int
)
as
begin
if @id >= 0
begin
delete from Users where ID=@id;
end
else
begin
select 'Dummy entries shall not be deleted!';
end
end
go

/* Add Brand stored procedure, it will be for securely adding brands to the brands table */
go
create or alter procedure AddBrand(
@brandname varchar(200)
)
as
begin
insert into ProductBrands(BrandName)
values(@brandname);
end
go
/* Get Brand stored procedure, if blank parameters are put it is supposed to return everything, if specific parameters
are provided it will return by the parameter criterias  and if not all criterias are valid all brands will be returned instead*/
go
create or alter procedure GetBrand(
@id int, 
@brandname varchar(200)
)
as
begin
if @id >= 0 and @brandname != '' 
begin
select * from ProductBrands where ID = ID and BrandName like '%'+@brandname+'%';
end
else
begin
select * from ProductBrands;
end
end
go
/* Update Brand by ID procedure, updates safely an user by ID and validates if the ID is not a dummy value */
/* by default IDs aren't to be edited via the stored procedures and this is for security reasons */
/* also if the ID is dummy entry it won't be edited and if the parameters are null, blank or invalid the old parameters will be preserved */
go
create or alter procedure UpdateBrandByID(
@id int, 
@new_brand_name varchar(200)
)
as
begin
/* first check get old entry values and check if the ID is the dummy, if it is the dummy value do nothing */
/* select the current values from the table entry if it is found */
declare @old_brand_name as varchar(200);
select @old_brand_name = BrandName from ProductBrands where ID = @id;
if @id < 0
begin
select 'Dummy entries shall not be edited!';
end
else
begin
if @new_brand_name is null or @new_brand_name = ''
begin
set @new_brand_name = @old_brand_name;
end
update ProductBrands set BrandName = @new_brand_name where ID = @id;
end
end
go
/* Delete Brand procedure, it will have almost the same manner as the Get User procedure but will delete stuff,
if all the values are invalid then it will delete everything, if all the values are valid it will delete anything
that is coresponding to these parameters */
go
create or alter procedure DeleteBrand(
@id int, 
@brandname varchar(200)
)
as
begin
if @id >= 0 and @brandname != '' 
begin
delete from ProductBrands where ID = ID and BrandName like '%'+@brandname+'%';
end
else
begin
delete from ProductBrands;
end
end
go
go
/* Delete Brand by ID, only for deleting by ID, will be mapped using Entity Model, if you want to delete specific brand or all brands 
use DeleteBrand*/
create or alter procedure DeleteBrandByID(
@id int
)
as
begin
if @id >= 0
begin
delete from ProductBrands where ID=@id;
end
else
begin
select 'Dummy entries shall not be deleted!';
end
end
go

/* Add Payment Method stored procedure, it will be for securely adding payment methods to the payment methods table */
go
create or alter procedure AddPaymentMethod(
@methodname varchar(200)
)
as
begin
insert into PaymentMethods(MethodName)
values(@methodname);
end
go
/* Get Payment Method stored procedure, if blank parameters are put it is supposed to return everything, if specific parameters
are provided it will return by the parameter criterias  and if not all criterias are valid all methods will be returned instead*/
go
create or alter procedure GetPaymentMethod(
@id int, 
@methodname varchar(200)
)
as
begin
if @id >= 0 and @methodname != '' 
begin
select * from PaymentMethods where ID = ID and MethodName like '%'+@methodname+'%';
end
else
begin
select * from PaymentMethods;
end
end
go
/* Update Payment Method by ID procedure, updates safely an user by ID and validates if the ID is not a dummy value */
/* by default IDs aren't to be edited via the stored procedures and this is for security reasons */
/* also if the ID is dummy entry it won't be edited and if the parameters are null, blank or invalid the old parameters will be preserved */
go
create or alter procedure UpdatePaymentMethodByID(
@id int, 
@new_method_name varchar(200)
)
as
begin
/* first check get old entry values and check if the ID is the dummy, if it is the dummy value do nothing */
/* select the current values from the table entry if it is found */
declare @old_method_name as varchar(200);
select @old_method_name = MethodName from PaymentMethods where ID = @id;
if @id < 0
begin
select 'Dummy entries shall not be edited!';
end
else
begin
if @new_method_name is null or @new_method_name = ''
begin
set @new_method_name = @old_method_name;
end
update PaymentMethods set MethodName = @new_method_name where ID = @id;
end
end
go
/* Delete Payment Method procedure, it will have almost the same manner as the Get Payment Method procedure but will delete stuff,
if all the values are invalid then it will delete everything, if all the values are valid it will delete anything
that is coresponding to these parameters */
go
create or alter procedure DeletePaymentMethod(
@id int, 
@methodname varchar(200)
)
as
begin
if @id >= 0 and @methodname != '' 
begin
delete from PaymentMethods where ID = ID and MethodName like '%'+@methodname+'%';
end
else
begin
delete from PaymentMethods;
end
end
go
go
/* Delete Payment Method by ID, only for deleting by ID, will be mapped using Entity Model, if you want to delete specific method or all methods 
use DeletePaymentMethod*/
create or alter procedure DeletePaymentMethodByID(
@id int
)
as
begin
if @id >= 0
begin
delete from PaymentMethods where ID=@id;
end
else
begin
select 'Dummy entries shall not be deleted!';
end
end
go

/* Add Delivery Service stored procedure, it will be for securely adding delivery services to the delivery services table */
go
create or alter procedure AddDeliveryService(
@servicename varchar(200),
@price money
)
as
begin
insert into DeliveryServices(ServiceName, ServicePrice)
values(@servicename,@price);
end
go
/* Get Delivery Service stored procedure, if blank parameters are put it is supposed to return everything, if specific parameters
are provided it will return by the parameter criterias  and if not all criterias are valid all services will be returned instead*/
go
create or alter procedure GetDeliveryService(
@id int, 
@servicename varchar(200),
@serviceprice money
)
as
begin
if @id >= 0 and @servicename != '' and @serviceprice >= 0 
begin
select * from DeliveryServices where ID = ID and ServiceName like '%'+@servicename+'%' and (ServicePrice >= @serviceprice or ServicePrice <= @serviceprice);
end
else
begin
select * from DeliveryServices;
end
end
go
/* Update Delivery Service by ID procedure, updates safely an user by ID and validates if the ID is not a dummy value */
/* by default IDs aren't to be edited via the stored procedures and this is for security reasons */
/* also if the ID is dummy entry it won't be edited and if the parameters are null, blank or invalid the old parameters will be preserved */
go
create or alter procedure UpdateDeliveryServiceByID(
@id int, 
@new_service_name varchar(200),
@new_service_price money
)
as
begin
/* first check get old entry values and check if the ID is the dummy, if it is the dummy value do nothing */
/* select the current values from the table entry if it is found */
declare @old_service_name as varchar(200);
select @old_service_name = ServiceName from DeliveryServices where ID = @id;
declare @old_service_price as money;
select @old_service_price = ServicePrice from DeliveryServices where ID=@id;
if @id < 0
begin
select 'Dummy entries shall not be edited!';
end
else
begin
if @new_service_name is null or @new_service_name = ''
begin
set @new_service_name = @old_service_name;
end
if @new_service_price is null or @new_service_price < 0
begin
set @new_service_price = @old_service_price;
end
update DeliveryServices set ServiceName = @new_service_name, ServicePrice = @new_service_price where ID = @id;
end
end
go
/* Delete Delivery Service procedure, it will have almost the same manner as the Get Delivery Service procedure but will delete stuff,
if all the values are invalid then it will delete everything, if all the values are valid it will delete anything
that is coresponding to these parameters */
go
create or alter procedure DeleteDeliveryService(
@id int, 
@servicename varchar(200),
@serviceprice money
)
as
begin
if @id >= 0 and @servicename != '' and @serviceprice >= 0
begin
delete from DeliveryServices where ID = ID and ServiceName like '%'+@servicename+'%' and (ServicePrice>=@serviceprice or ServicePrice <= @serviceprice) ;
end
else
begin
delete from DeliveryServices;
end
end
go
go
/* Delete Delivery Service by ID, only for deleting by ID, will be mapped using Entity Model, if you want to delete specific service or all services 
use DeleteDeliveryService*/
create or alter procedure DeleteDeliveryServiceByID(
@id int
)
as
begin
if @id >= 0
begin
delete from DeliveryServices where ID=@id;
end
else
begin
select 'Dummy entries shall not be deleted!';
end
end
go

/* Add Product stored procedure, it will be for securely adding products to the products table */
go
create or alter procedure AddProduct(
@productname varchar(100),
@brandid int,
@description varchar(200),
@quantity int,
@price money,
@expirydate date,
@regnum varchar(max),
@partnum varchar(max),
@storagelocation varchar(max)
)
as
begin
insert into Products(ProductName,BrandID,ProductDescription,ProductQuantity,ProductPrice,ProductExpiryDate,ProductRegNum,ProductPartNum,ProductStorageLocation)
values(@productname,@brandid,@description,@quantity,@price,@expirydate,@regnum,@partnum,@storagelocation);
end
go
/* Get Product stored procedure, if blank parameters are put it is supposed to return everything, if specific parameters
are provided it will return by the parameter criterias  and if not all criterias are valid all products will be returned instead*/
go
create or alter procedure GetProduct(
@id int,
@productname varchar(100),
@brandid int,
@description varchar(200),
@quantity int,
@price money,
@expirydatefrom date,
@expirydateto date,
@regnum varchar(max),
@partnum varchar(max),
@storagelocation varchar(max)
)
as
begin
if @id >= 0 and @productname != '' and @brandid >= 0 and @description != '' 
and @quantity >= 0 and @price >= 0 and @expirydatefrom != '' and @expirydateto != '' and @regnum != ''
and @partnum != '' and @storagelocation != ''
begin
select * from Products where ID = ID and ProductName like '%'+@productname+'%' and BrandID = @brandid  and ProductDescription like '%' + @description + '%'
and (ProductQuantity >= @quantity or ProductQuantity <= @quantity) and (ProductPrice >= @price or ProductPrice <= @price) 
and ProductExpiryDate between @expirydatefrom and @expirydateto and ProductRegNum like '%' + @regnum + '%' and ProductPartNum like '%' + @partnum + '%'
and ProductStorageLocation like '%' + @storagelocation + '%';
end
else
begin
select * from Products;
end
end
go
/* Update Product by ID procedure, updates safely an user by ID and validates if the ID is not a dummy value */
/* by default IDs aren't to be edited via the stored procedures and this is for security reasons */
/* also if the ID is dummy entry it won't be edited and if the parameters are null, blank or invalid the old parameters will be preserved */
go
create or alter procedure UpdateProductByID(
@id int,
@new_product_name varchar(100),
@new_brand_id int,
@new_description varchar(200),
@new_quantity int,
@new_price money,
@new_expiry_date date,
@new_reg_num varchar(max),
@new_part_num varchar(max),
@new_storage_location varchar(max)
)
as
begin
/* first check get old entry values and check if the ID is the dummy, if it is the dummy value do nothing */
/* select the current values from the table entry if it is found */
declare @old_product_name varchar(100);
select @old_product_name = ProductName from Products where ID = @id;
declare @old_brand_id int;
select @old_brand_id = BrandID from Products where ID = @id;
declare @old_description varchar(200);
select @old_description = ProductDescription from Products where ID = @id;
declare @old_quantity int;
select @old_quantity = ProductQuantity from Products where ID = @id;
declare @old_price money;
select @old_price = ProductPrice from Products where ID = @id;
declare @old_expiry_date date;
select @old_expiry_date = ProductExpiryDate from Products where ID = @id;
declare @old_reg_num varchar(max);
select @old_reg_num = ProductRegNum from Products where ID = @id;
declare @old_part_num varchar(max);
select @old_part_num = ProductPartNum from Products where ID = @id;
declare @old_storage_location varchar(max);
select @old_storage_location = ProductStorageLocation from Products where ID = @id;
if @id < 0
begin
select 'Dummy entries shall not be edited!';
end
else
begin
if @new_product_name is null or @new_product_name = ''
begin
set @new_product_name = @old_product_name;
end
if @new_brand_id is null
begin
set @new_brand_id = @old_brand_id;
end
if @new_description is null or @new_description = ''
begin
set @new_description = @old_description;
end
if @new_quantity is null or @new_quantity < 0
begin
set @new_quantity = @old_quantity;
end
if @new_price is null or @new_price < 0
begin
set @new_price = @old_price;
end
if @new_expiry_date is null or @new_expiry_date = ''
begin
set @new_expiry_date = @old_expiry_date;
end
if @new_reg_num is null or @new_reg_num = ''
begin
set @new_reg_num = @old_reg_num;
end
if @new_part_num is null or @new_part_num = ''
begin
set @new_part_num = @old_part_num;
end
if @new_storage_location is null or @new_storage_location = ''
begin
set @new_storage_location = @old_storage_location;
end
update Products set ProductName = @new_product_name, BrandID = @new_brand_id, ProductDescription = @new_description, ProductQuantity = @new_quantity,
ProductPrice = @new_price, ProductExpiryDate = @new_expiry_date, ProductRegNum = @new_reg_num, ProductPartNum = @new_part_num, ProductStorageLocation = @new_storage_location
where ID = @id;
end
end
go
/* Delete Product procedure, it will have almost the same manner as the Get Product procedure but will delete stuff,
if all the values are invalid then it will delete everything, if all the values are valid it will delete anything
that is coresponding to these parameters */
go
create or alter procedure DeleteProduct(
@id int,
@productname varchar(100),
@brandid int,
@description varchar(200),
@quantity int,
@price money,
@expirydatefrom date,
@expirydateto date,
@regnum varchar(max),
@partnum varchar(max),
@storagelocation varchar(max)
)
as
begin
if @id >= 0 and @productname != '' and @brandid >= 0 and @description != '' 
and @quantity >= 0 and @price >= 0 and @expirydatefrom != '' and @expirydateto != '' and @regnum != ''
and @partnum != '' and @storagelocation != ''
begin
delete from Products where ID = ID and ProductName like '%'+@productname+'%' and BrandID = @brandid  and ProductDescription like '%' + @description + '%'
and (ProductQuantity >= @quantity or ProductQuantity <= @quantity) and (ProductPrice >= @price or ProductPrice <= @price) 
and ProductExpiryDate between @expirydatefrom and @expirydateto and ProductRegNum like '%' + @regnum + '%' and ProductPartNum like '%' + @partnum + '%'
and ProductStorageLocation like '%' + @storagelocation + '%';
end
else
begin
delete from Products;
end
end
go
go
/* Delete Product by ID, only for deleting by ID, will be mapped using Entity Model, if you want to delete specific product or all products 
use DeleteProduct*/
create or alter procedure DeleteProductByID(
@id int
)
as
begin
if @id >= 0
begin
delete from Products where ID=@id;
end
else
begin
select 'Dummy entries shall not be deleted!';
end
end
go

/* Add Product Image stored procedure, it will be for securely adding product images to the product images table */
go
create or alter procedure AddProductImage(
@productid int,
@imagename varchar(100),
@imagedata varbinary(max)
)
as
begin
insert into ProductImages(ProductID,ImageName,ImageData) values(@productid,@imagename,@imagedata);
end
go
/* Get Product Image stored procedure, if blank parameters are put it is supposed to return everything, if specific parameters
are provided it will return by the parameter criterias  and if not all criterias are valid all product images will be returned instead*/
go
create or alter procedure GetProductImage(
@id int,
@productid int,
@imagename varchar(100)
)
as
begin
if @id >= 0 and @productid >= 0 and @imagename != ''
begin
select * from ProductImages where ID = ID and ProductID = @productid and ImageName like '%'+@imagename+'%' ;
end
else
begin
select * from ProductImages;
end
end
go
/* Update Product Image by ID procedure, updates safely an user by ID and validates if the ID is not a dummy value */
/* by default IDs aren't to be edited via the stored procedures and this is for security reasons */
/* also if the ID is dummy entry it won't be edited and if the parameters are null, blank or invalid the old parameters will be preserved */
go
create or alter procedure UpdateProductImageByID(
@id int,
@new_product_id int,
@new_image_name varchar(100),
@new_image_data varbinary(max)
)
as
begin
/* first check get old entry values and check if the ID is the dummy, if it is the dummy value do nothing */
/* select the current values from the table entry if it is found */
declare @old_product_id int;
select @old_product_id = ProductID from ProductImages where ID = @id;
declare @old_image_name varchar(100);
select @old_image_name = ImageName from ProductImages where ID = @id;
declare @old_image_data varbinary(max);
select @old_image_data = ImageData from productImages where ID = @id;
if @id < 0
begin
select 'Dummy entries shall not be edited!';
end
else
begin
if @new_product_id is null
begin
set @new_product_id = @old_product_id;
end
if @new_image_name is null or @new_image_name = ''
begin
set @new_image_name = @old_image_name;
end
if @new_image_data is null
begin
set @new_image_data = @old_image_data;
end
update ProductImages set ProductID = @new_product_id, ImageName = @new_image_name, ImageData = @new_image_data where ID = @id;
end
end
go
/* Delete Product Image procedure, it will have almost the same manner as the Get Product Image procedure but will delete stuff,
if all the values are invalid then it will delete everything, if all the values are valid it will delete anything
that is coresponding to these parameters */
go
create or alter procedure DeleteProductImage(
@id int,
@productid int,
@imagename varchar(100)
)
as
begin
if @id >= 0 and @productid >= 0 and @imagename != ''
begin
delete from ProductImages where ID = ID and ProductID = @productid and ImageName like '%'+@imagename+'%' ;
end
else
begin
delete from ProductImages;
end
end
go
go
/* Delete Product Image by ID, only for deleting by ID, will be mapped using Entity Model, if you want to delete specific product image or all 
product images use DeleteProductImage*/
create or alter procedure DeleteProductImageByID(
@id int
)
as
begin
if @id >= 0
begin
delete from ProductImages where ID=@id;
end
else
begin
select 'Dummy entries shall not be deleted!';
end
end
go

/* Add Product Order stored procedure, it will be for securely adding product orders to the product orders table */
go
create or alter procedure AddProductOrder(
@productid int,
@desiredquantity int,
@priceoverride money,
@clientid int,
@employeeid int,
@orderreason varchar(max),
@overridepriceastotal bit
)
as
begin
/* before we insert though we have to make several checks on the price override, there are 3 cases:
1. Price override is for product, if the price override for a product is less than the actual product price then the product price
is accepted, otherwise the price override is accepted
2. Price override is total price, if the price override is lower than the total price which is product price times the desired quantity
then the total price is accepted, otherwise the total price override is accepted
3. If the price override is 0 or below then the price is calculated by the product price and desired quantity of the product
This is for that if someone wants to override the price of the product when selling they can do it but only if the price override is higher
than the product price or the total price of the order
*/
declare @finalprice as money; /* the final calculated price */
declare @productprice as money; /* the current product price */
declare @currenttotalprice as money; /* the current total price, calculated at runtime */
select @productprice = ProductPrice from Products where ID = @productid;
select @currenttotalprice = @productprice * @desiredquantity;
/* Case 1: price override is bigger then 0 and product price is overriden */
if @priceoverride > 0 and @overridepriceastotal = 0
begin
/* overriden price is equal or bigger than the product price then it is accepted */
if @priceoverride >= @productprice
begin
set @finalprice = @priceoverride * @desiredquantity;
end
else
/* otherwise the final price is calculated by the current product price and the quantity of the order */
begin
set @finalprice = @currenttotalprice;
end
end
else if @priceoverride > 0 and @overridepriceastotal = 1
begin
if @priceoverride >= @currenttotalprice
/* overriden price is bigger or equal than the current total price then it is accepted */
begin
set @finalprice = @priceoverride;
end
else
/* otherwise the current total price is set as final */
begin
set @finalprice = @currenttotalprice;
end
end
else
/* if not any of these cases are met then the current total price is set and period. */
begin
set @finalprice = @currenttotalprice;
end
insert into ProductOrders(ProductID,DesiredQuantity, OrderPrice, ClientID, EmployeeID,DateAdded,DateModified,OrderReason)
values(@productid,@desiredquantity,@finalprice,@clientid,@employeeid,getdate(),getdate(), @orderreason);
end
go
/* Get Product Order stored procedure, if blank parameters are put it is supposed to return everything, if specific parameters
are provided it will return by the parameter criterias  and if not all criterias are valid all product orders will be returned instead*/
go
create or alter procedure GetProductOrder(
@id int,
@productid int,
@quantity int,
@price money,
@clientid int,
@employeeid int,
@dateaddedfrom date,
@dateaddedto date,
@datemodifiedfrom date,
@datemodifiedto date,
@status int,
@reason varchar(max)
)
as
begin
if @id >= 0 and @productid >= 0 and @quantity >= 0 and @price >= 0 and @clientid >= 0 and @employeeid >= 0 and 
@dateaddedfrom != '' and @dateaddedto != '' and @datemodifiedfrom != '' and @datemodifiedto != '' and @status >= 0 and @reason != ''
begin
select * from ProductOrders where ID = @id and ProductID = @productid and (DesiredQuantity >= @quantity or DesiredQuantity <= @quantity) and 
(OrderPrice >= @price or OrderPrice <= @price) and ClientID = @clientid and EmployeeID = @employeeid and DateAdded between @dateaddedfrom and @dateaddedto
and DateModified between @datemodifiedfrom and @datemodifiedto and OrderStatus = @status and OrderReason like '%'+@reason+'%' ;
end
else
begin
select * from ProductOrders;
end
end
go
/* Update Product Order by ID procedure, updates safely an user by ID and validates if the ID is not a dummy value */
/* by default IDs, Dates Added and Dates Modified aren't to be edited via the stored procedures and this is for security reasons */
/* also if the ID is dummy entry it won't be edited and if the parameters are null, blank or invalid the old parameters will be preserved */
/* Here also the override check, if the price override is over the product price or the total price calculated by the new desired quantity
then it is accepted, otherwise nope */
go
create or alter procedure UpdateProductOrderByID(
@id int,
@new_product_id int,
@new_desired_quantity int,
@new_price_override money,
@new_client_id int,
@new_employee_id int,
@new_status int,
@new_reason varchar(max)
)
as
begin
/* first check get old entry values and check if the ID is the dummy, if it is the dummy value do nothing */
/* select the current values from the table entry if it is found */
declare @old_product_id int;
select @old_product_id = ProductID from ProductOrders where ID = @id;
declare @old_desired_quantity int;
select @old_desired_quantity = DesiredQuantity from ProductOrders where ID = @id;
declare @old_price as money;
select @old_price = OrderPrice from ProductOrders where ID = @id;
declare @old_client_id as int;
select @old_client_id = ClientID from ProductOrders where ID = @id;
declare @old_employee_id as int;
select @old_employee_id = EmployeeID from ProductOrders where ID = @id;
declare @old_status as int;
select @old_status = OrderStatus from ProductOrders where ID = @id;
declare @old_reason as varchar(max);
select @old_reason = OrderReason from ProductOrders where ID = @id;
declare @final_price as money;
set @final_price = 0;
if @id < 0
begin
select 'Dummy entries shall not be edited!';
end
else
begin
/* first is the validation */
if @new_product_id is null
begin
set @new_product_id = @old_product_id;
end
if @new_desired_quantity is null or @new_desired_quantity < 0
begin
set @new_desired_quantity = @old_desired_quantity;
end
if @new_price_override is null or @new_price_override < 0
begin
set @new_price_override = @old_price;
end
if @new_client_id is null
begin
set @new_client_id = @old_client_id;
end
if @new_employee_id is null
begin
set @new_employee_id = @old_employee_id;
end
if @new_status is null or @new_status < 0
begin
set @new_status = @old_status;
end
if @new_reason is null or @new_reason = ''
begin
set @new_reason = @old_reason;
end
/* Now for determining the final price */
declare @new_order_price as money;
declare @new_overidden_order_price as money;
declare @new_product_price as money;
select @new_product_price = ProductPrice from Products where ID = @new_product_id;
set @new_order_price = @new_product_price * @new_desired_quantity;
set @new_overidden_order_price = @new_price_override * @new_desired_quantity;
/* after calculating the new total price without the price override and the total price with the override we can determine the final price */
if @new_price_override >= @new_product_price and @new_overidden_order_price < @new_order_price and @new_price_override < @new_order_price
begin
set @final_price = @new_order_price;
end
else if @new_price_override >= @new_product_price and @new_overidden_order_price >= @new_order_price and @new_price_override < @new_order_price
begin
set @final_price = @new_overidden_order_price;
end
else if @new_price_override > @new_order_price
begin
set @final_price = @new_price_override;
end
else
begin
set @final_price = @new_order_price;
end
/* and then update */
update ProductOrders set ProductID = @new_product_id, DesiredQuantity = @new_desired_quantity, OrderPrice = @final_price, ClientID = @new_client_id,
EmployeeID = @new_employee_id, DateModified = getdate(), OrderStatus = @new_status, OrderReason = @new_reason where ID = @id;
end
end
go
/* Delete Product Order procedure, it will have almost the same manner as the Get Product Order procedure but will delete stuff,
if all the values are invalid then it will delete everything, if all the values are valid it will delete anything
that is coresponding to these parameters */
go
create or alter procedure DeleteProductOrder(
@id int,
@productid int,
@quantity int,
@price money,
@clientid int,
@employeeid int,
@dateaddedfrom date,
@dateaddedto date,
@datemodifiedfrom date,
@datemodifiedto date,
@status int,
@reason varchar(max)
)
as
begin
if @id >= 0 and @productid >= 0 and @quantity >= 0 and @price >= 0 and @clientid >= 0 and @employeeid >= 0 and 
@dateaddedfrom != '' and @dateaddedto != '' and @datemodifiedfrom != '' and @datemodifiedto != '' and @status >= 0 and @reason != ''
begin
delete from ProductOrders where ID = @id and ProductID = @productid and (DesiredQuantity >= @quantity or DesiredQuantity <= @quantity) and 
(OrderPrice >= @price or OrderPrice <= @price) and ClientID = @clientid and EmployeeID = @employeeid and DateAdded between @dateaddedfrom and @dateaddedto
and DateModified between @datemodifiedfrom and @datemodifiedto and OrderStatus = @status and OrderReason like '%'+@reason+'%' ;
end
else
begin
delete from ProductOrders;
end
end
go
go
/* Delete Product Order by ID, only for deleting by ID, will be mapped using Entity Model, if you want to delete specific product order or all 
product orders use DeleteProductOrder*/
create or alter procedure DeleteProductOrderByID(
@id int
)
as
begin
if @id >= 0
begin
delete from ProductOrders where ID=@id;
end
else
begin
select 'Dummy entries shall not be deleted!';
end
end
go

/* Add Order Delivery stored procedure, it will be for securely adding order deliveries to the order deliveries table */
go
create or alter procedure AddOrderDelivery(
@orderid int,
@serviceid int,
@methodid int,
@deliveryreason varchar(max)
)
as
begin
declare @orderprice as money;
select @orderprice = OrderPrice from ProductOrders where ID = @orderid;
declare @serviceprice as money;
select @serviceprice = ServicePrice from DeliveryServices where ID = @serviceid;
/* total price for order deliveries is calculated automatically */
declare @finalprice as money; /* the final calculated price */
set @finalprice = @orderprice + @serviceprice;
insert into OrderDeliveries(OrderID,DeliveryServiceID, PaymentMethodID,TotalPrice,DateAdded,DateModified,DeliveryReason)
values(@orderid,@serviceid,@methodid,@finalprice,getdate(),getdate(), @deliveryreason);
end
go
/* Get Order Delivery stored procedure, if blank parameters are put it is supposed to return everything, if specific parameters
are provided it will return by the parameter criterias  and if not all criterias are valid all order deliveries will be returned instead*/
go
create or alter procedure GetOrderDelivery(
@id int,
@orderid int,
@serviceid int,
@methodid int,
@price money,
@dateaddedfrom date,
@dateaddedto date,
@datemodifiedfrom date,
@datemodifiedto date,
@status int,
@reason varchar(max)
)
as
begin
if @id >= 0 and @orderid >= 0 and @serviceid >= 0 and @methodid >= 0 and @price >= 0 and 
@dateaddedfrom != '' and @dateaddedto != '' and @datemodifiedfrom != '' and @datemodifiedto != '' and @status >= 0 and @reason != ''
begin
select * from OrderDeliveries where ID = @id and OrderID = @orderid and DeliveryServiceID = @serviceid and PaymentMethodID = @methodid and
(TotalPrice >= @price or TotalPrice <= @price) and DateAdded between @dateaddedfrom and @dateaddedto
and DateModified between @datemodifiedfrom and @datemodifiedto and DeliveryStatus = @status and DeliveryReason like '%'+@reason+'%' ;
end
else
begin
select * from OrderDeliveries;
end
end
go
/* Update Order Delivery by ID procedure, updates safely an user by ID and validates if the ID is not a dummy value */
/* by default IDs, Dates Added and Dates Modified aren't to be edited via the stored procedures and this is for security reasons */
/* also if the ID is dummy entry it won't be edited and if the parameters are null, blank or invalid the old parameters will be preserved */
/* Here the price is automatically calculated as well so no user input is needed*/
go
create or alter procedure UpdateOrderDeliveryByID(
@id int,
@new_order_id int,
@new_service_id int,
@new_method_id int,
@new_status int,
@new_reason varchar(max)
)
as
begin
/* first check get old entry values and check if the ID is the dummy, if it is the dummy value do nothing */
/* select the current values from the table entry if it is found */
declare @old_order_id int;
select @old_order_id = OrderID from OrderDeliveries where ID = @id;
declare @old_service_id as int;
select @old_service_id = DeliveryServiceID from OrderDeliveries where ID = @id;
declare @old_method_id as int;
select @old_service_id = PaymentMethodID from OrderDeliveries where ID = @id;
declare @old_status as int;
select @old_status = DeliveryStatus from OrderDeliveries where ID = @id;
declare @old_reason as varchar(max);
select @old_reason = DeliveryReason from OrderDeliveries where ID = @id;
declare @final_price as money;
set @final_price = 0;
if @id < 0
begin
select 'Dummy entries shall not be edited!';
end
else
begin
/* first is the validation */
if @new_order_id is null
begin
set @new_order_id = @old_order_id;
end
if @new_service_id is null
begin
set @new_service_id = @old_service_id;
end
if @new_method_id is null
begin
set @new_method_id = @old_method_id;
end
if @new_status is null or @new_status < 0
begin
set @new_status = @old_status;
end
if @new_reason is null or @new_reason = ''
begin
set @new_reason = @old_reason;
end
/* Now calculating the final price, it is order price + delivery price and it is always like that */
declare @new_order_price as money;
declare @new_delivery_price as money;
select @new_order_price = OrderPrice from ProductOrders where ID = @new_order_id;
select @new_delivery_price = ServicePrice from DeliveryServices where ID = @new_service_id;
set @final_price = @new_order_price + @new_delivery_price;
/* and then update */
update OrderDeliveries set OrderID = @new_order_id, DeliveryServiceID = @new_service_id,
PaymentMethodID = @new_method_id, TotalPrice = @final_price, DateModified = getdate(), 
DeliveryStatus = @new_status, DeliveryReason = @new_reason where ID = @id;
end
end
go
/* Delete Order Delivery procedure, it will have almost the same manner as the Get Order Delivery procedure but will delete stuff,
if all the values are invalid then it will delete everything, if all the values are valid it will delete anything
that is coresponding to these parameters */
go
create or alter procedure DeleteOrderDelivery(
@id int,
@orderid int,
@serviceid int,
@methodid int,
@price money,
@dateaddedfrom date,
@dateaddedto date,
@datemodifiedfrom date,
@datemodifiedto date,
@status int,
@reason varchar(max)
)
as
begin
if @id >= 0 and @orderid >= 0 and @serviceid >= 0 and @methodid >= 0 and @price >= 0 and 
@dateaddedfrom != '' and @dateaddedto != '' and @datemodifiedfrom != '' and @datemodifiedto != '' and @status >= 0 and @reason != ''
begin
delete from OrderDeliveries where ID = @id and OrderID = @orderid and DeliveryServiceID = @serviceid and PaymentMethodID = @methodid and
(TotalPrice >= @price or TotalPrice <= @price) and DateAdded between @dateaddedfrom and @dateaddedto
and DateModified between @datemodifiedfrom and @datemodifiedto and DeliveryStatus = @status and DeliveryReason like '%'+@reason+'%' ;
end
else
begin
delete from OrderDeliveries;
end
end
go
go
/* Delete Order Delivery by ID, only for deleting by ID, will be mapped using Entity Model, if you want to delete specific product order or all 
product orders use DeleteOrderDelivery*/
create or alter procedure DeleteOrderDeliveryByID(
@id int
)
as
begin
if @id >= 0
begin
delete from OrderDeliveries where ID=@id;
end
else
begin
select 'Dummy entries shall not be deleted!';
end
end
go

/* Add Log stored procedure, it will be for securely adding logs to the logs table */
go
create or alter procedure AddLog(
@logdate date,
@logtitle varchar(50),
@logmessage varchar(max),
@additionalinformation varchar(max)
)
as
begin
insert into Logs(LogDate, LogTitle, LogMessage,AdditionalLogInformation)
values(@logdate,@logtitle,@logmessage,@additionalinformation);
end
go
/* Get Log stored procedure, if blank parameters are put it is supposed to return everything, if specific parameters
are provided it will return by the parameter criterias  and if not all criterias are valid all logs will be returned instead*/
go
create or alter procedure GetLog(
@id int,
@logdatefrom date,
@logdateto date,
@logtitle varchar(50),
@logmessage varchar(max),
@additionalinformation varchar(max)
)
as
begin
if @id >= 0 and @logdatefrom != '' and @logdateto != '' and @logtitle != '' and @logmessage != '' and @additionalinformation != ''
begin
select * from Logs where ID = @id and LogDate between @logdatefrom and @logdateto and LogTitle like '%' + @logtitle + '%'
and LogMessage like '%' + @logmessage + '% ' and AdditionalLogInformation like '%'+@additionalinformation+'%' ;
end
else
begin
select * from Logs;
end
end
go
/* Update Log by ID procedure, updates safely an user by ID and validates if the ID is not a dummy value */
/* by default IDs and Dates aren't to be edited via the stored procedures and this is for security reasons */
/* also if the ID is dummy entry it won't be edited and if the parameters are null, blank or invalid the old parameters will be preserved */
go
create or alter procedure UpdateLogByID(
@id int,
@new_log_title varchar(50),
@new_log_message varchar(max),
@new_add_info varchar(max)
)
as
begin
/* here only validation check is needed, nothing more so first get old values and then valiate and then update if it isn't the dummy value */
declare @old_log_title as varchar(50);
select @old_log_title = LogTitle from logs where ID = @id;
declare @old_log_message as varchar(max);
select @old_log_message = LogMessage from Logs where ID = @id;
declare @old_add_info as varchar(max);
select @old_add_Info = AdditionalLogInformation from Logs where ID = @id;
if @id < 0
begin
select 'Dummy entries shall not be edited!';
end
else
begin
if @new_log_title is null or @new_log_title = ''
begin
set @new_log_title = @old_log_title;
end
if @new_log_message is null or @new_log_message = ''
begin
set @new_log_message = @old_log_message;
end
if @new_add_info is null or @new_add_info = ''
begin
set @new_add_info = @old_add_info;
end
update Logs set LogTitle = @new_log_title, LogMessage = @new_log_message, AdditionalLogInformation = @new_add_info where ID = @id;
end
end
go
/* Delete Log procedure, it will have almost the same manner as the Get Log procedure but will delete stuff,
if all the values are invalid then it will delete everything, if all the values are valid it will delete anything
that is coresponding to these parameters */
go
create or alter procedure DeleteLog(
@id int,
@logdatefrom date,
@logdateto date,
@logtitle varchar(50),
@logmessage varchar(max),
@additionalinformation varchar(max)
)
as
begin
if @id >= 0 and @logdatefrom != '' and @logdateto != '' and @logtitle != '' and @logmessage != '' and @additionalinformation != ''
begin
delete from Logs where ID = @id and LogDate between @logdatefrom and @logdateto and LogTitle like '%' + @logtitle + '%'
and LogMessage like '%' + @logmessage + '% ' and AdditionalLogInformation like '%'+@additionalinformation+'%' ;
end
else
begin
delete from Logs;
end
end
go
go
/* Delete Log by ID, only for deleting by ID, will be mapped using Entity Model, if you want to delete specific log or all 
product orders use DeleteLog*/
create or alter procedure DeleteLogByID(
@id int
)
as
begin
if @id >= 0
begin
delete from Logs where ID=@id;
end
else
begin
select 'Dummy entries shall not be deleted!';
end
end
go
/* end of the stored procedures */
/* beginning of views */

/* some useful views that can help us in the long run so we don't have to make thousands of procedures and make our life harder */
/* employees and clients view, it will have sufficient data even fo generating reports from it . Remember: admins and employeers are employees
because they work for your company after all
*/
go
create or alter view EmployeeView as
select Users.UserName,Users.UserPassword,Users.UserDisplayName,Users.UserBirthDate,Users.UserPhone,Users.UserEmail,Users.UserAddress,
Users.UserProfilePic,Users.UserBalance,Users.UserDiagnose,Users.UserDateOfRegister,Users.UserRole, AVG(ProductOrders.OrderPrice) as AverageEmployeeIncome 
from Users, ProductOrders where Users.ID = ProductOrders.EmployeeID and Users.UserRole = 0 or Users.UserRole = 1 and ProductOrders.OrderStatus = 9
group by Users.UserName,Users.UserPassword,Users.UserDisplayName,Users.UserBirthDate,Users.UserPhone,Users.UserEmail,Users.UserAddress,
Users.UserProfilePic,Users.UserBalance,Users.UserDiagnose,Users.UserDateOfRegister,Users.UserRole, ProductOrders.ID,ProductOrders.ProductID,
ProductOrders.DesiredQuantity, ProductOrders.OrderPrice, ProductOrders.ClientID,ProductOrders.EmployeeID, ProductOrders.DateAdded,ProductOrders.DateModified, 
ProductOrders.OrderStatus, ProductOrders.OrderReason;
go
/* first time creating views so I am gonna test this one and the next ones */
select * from EmployeeView;
select * from Users;

go
create or alter view ClientView as
select Users.UserName,Users.UserPassword,Users.UserDisplayName,Users.UserBirthDate,Users.UserPhone,Users.UserEmail,Users.UserAddress,
Users.UserProfilePic,Users.UserBalance,Users.UserDiagnose,Users.UserDateOfRegister,Users.UserRole, AVG(ProductOrders.OrderPrice) as AverageClientSpending 
from Users, ProductOrders where Users.ID = ProductOrders.ClientID and Users.UserRole = 2 and ProductOrders.OrderStatus = 9
group by Users.UserName,Users.UserPassword,Users.UserDisplayName,Users.UserBirthDate,Users.UserPhone,Users.UserEmail,Users.UserAddress,
Users.UserProfilePic,Users.UserBalance,Users.UserDiagnose,Users.UserDateOfRegister,Users.UserRole, ProductOrders.ID,ProductOrders.ProductID,
ProductOrders.DesiredQuantity, ProductOrders.OrderPrice, ProductOrders.ClientID,ProductOrders.EmployeeID, ProductOrders.DateAdded,ProductOrders.DateModified, 
ProductOrders.OrderStatus, ProductOrders.OrderReason;
go

/* doing the same with the client view, selecting both the original view so we can compare them :) */
select * from ClientView;
select * from Users;

/* extended products view, gives enough details to make a report for a product and calculates its average sales and images of it uploaded
in the database(images are directly uploaded to the database in a binary format) */
go
create or alter view ExtendedProductView as
select ProductName, BrandName, ProductDescription, ProductQuantity, ProductPrice,
ProductExpiryDate, ProductRegNum, ProductPartNum, ProductStorageLocation, AVG(ProductOrders.OrderPrice) as AverageProductSale, Count(ProductImages.ImageName) as ProductImageCount
from Products, ProductBrands, ProductImages ,ProductOrders where ProductOrders.ProductID = Products.ID and Products.BrandID = ProductBrands.ID
and ProductImages.ProductID = Products.ID
group by ProductName, BrandName, ProductDescription, ProductQuantity, ProductPrice,
ProductExpiryDate, ProductRegNum, ProductPartNum, ProductStorageLocation, Products.ID, ProductOrders.ProductID, ProductImages.ProductID, DesiredQuantity,OrderPrice,ClientID,EmployeeID,
DateAdded,DateModified,OrderStatus,OrderReason, ProductImages.ImageName, ProductImages.ProductID
go

select * from ExtendedProductView;
select * from Products;

/* product brands extended view with added number of products of this brand */
go
create or alter view ExtendedBrandsView as
select BrandName, Count(Products.ID) as CountProductsFromBrand from ProductBrands, Products where Products.BrandID = ProductBrands.ID
group by BrandName;
go

select * from ExtendedBrandsView;
select * from productBrands;

/* payment methods extended view with times the payment method was used in order deliveries(if it is used in order deliveries it is used in orders) */
go
create or alter view ExtendedPaymentMethodsView as
select MethodName, count(OrderDeliveries.ID) as TimesThisMethodWasUsed from PaymentMethods, OrderDeliveries
where OrderDeliveries.PaymentMethodID = PaymentMethods.ID group by MethodName;
go

select * from ExtendedPaymentMethodsView;
select * from PaymentMethods;

/* delivery services extended view with times the service was used in the orders and deliveries(it is the same as the payment method) */
go
create or alter view ExtendedDeliveryServicesView as
select ServiceName, ServicePrice, Count(OrderDeliveries.ID) as TimesThisServiceWasUsed from DeliveryServices, OrderDeliveries
where OrderDeliveries.DeliveryServiceID = DeliveryServices.ID group by ServiceName,ServicePrice;
go

select * from ExtendedDeliveryServicesView;
select * from DeliveryServices;

/* extended product orders view and extended order deliveries view, these views provide information about the orders and the deliveries
and oh boy are they big queries and even with stored procedures it will be too much to handle  so a view is better than a procedure in 
this case  */

go
create or alter view ExtendedProductOrdersView as
select ProductOrders.ID, Products.ProductName, ProductBrands.BrandName, Products.ProductDescription, Products.ProductExpiryDate,
ProductOrders.DesiredQuantity, ProductOrders.OrderPrice,
(select UserDisplayName from Users, ProductOrders where ProductOrders.ClientID = Users.ID) as ClientName,
(select UserPhone from Users, ProductOrders where ProductOrders.ClientID = Users.ID) as ClientPhone,
(select UserEmail from Users, ProductOrders where ProductOrders.ClientID = Users.ID) as ClientEmail,
(select UserAddress from Users, ProductOrders where ProductOrders.ClientID = Users.ID) as ClientAddress,
(select UserDisplayName from Users,ProductOrders where ProductOrders.EmployeeID = Users.ID) as EmployeeName,
ProductOrders.DateAdded,ProductOrders.DateModified,ProductOrders.OrderStatus,ProductOrders.OrderReason
from ProductOrders inner join Products on ProductOrders.ProductID = Products.ID inner join ProductBrands on Products.BrandID = ProductBrands.ID
inner join Users on ProductOrders.EmployeeID = Users.ID or ProductOrders.ClientID = Users.ID;
go

select * from ExtendedProductOrdersView;
select * from ProductOrders;

go
create or alter view ExtendedOrderDeliveriesView as
select OrderDeliveries.ID, Products.ProductName, ProductBrands.BrandName, Products.ProductDescription, Products.ProductExpiryDate,
ProductOrders.DesiredQuantity, ProductOrders.OrderPrice,
(select UserDisplayName from Users, ProductOrders where ProductOrders.ClientID = Users.ID) as ClientName,
(select UserPhone from Users, ProductOrders where ProductOrders.ClientID = Users.ID) as ClientPhone,
(select UserEmail from Users, ProductOrders where ProductOrders.ClientID = Users.ID) as ClientEmail,
(select UserAddress from Users, ProductOrders where ProductOrders.ClientID = Users.ID) as ClientAddress,
(select UserDisplayName from Users,ProductOrders where ProductOrders.EmployeeID = Users.ID) as EmployeeName,
DeliveryServices.ServiceName, DeliveryServices.ServicePrice as DeliveryPrice, PaymentMethods.MethodName, OrderDeliveries.TotalPrice,
OrderDeliveries.DateAdded,OrderDeliveries.DateModified, OrderDeliveries.DeliveryStatus, OrderDeliveries.DeliveryReason
from OrderDeliveries inner join ProductOrders on OrderDeliveries.OrderID = ProductOrders.ID
inner join DeliveryServices on OrderDeliveries.DeliveryServiceID = DeliveryServices.ID
inner join PaymentMethods on OrderDeliveries.PaymentMethodID = PaymentMethods.ID
inner join Products on ProductOrders.ProductID = Products.ID
inner join ProductBrands on Products.BrandID = ProductBrands.ID;
go

select * from ExtendedOrderDeliveriesView;
select * from OrderDeliveries;

/* end of database views */
/* now for the interesting part, database roles, they are XPAdmin for admin, XPEmployee for Employee and XPClient for Client,
they will be assigned via a trigger on each added user when creating a new login for the database. Admins full power over
all tables while Employees and Clients have restricted create/read/update/delete permissions to specific tables */


create role XPAdmin;
grant alter, control, delete, execute, insert, references, select, take ownership, update, view definition
on schema::dbo to XPAdmin;

create role XPEmployee;
grant delete, select, insert, update, references, view definition on ProductOrders to XPEmployee;
grant delete, select, insert, update, references, view definition on OrderDeliveries to XPEmployee;
grant delete, select, insert, update, references, view definition on ProductImages to XPEmployee;
grant delete, select, insert, update, references, view definition on Users to XPEmployee;
grant select on Products to XPEmployee;
grant delete, select, insert, update, references, view definition on Logs to XPEmployee;
grant select on ProductBrands to XPEmployee;
grant select on PaymentMethods to XPEmployee;
grant select on DeliveryServices to XPEmployee;

create role XPClient;
grant select, insert, update, references, view definition on ProductOrders to XPClient;
grant select, insert, update, references, view definition on OrderDeliveries to XPClient;
grant select on ProductImages to XPEmployee;
grant delete, select, insert, update, references, view definition on Users to XPClient;
grant select on Products to XPClient;
grant select on ProductBrands to XPClient;
grant select on PaymentMethods to XPClient;
grant select on DeliveryServices to XPClient;

/* below is to verify that the roles exist after we finished creating them*/
select * from sys.database_principals;

/* end of roles */
/* triggers, the most important part, especially for product orders */
/* for regular stored procedures you can enable count so it you can retrieve the number of affected table fields,
but as triggers run in the background they don't need counts so it's better to set nocount on them */
/* first is product brands, it will have triggers that add logs on update, delete and insert */
go
create or alter trigger ProductBrands_OnAdd on ProductBrands for insert
as
begin
set nocount on;
declare @new_id as int;
declare @new_brand_name as varchar(200);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @new_id = ID from inserted;
select @new_brand_name = BrandName from inserted;
set @log_message = 'A new brand was added to the list with the id: ' + try_cast(@new_id as varchar);
set @additional_information = 'Brand ID: ' + try_cast(@new_id as varchar) + '\n' + 'Brand Name: ' + try_cast(@new_brand_name as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Brand Added', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger ProductBrands_OnUpdate on ProductBrands for update
as
begin
set nocount on;
declare @old_id as int;
declare @new_id as int;
declare @old_brand_name as varchar(200);
declare @new_brand_name as varchar(200);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @new_id = ID from inserted;
select @old_brand_name = BrandName from deleted;
select @new_brand_name = BrandName from inserted;
set @log_message = 'A product brand was updated with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Old Brand ID: ' + try_cast(@old_id as varchar) + '\n' + ' Old Brand Name: ' + try_cast(@old_brand_name as varchar) + '\n'
+ 'New Brand ID: ' + try_cast(@new_id as varchar) + '\n' + 'New Brand Name: ' + try_cast(@new_brand_name as varchar) + '\n' ;
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Brand Updated', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger ProductBrands_OnDelete on ProductBrands for delete
as
begin
set nocount on;
declare @old_id as int;
declare @old_brand_name as varchar(200);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @old_brand_name = BrandName from deleted;
set @log_message = 'A product brand was removed list with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Old Brand ID: ' + try_cast(@old_id as varchar) + '\n' + ' Old Brand Name: ' + try_cast(@old_brand_name as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Brand Removed', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go
/* next is the payment methods, standart triggers that add logs to the logs list */
go
create or alter trigger PaymentMethods_OnAdd on PaymentMethods for insert
as
begin
set nocount on;
declare @new_id as int;
declare @new_method_name as varchar(200);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @new_id = ID from inserted;
select @new_method_name = MethodName from inserted;
set @log_message = 'A payment method was added to the list with the id: ' + try_cast(@new_id as varchar);
set @additional_information = 'Method ID: ' + try_cast(@new_id as varchar) + '\n' + 'Method Name: ' + try_cast(@new_method_name as varchar) + '\n';
set @current_date = getdate()
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Payment Method Added', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger PaymentMethods_OnUpdate on PaymentMethods for update
as
begin
set nocount on;
declare @old_id as int;
declare @new_id as int;
declare @old_method_name as varchar(200);
declare @new_method_name as varchar(200);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @new_id = ID from inserted;
select @old_method_name = MethodName from deleted;
select @new_method_name = MethodName from inserted;
set @log_message = 'A payment method was updated with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Old Method ID: ' + try_cast(@old_id as varchar) + '\n' + ' Old Method Name: ' + try_cast(@old_method_name as varchar) + '\n'
+ 'New Method ID: ' + try_cast(@new_id as varchar) + '\n' + 'New Method Name: ' + try_cast(@new_method_name as varchar) + '\n' ;
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Payment Method Updated', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger PaymentMethods_OnDelete on PaymentMethods for delete
as
begin
set nocount on;
declare @old_id as int;
declare @old_method_name as varchar(200);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @old_method_name = MethodName from deleted;
set @log_message = 'A payment method was removed list with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Old Method ID: ' + try_cast(@old_id as varchar) + '\n' + ' Old Method Name: ' + try_cast(@old_method_name as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Payment Method Removed', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go
/* onward to the delivery services, same as the product brands and the payment methods but with additional field */
go
create or alter trigger DeliveryServices_OnAdd on DeliveryServices for insert
as
begin
set nocount on;
declare @new_id as int;
declare @new_service_name as varchar(200);
declare @new_service_price as money;
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @new_id = ID from inserted;
select @new_service_name = ServiceName from inserted;
select @new_service_price = ServicePrice from inserted;
set @log_message = 'A delivery service was added to the list with the id: ' + try_cast(@new_id as varchar);
set @additional_information = 'Service ID: ' + try_cast(@new_id as varchar) + '\n' + 'Service Name: ' + try_cast(@new_service_name as varchar) + '\n'
+ 'Service Price: ' + try_cast(@new_service_price as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Delivery Service Added', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger DeliveryServices_OnUpdate on DeliveryServices for update
as
begin
set nocount on;
declare @old_id as int;
declare @new_id as int;
declare @old_service_name as varchar(200);
declare @new_service_name as varchar(200);
declare @old_service_price as money;
declare @new_service_price as money;
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @new_id = ID from inserted;
select @old_service_name = ServiceName from deleted;
select @new_service_name = ServiceName from inserted;
select @old_service_price = ServicePrice from deleted;
select @new_service_price = ServicePrice from inserted;
set @log_message = 'A delivery service was updated with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Old Service ID: ' + try_cast(@old_id as varchar) + '\n' + ' Old Service Name: ' + try_cast(@old_service_name as varchar) + '\n'
+ 'Old Service Price: ' + try_cast(@old_service_price as varchar) + '\n'+
+ 'New Method ID: ' + try_cast(@new_id as varchar) + '\n' + 'New Method Name: ' + try_cast(@new_service_name as varchar) + '\n' +
'New Service Price: ' + try_cast(@new_service_price as varchar);
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Delivery Service Updated', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger DeliveryServices_OnDelete on DeliveryServices for delete
as
begin
set nocount on;
declare @old_id as int;
declare @old_service_name as varchar(200);
declare @old_service_price as money;
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @old_service_name = ServiceName from deleted;
select @old_service_price = ServicePrice from deleted;
set @log_message = 'A delivery service was removed list with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Old Service ID: ' + try_cast(@old_id as varchar) + '\n' + ' Old Service Name: ' + try_cast(@old_service_name as varchar) + '\n'
+ 'Old Service Price: ' + try_cast(@old_service_price as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Delivery Service Removed', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go
/* now the hulks are on. These triggers will take thousands lines of code to make. */
/* First tables are products and product images. Product images isn't a big table but depends very very much on the main products table */
/* product triggers */
go
create or alter trigger Products_OnAdd on Products for insert
as
begin
set nocount on;
declare @new_id as int;
declare @new_product_name as varchar(100);
declare @new_brand_id as int;
declare @new_product_description as varchar(200);
declare @new_product_quantity as int;
declare @new_product_price as money;
declare @new_product_expiry_date as date;
declare @new_product_reg_num as varchar(max);
declare @new_product_part_num as varchar(max);
declare @new_product_location as varchar(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @new_id = ID from inserted;
select @new_product_name = ProductName from inserted;
select @new_brand_id = BrandID from inserted;
select @new_product_description = ProductDescription from inserted;
select @new_product_quantity = ProductQuantity from inserted;
select @new_product_price = ProductPrice from inserted;
select @new_product_expiry_date = ProductExpiryDate from inserted;
select @new_product_reg_num = ProductRegNum from inserted;
select @new_product_part_num = ProductPartNum from inserted;
select @new_product_location = ProductStorageLocation from inserted;
set @log_message = 'A product was added to the list with the id: ' + try_cast(@new_id as varchar);
set @additional_information = 'Product ID: ' + try_cast(@new_id as varchar) + '\n' + 'Product Name: ' + try_cast(@new_product_name as varchar) + '\n'
+ 'Brand ID: ' + try_cast(@new_brand_id as varchar) + '\n' + 'Product Description: ' + try_cast(@new_product_description as varchar) + '\n' +
'Product Quantity: ' + try_cast(@new_product_quantity as varchar) + '\n' + 'Product Price: ' + try_cast(@new_product_price as varchar) + '\n' + 
'Product Expiry Date: ' + try_cast(@new_product_expiry_date as varchar) + '\n' + 'Product Reg. Number: ' + try_cast(@new_product_reg_num as varchar) + '\n' + 
'Product Part. Number: ' + try_cast(@new_product_part_num as varchar) + '\n' + 'Product Storage Location: ' + try_cast(@new_product_location as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Added', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger Products_OnUpdate on Products for update
as
begin
set nocount on;
declare @old_id as int;
declare @new_id as int;
declare @old_product_name as varchar(100);
declare @new_product_name as varchar(100);
declare @old_brand_id as int;
declare @new_brand_id as int;
declare @old_product_description as varchar(200);
declare @new_product_description as varchar(200);
declare @old_product_quantity as int;
declare @new_product_quantity as int;
declare @old_product_price as money;
declare @new_product_price as money;
declare @old_product_expiry_date as date;
declare @new_product_expiry_date as date;
declare @old_product_reg_num as varchar(max);
declare @new_product_reg_num as varchar(max);
declare @old_product_part_num as varchar(max);
declare @new_product_part_num as varchar(max);
declare @old_product_location as varchar(max);
declare @new_product_location as varchar(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @new_id = ID from inserted;
select @old_product_name = ProductName from deleted;
select @new_product_name = ProductName from inserted;
select @old_brand_id = BrandID from deleted;
select @new_brand_id = BrandID from inserted;
select @old_product_description = ProductDescription from deleted;
select @new_product_description = ProductDescription from inserted;
select @old_product_quantity = ProductQuantity from deleted;
select @new_product_quantity = ProductQuantity from inserted;
select @old_product_price = ProductPrice from deleted;
select @new_product_price = ProductPrice from inserted;
select @old_product_expiry_date = ProductExpiryDate from deleted;
select @new_product_expiry_date = ProductExpiryDate from inserted;
select @old_product_reg_num = ProductRegNum from deleted;
select @new_product_reg_num = ProductRegNum from inserted;
select @old_product_part_num = ProductPartNum from deleted;
select @new_product_part_num = ProductPartNum from inserted;
select @old_product_location = ProductStorageLocation from deleted;
select @new_product_location = ProductStorageLocation from inserted;
set @log_message = 'A product was updated with the id: ' + try_cast(@old_id as varchar) + 
'.\nThe product orders for the following product will be updated with new prices as well.\nThe affected orders will have standart prices
and you have to override their prices again.\n';
/* update the prices of orders that have either the new ID or the old ID of the product. This is a safety measure to prevent inconsistence
but might remove the price overrides and they should be set again so add your price overrides again */
declare @affected_orders as table(OrderCounter int identity primary key not null, OrderID int unique not null, DesiredQuantity int not null, OrderPrice money not null);
declare @affected_orders_count as int;
declare @affected_orders_last as int;
insert into @affected_orders(OrderID,DesiredQuantity,OrderPrice)
select ID,DesiredQuantity,OrderPrice from ProductOrders where ProductID = @old_id or ID = @new_id;
select  top 1 @affected_orders_count = OrderCounter from @affected_orders order by OrderCounter asc; /* first element in the ascending order */
select  top 1 @affected_orders_last = OrderCounter from @affected_orders order by OrderCounter desc; /* last element in the ascending order */
while @affected_orders_count <= @affected_orders_last  /* iteration loop that runs as long as the count hasn't reached the last element */
begin
declare @affected_order_id as int;
declare @affected_order_quantity as int;
declare @affected_order_price as money;
declare @new_order_price as money;
/* ensure the ID and price gotten are from the fields the current count is on  and get them*/
select @affected_order_id = OrderID from @affected_orders where OrderCounter = @affected_orders_count;
select @affected_order_quantity = DesiredQuantity from @affected_orders where OrderCounter = @affected_orders_count;
select @affected_order_price = OrderPrice from @affected_orders where OrderCounter = @affected_orders_count;
set @new_order_price = @affected_order_quantity * @new_product_price;
update ProductOrders set OrderPrice = @new_order_price where ID = @affected_order_id; /* set a new price for the order */
set @affected_orders_count = @affected_orders_count + 1; /* this counts upwards otherwise the loop will be stuck */
end
/* then make the log messages and add the logs */
set @additional_information =   'Old Product ID: ' + try_cast(@old_id as varchar) + '\n' + 'Old Product Name: ' + try_cast(@old_product_name as varchar) + '\n'
+ 'Old Brand ID: ' + try_cast(@old_brand_id as varchar) + '\n' + 'Old Product Description: ' + try_cast(@old_product_description as varchar) + '\n' +
'Old Product Quantity: ' + try_cast(@old_product_quantity as varchar) + '\n' + 'Old Product Price: ' + try_cast(@old_product_price as varchar) + '\n' + 
'Old Product Expiry Date: ' + try_cast(@old_product_expiry_date as varchar) + '\n' + 'Old Product Reg. Number: ' + try_cast(@old_product_reg_num as varchar) + '\n' + 
'Old Product Part. Number: ' + try_cast(@old_product_part_num as varchar) + '\n' + 'Old Product Storage Location: ' + try_cast(@old_product_location as varchar) + '\n' + 
'New Product ID: ' + try_cast(@new_id as varchar) + '\n' + 'New Product Name: ' + try_cast(@new_product_name as varchar) + '\n'
+ 'New Brand ID: ' + try_cast(@new_brand_id as varchar) + '\n' + 'New Product Description: ' + try_cast(@new_product_description as varchar) + '\n' +
'New Product Quantity: ' + try_cast(@new_product_quantity as varchar) + '\n' + 'New Product Price: ' + try_cast(@new_product_price as varchar) + '\n' + 
'New Product Expiry Date: ' + try_cast(@new_product_expiry_date as varchar) + '\n' + 'New Product Reg. Number: ' + try_cast(@new_product_reg_num as varchar) + '\n' + 
'New Product Part. Number: ' + try_cast(@new_product_part_num as varchar) + '\n' + 'New Product Storage Location: ' + try_cast(@new_product_location as varchar) + '\n' ;
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Updated', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger Products_OnDelete on Products for delete
as
begin
set nocount on;
declare @old_id as int;
declare @old_product_name as varchar(100);
declare @old_brand_id as int;
declare @old_product_description as varchar(200);
declare @old_product_quantity as int;
declare @old_product_price as money;
declare @old_product_expiry_date as date;
declare @old_product_reg_num as varchar(max);
declare @old_product_part_num as varchar(max);
declare @old_product_location as varchar(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @old_product_name = ProductName from deleted;
select @old_brand_id = BrandID from deleted;
select @old_product_description = ProductDescription from deleted;
select @old_product_quantity = ProductQuantity from deleted;
select @old_product_price = ProductPrice from deleted;
select @old_product_expiry_date = ProductExpiryDate from deleted;
select @old_product_reg_num = ProductRegNum from deleted;
select @old_product_part_num = ProductPartNum from deleted;
select @old_product_location = ProductStorageLocation from deleted;
set @log_message = 'A product was removed list with the id: ' + try_cast(@old_id as varchar);
set @additional_information =  'Product ID: ' + try_cast(@old_id as varchar) + '\n' + 'Product Name: ' + try_cast(@old_product_name as varchar) + '\n'
+ 'Brand ID: ' + try_cast(@old_brand_id as varchar) + '\n' + 'Product Description: ' + try_cast(@old_product_description as varchar) + '\n' +
'Product Quantity: ' + try_cast(@old_product_quantity as varchar) + '\n' + 'Product Price: ' + try_cast(@old_product_price as varchar) + '\n' + 
'Product Expiry Date: ' + try_cast(@old_product_expiry_date as varchar) + '\n' + 'Product Reg. Number: ' + try_cast(@old_product_reg_num as varchar) + '\n' + 
'Product Part. Number: ' + try_cast(@old_product_part_num as varchar) + '\n' + 'Product Storage Location: ' + try_cast(@old_product_location as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Removed', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go
/* product images triggers */
go
create or alter trigger ProductImages_OnAdd on ProductImages for insert
as
begin
set nocount on;
declare @new_id as int;
declare @new_product_id as int;
declare @new_image_name as varchar(100);
declare @new_image_data as varbinary(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @new_id = ID from inserted;
select @new_product_id = ProductID from inserted;
select @new_image_name = ImageName from inserted;
select @new_image_data = ImageData from inserted;
set @log_message = 'A product image was added to the list with the id: ' + try_cast(@new_id as varchar);
set @additional_information = 'Image ID: ' + try_cast(@new_id as varchar) + '\n' + 'Product ID: ' + try_cast(@new_product_id as varchar) + '\n' +
'Image Name: ' + try_cast(@new_image_name as varchar) + '\n' + 'Image Data Dump: ' + try_cast(@new_image_data as varchar(max)) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Image Added', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger ProductImages_OnUpdate on ProductImages for update
as
begin
set nocount on;
declare @old_id as int;
declare @new_id as int;
declare @old_product_id as int;
declare @new_product_id as int;
declare @old_image_name as varchar(100);
declare @new_image_name as varchar(100);
declare @old_image_data as varbinary(max);
declare @new_image_data as varbinary(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @new_id = ID from inserted;
select @old_product_id = ProductID from deleted;
select @new_product_id = ProductID from inserted;
select @old_image_name = ImageName from deleted;
select @new_image_name = ImageName from inserted;
select @old_image_data = ImageData from deleted;
select @new_image_data = ImageData from inserted;
set @log_message = 'A product image was updated with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Old Image ID: ' + try_cast(@old_id as varchar) + '\n' + 'Old Product ID: ' + try_cast(@old_product_id as varchar) + '\n' +
'Old Image Name: ' + try_cast(@old_image_name as varchar) + '\n' + 'Old Image Data Dump: ' + try_cast(@old_image_data as varchar(max)) + '\n' +
'New Image ID: ' + try_cast(@new_id as varchar) + '\n' + 'New Product ID: ' + try_cast(@new_product_id as varchar) + '\n' +
'New Image Name: ' + try_cast(@new_image_name as varchar) + '\n' + 'New Image Data Dump: ' + try_cast(@new_image_data as varchar(max)) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Image Updated', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger ProductImages_OnDelete on ProductImages for delete
as
begin
set nocount on;
declare @old_id as int;
declare @old_product_id as int;
declare @old_image_name as varchar(100);
declare @old_image_data as varbinary(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @old_product_id = ProductID from deleted;
select @old_image_name = ImageName from deleted;
select @old_image_data = ImageData from deleted;
set @log_message = 'A product image was removed list with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Image ID: ' + try_cast(@old_id as varchar) + '\n' + 'Product ID: ' + try_cast(@old_product_id as varchar) + '\n' +
'Image Name: ' + try_cast(@old_image_name as varchar) + '\n' + 'Image Data Dump: ' + try_cast(@old_image_data as varchar(max)) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Image Removed', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go
/* users triggers, unique on their own, they will update the user references if the ID is updated, create logins and add them to roles */
go
create or alter trigger Users_OnAdd on Users for insert
as
begin
set nocount on;
declare @new_id as int;
declare @new_user_name as varchar(50);
declare @new_user_password as varchar(100);
declare @new_display_name as varchar(100);
declare @new_birth_date as date;
declare @new_phone as varchar(100);
declare @new_email as varchar(100);
declare @new_address as varchar(250);
declare @new_profile_pic as varbinary(max);
declare @new_user_balance as money;
declare @new_diagnose as varchar(max);
declare @new_register_date as date;
declare @new_role as int;
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
DECLARE @sql NVARCHAR(MAX);
declare @currentdate as date;
select @new_id = ID from inserted;
select @new_user_name = UserName from inserted;
select @new_user_password = UserPassword from inserted;
select @new_display_name = UserDisplayName from inserted;
select @new_birth_date = UserBirthDate from inserted;
select @new_phone = UserPhone from inserted;
select @new_email = UserEmail from inserted;
select @new_address = UserAddress from inserted;
select @new_profile_pic = UserProfilePic from inserted;
select @new_user_balance = UserBalance from inserted;
select @new_diagnose = UserDiagnose from inserted;
select @new_register_date = UserDateOfRegister from inserted;
select @new_role = UserRole from inserted;
set @currentdate = getdate();
set @log_message = 'An user was added to the list with the id: ' + try_cast(@new_id as varchar);
/* first check the role and create a login and add it to role */
/* I used the chatgpt for making the login creation and altering */


SET @sql = 'CREATE LOGIN ' + QUOTENAME(@new_user_name) + ' WITH PASSWORD = ''' + @new_user_password + ''';';
EXEC sp_executesql @sql;

SET @sql = 'CREATE USER ' + QUOTENAME(@new_user_name) + ' FOR LOGIN ' + QUOTENAME(@new_user_name) + ';';
EXEC sp_executesql @sql;
if @new_role = 0
begin
set @sql = 'alter role XPAdmin add member ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
else if @new_role = 1
begin
set @sql = 'alter role XPEmployee add member ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
else if @new_role = 2
begin
set @sql = 'alter role XPClient add member ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
set @additional_information = 'User ID: ' + try_cast(@new_id as varchar) + '\n' +
'User Name: ' + try_cast(@new_user_name as varchar) + '\n' + 'User Password: ' + try_cast(@new_user_password as varchar) + '\n' +
'Display Name: ' + try_cast(@new_display_name as varchar) + '\n' + 'Birth Date: ' + try_cast(@new_birth_date as varchar) + '\n' +
'User Phone: ' + try_cast(@new_phone as varchar) + '\n' + 'User Email: ' + try_cast(@new_email as varchar) + '\n' +
'User Address: ' + try_cast(@new_address as varchar) + '\n' + 'Profile Picture data dump: ' + try_cast(@new_profile_pic as varchar) + '\n' +
'User Balance: ' + try_cast(@new_user_balance as varchar) + '\n' + 'User Diagnose: ' + try_cast(@new_diagnose as varchar) + '\n'+
'Register Date: ' + try_cast(@new_register_date as varchar) + '\n' + 'Role ID: ' + try_cast(@new_role as varchar) + '\n';
exec AddLog @logdate = @currentdate, 
@logtitle='[XTremePharmacyDB] User Added', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger Users_OnUpdate on Users for update
as
begin
set nocount on;
declare @old_id as int;
declare @new_id as int;
declare @old_user_name as varchar(50);
declare @new_user_name as varchar(50);
declare @old_user_password as varchar(100);
declare @new_user_password as varchar(100);
declare @old_display_name as varchar(100);
declare @new_display_name as varchar(100);
declare @old_birth_date as date;
declare @new_birth_date as date;
declare @old_phone as varchar(100);
declare @new_phone as varchar(100);
declare @old_email as varchar(100);
declare @new_email as varchar(100);
declare @old_address as varchar(250);
declare @new_address as varchar(250);
declare @old_profile_pic as varbinary(max);
declare @new_profile_pic as varbinary(max);
declare @old_user_balance as money;
declare @new_user_balance as money;
declare @old_diagnose as varchar(max);
declare @new_diagnose as varchar(max);
declare @old_register_date as date;
declare @new_register_date as date;
declare @old_role as int;
declare @new_role as int;
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @currentdate as date;
declare @sql as nvarchar(max);
select @old_id = ID from deleted;
select @new_id = ID from inserted;
select @old_user_name = UserName from deleted;
select @new_user_name = UserName from inserted;
select @old_user_password = UserPassword from deleted;
select @new_user_password = UserPassword from inserted;
select @old_display_name = UserDisplayName from deleted;
select @new_display_name = UserDisplayName from inserted;
select @old_birth_date = UserBirthDate from deleted;
select @new_birth_date = UserBirthDate from inserted;
select @old_phone = UserPhone from deleted;
select @new_phone = UserPhone from inserted;
select @old_email = UserEmail from deleted;
select @new_email = UserEmail from inserted;
select @old_address = UserAddress from deleted;
select @new_address = UserAddress from inserted;
select @old_profile_pic = UserProfilePic from deleted;
select @new_profile_pic = UserProfilePic from inserted;
select @old_user_balance = UserBalance from deleted;
select @new_user_balance = UserBalance from inserted;
select @old_diagnose = UserDiagnose from deleted;
select @new_diagnose = UserDiagnose from inserted;
select @old_register_date = UserDateOfRegister from deleted;
select @new_register_date = UserDateOfRegister from inserted;
select @old_role = UserRole from deleted;
select @new_role = UserRole from inserted;
/* and before that let's check if the username and/or password are changed and change the logins and users*/
if @new_user_name != @old_user_name or @new_user_password != @old_user_password or (@old_user_name != @new_user_name and @old_user_password != @new_user_password)
begin
set @sql = 'alter login ' + QUOTENAME(@old_user_name) + ' with name = ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
set @sql = 'alter login ' + QUOTENAME(@new_user_name) + ' with password = ''' + @new_user_password + ''';';
exec sp_executesql @sql;
set @sql = 'alter user ' + QUOTENAME(@old_user_name) + ' with name = ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
set @sql = 'alter user ' + QUOTENAME(@new_user_name) + ' with login = ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
/* wait a moment, we have to check the old role and remove the user from that role if it has a login */
if @old_role is not null and @old_role != @new_role
begin
if @old_role = 0
begin
set @sql = 'alter role XPAdmin drop member ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
else if @old_role = 1
begin
set @sql = 'alter role XPEmployee drop member ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
else if @old_role = 2
begin
set @sql = 'alter role XPClient drop member ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
end
/* now add the new role if the new role is not null and is different from old role */
if @new_role is not null and @new_role != @old_role
begin
if @new_role = 0
begin
set @sql = 'alter role XPAdmin add member ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
else if @new_role = 1
begin
set @sql = 'alter role XPEmployee add member ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
else if @new_role = 2
begin
set @sql = 'alter role XPClient add member ' + QUOTENAME(@new_user_name) + ';';
exec sp_executesql @sql;
end
end
/* now check if the ID is changed and the role is changed then updated the orders somehow */
if @old_id != @new_id
declare @affected_orders as table(OrderCounter int identity primary key not null , OrderID int unique);
declare @affected_orders_count as int;
declare @affected_orders_last as int;
declare @current_affected_order_id as int;
begin
if (@old_role = 0 or @old_role = 1) and (@new_role = 0 or @new_role = 1)
begin
insert into @affected_orders select ID from ProductOrders where EmployeeID = @old_id;
select  top 1 @affected_orders_count = OrderCounter from @affected_orders order by OrderCounter asc;
select  top 1 @affected_orders_last = OrderCounter from @affected_orders order by OrderCOunter desc;
while @affected_orders_count <= @affected_orders_last
begin
select @current_affected_order_id = OrderID from @affected_orders where OrderCounter = @affected_orders_count;
update ProductOrders set EmployeeID = @new_id where ID = @current_affected_order_id;
set @affected_orders_count = @affected_orders_count + 1;
end
end
if @old_role = 2 and @new_role = 2
begin
insert into @affected_orders select ID from ProductOrders where ClientID = @old_id;
select  top 1 @affected_orders_count = OrderCounter from @affected_orders order by OrderCounter asc;
select  top 1 @affected_orders_last = OrderCounter from @affected_orders order by OrderCOunter desc;
while @affected_orders_count <= @affected_orders_last
begin
select @current_affected_order_id = OrderID from @affected_orders where OrderCounter = @affected_orders_count;
update ProductOrders set ClientID = @new_id where ID = @current_affected_order_id;
set @affected_orders_count = @affected_orders_count + 1;
end
end
if (@old_role = 0 or @old_role = 1) and @new_role = 2
begin
insert into @affected_orders select ID from ProductOrders where EmployeeID = @old_id;
select  top 1 @affected_orders_count = OrderCounter from @affected_orders order by OrderCounter asc;
select  top 1 @affected_orders_last = OrderCounter from @affected_orders order by OrderCOunter desc;
while @affected_orders_count <= @affected_orders_last
begin
select @current_affected_order_id = OrderID from @affected_orders where OrderCounter = @affected_orders_count;
update ProductOrders set EmployeeID = -1 where ID = @current_affected_order_id;
set @affected_orders_count = @affected_orders_count + 1;
end
end
if (@old_role = 2) and (@new_role =  0 or @new_role = 1)
begin
insert into @affected_orders select ID from ProductOrders where ClientID = @old_id;
select  top 1 @affected_orders_count = OrderCounter from @affected_orders order by OrderCounter asc;
select  top 1 @affected_orders_last = OrderCounter from @affected_orders order by OrderCOunter desc;
while @affected_orders_count <= @affected_orders_last
begin
select @current_affected_order_id = OrderID from @affected_orders where OrderCounter = @affected_orders_count;
update ProductOrders set ClientID = -1 where ID = @current_affected_order_id;
set @affected_orders_count = @affected_orders_count + 1;
end
end
end
set @currentdate = getdate();
set @log_message = 'An user was updated with the id: ' + try_cast(@old_id as varchar) + 
'.\n If its role is the same the ID will be updated on the orders,\notherwise it will beed to be manually reselected in the orders.\n';
set @additional_information = 'Old User ID: ' + try_cast(@old_id as varchar) + '\n' +
'Old User Name: ' + try_cast(@old_user_name as varchar) + '\n' + 'Old User Password: ' + try_cast(@old_user_password as varchar) + '\n' +
'Old Display Name: ' + try_cast(@old_display_name as varchar) + '\n' + 'Old Birth Date: ' + try_cast(@old_birth_date as varchar) + '\n' +
'Old User Phone: ' + try_cast(@old_phone as varchar) + '\n' + 'Old User Email: ' + try_cast(@old_email as varchar) + '\n' +
'Old User Address: ' + try_cast(@old_address as varchar) + '\n' + 'Old Profile Picture data dump: ' + try_cast(@old_profile_pic as varchar) + '\n' +
'Old User Balance: ' + try_cast(@old_user_balance as varchar) + '\n' + 'Old User Diagnose: ' + try_cast(@old_diagnose as varchar) + '\n'+
'Old Register Date: ' + try_cast(@old_register_date as varchar) + '\n' + 'New Role ID: ' + try_cast(@old_role as varchar) + '\n' + 
'New User ID: ' + try_cast(@new_id as varchar) + '\n' +
'New User Name: ' + try_cast(@new_user_name as varchar) + '\n' + 'New User Password: ' + try_cast(@new_user_password as varchar) + '\n' +
'New Display Name: ' + try_cast(@new_display_name as varchar) + '\n' + 'New Birth Date: ' + try_cast(@new_birth_date as varchar) + '\n' +
'New User Phone: ' + try_cast(@new_phone as varchar) + '\n' + 'New User Email: ' + try_cast(@new_email as varchar) + '\n' +
'New User Address: ' + try_cast(@new_address as varchar) + '\n' + 'New Profile Picture data dump: ' + try_cast(@new_profile_pic as varchar) + '\n' +
'New User Balance: ' + try_cast(@new_user_balance as varchar) + '\n' + 'New User Diagnose: ' + try_cast(@new_diagnose as varchar) + '\n'+
'New Register Date: ' + try_cast(@new_register_date as varchar) + '\n' + 'New Role ID: ' + try_cast(@new_role as varchar) + '\n' ;
exec AddLog @logdate = @currentdate, 
@logtitle='[XTremePharmacyDB] User Updated', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger Users_OnDelete on Users for delete
as
begin
set nocount on;
declare @old_id as int;
declare @old_user_name as varchar(50);
declare @old_user_password as varchar(100);
declare @old_display_name as varchar(100);
declare @old_birth_date as date;
declare @old_phone as varchar(100);
declare @old_email as varchar(100);
declare @old_address as varchar(250);
declare @old_profile_pic as varbinary(max);
declare @old_user_balance as money;
declare @old_diagnose as varchar(max);
declare @old_register_date as date;
declare @old_role as int;
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @currentdate as date;
declare @sql as nvarchar(max);
select @old_id = ID from deleted;
select @old_user_name = UserName from deleted;
select @old_user_password = UserPassword from deleted;
select @old_display_name = UserDisplayName from deleted;
select @old_birth_date = UserBirthDate from deleted;
select @old_phone = UserPhone from deleted;
select @old_email = UserEmail from deleted;
select @old_address = UserAddress from deleted;
select @old_profile_pic = UserProfilePic from deleted;
select @old_user_balance = UserBalance from deleted;
select @old_diagnose = UserDiagnose from deleted;
select @old_register_date = UserDateOfRegister from deleted;
select @old_role = UserRole from deleted;
/* so here for a deleted user remove the user their role */
if @old_role is not null
begin
if @old_role = 0
begin
set @sql = 'alter role XPAdmin drop member ' + QUOTENAME(@old_user_name) + ';';
exec sp_executesql @sql;
end
else if @old_role = 1
begin
set @sql = 'alter role XPEmployee drop member ' + QUOTENAME(@old_user_name) + ';';
exec sp_executesql @sql;
end
else if @old_role = 2
begin
set @sql = 'alter role XPClient drop member ' + QUOTENAME(@old_user_name) + ';';
exec sp_executesql @sql;
end
end
/* now drop the login data and the user */
if @old_user_name is not null and @old_user_password is not null
begin
set @sql = 'drop user ' + QUOTENAME(@old_user_name) + ';';
exec sp_executesql @sql;
set @sql = 'drop login ' + QUOTENAME(@old_user_name) + ';';
exec sp_executesql @sql;
end
/* now delete the ID of the user from the product orders */
declare @affected_orders as table(OrderCounter int identity primary key not null , OrderID int unique);
declare @affected_orders_count as int;
declare @affected_orders_last as int;
declare @current_affected_order_id as int;
if @old_role = 0 or @old_role = 1
begin
insert into @affected_orders select ID from ProductOrders where EmployeeID = @old_id;
select  top 1 @affected_orders_count = OrderCounter from @affected_orders order by OrderCounter asc;
select  top 1 @affected_orders_last = OrderCounter from @affected_orders order by OrderCOunter desc;
while @affected_orders_count <= @affected_orders_last
begin
select @current_affected_order_id = OrderID from @affected_orders where OrderCounter = @affected_orders_count;
update ProductOrders set EmployeeID = -1 where ID = @current_affected_order_id;
set @affected_orders_count = @affected_orders_count + 1;
end
end
if @old_role = 2
begin
insert into @affected_orders select ID from ProductOrders where ClientID = @old_id;
select  top 1 @affected_orders_count = OrderCounter from @affected_orders order by OrderCounter asc;
select  top 1 @affected_orders_last = OrderCounter from @affected_orders order by OrderCOunter desc;
while @affected_orders_count <= @affected_orders_last
begin
select @current_affected_order_id = OrderID from @affected_orders where OrderCounter = @affected_orders_count;
update ProductOrders set ClientID = -1 where ID = @current_affected_order_id;
set @affected_orders_count = @affected_orders_count + 1;
end
end
set @currentdate = getdate();
set @log_message = 'An user was removed list with the id: ' + try_cast(@old_id as varchar);
set @additional_information =  'Old User ID: ' + try_cast(@old_id as varchar) + '\n' +
'Old User Name: ' + try_cast(@old_user_name as varchar) + '\n' + 'Old User Password: ' + try_cast(@old_user_password as varchar) + '\n' +
'Old Display Name: ' + try_cast(@old_display_name as varchar) + '\n' + 'Old Birth Date: ' + try_cast(@old_birth_date as varchar) + '\n' +
'Old User Phone: ' + try_cast(@old_phone as varchar) + '\n' + 'Old User Email: ' + try_cast(@old_email as varchar) + '\n' +
'Old User Address: ' + try_cast(@old_address as varchar) + '\n' + 'Old Profile Picture data dump: ' + try_cast(@old_profile_pic as varchar) + '\n' +
'Old User Balance: ' + try_cast(@old_user_balance as varchar) + '\n' + 'Old User Diagnose: ' + try_cast(@old_diagnose as varchar) + '\n'+
'Old Register Date: ' + try_cast(@old_register_date as varchar) + '\n' + 'New Role ID: ' + try_cast(@old_role as varchar) + '\n';
exec AddLog @logdate = @currentdate, 
@logtitle='[XTremePharmacyDB] User Removed', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

/* now the product order triggers, they are unique in their own way because they do many things to products and users depending on their status */
/* writing these triggers is insanity and the insert trigger and delete triggers may not have anything unusual, but update trigger, there is the
Hell*/
go
create or alter trigger ProductOrders_OnAdd on ProductOrders for insert
as
begin
set nocount on;
declare @new_id as int;
declare @new_product_id as int;
declare @new_desired_quantity as int;
declare @new_order_price as money;
declare @new_client_id as int;
declare @new_employee_id as int;
declare @new_date_added as date;
declare @new_date_modified as date;
declare @new_order_status as int;
declare @new_order_reason as varchar(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @new_id = ID from inserted;
select @new_product_id = ProductID from inserted;
select @new_desired_quantity = DesiredQuantity from inserted;
select @new_order_price = OrderPrice from inserted;
select @new_client_id = ClientID from inserted;
select @new_employee_id = EmployeeID from inserted;
select @new_date_added = DateAdded from inserted;
select @new_date_modified = DateModified from inserted;
select @new_order_status = OrderStatus from inserted;
select @new_order_reason = OrderReason from inserted;
set @log_message = 'A product order was added to the list with the id: ' + try_cast(@new_id as varchar);
set @additional_information = 'Order ID: ' + try_cast(@new_id as varchar) + '\n' + 'Product ID: ' + try_cast(@new_product_id as varchar) + '\n' +
'Desired Quantity: ' + try_cast(@new_desired_quantity as varchar) + '\n' + 'Price: ' + try_cast(@new_order_price as varchar) + '\n' +
'Client ID: ' + try_cast(@new_client_id as varchar) + '\n' + 'Employee ID: ' + try_cast(@new_employee_id as varchar) + '\n' + 
'Date Added: ' + try_cast(@new_date_added as varchar) + '\n' + 'Date Modified: ' + try_cast(@new_date_modified as varchar) + '\n' +
'Status ID: ' + try_cast(@new_order_status as varchar) + '\n' + 'Reason: ' + try_cast(@new_order_reason as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Order Added', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger ProductOrders_OnUpdate on ProductOrders for update
as
begin
set nocount on;
declare @old_id as int;
declare @new_id as int;
declare @old_product_id as int;
declare @new_product_id as int;
declare @old_desired_quantity as int;
declare @new_desired_quantity as int;
declare @old_order_price as money;
declare @new_order_price as money;
declare @old_client_id as int;
declare @new_client_id as int;
declare @old_employee_id as int;
declare @new_employee_id as int;
declare @old_date_added as date;
declare @new_date_added as date;
declare @old_date_modified as date;
declare @new_date_modified as date;
declare @old_order_status as int;
declare @new_order_status as int;
declare @old_order_reason as varchar(max);
declare @new_order_reason as varchar(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @new_id = ID from inserted;
select @old_product_id = ProductID from deleted;
select @new_product_id = ProductID from inserted;
select @old_desired_quantity = DesiredQuantity from deleted;
select @new_desired_quantity = DesiredQuantity from inserted;
select @old_order_price = OrderPrice from deleted;
select @new_order_price = OrderPrice from inserted;
select @old_client_id = ClientID from deleted;
select @new_client_id = ClientID from inserted;
select @old_employee_id = EmployeeID from deleted;
select @new_employee_id = EmployeeID from inserted;
select @old_date_added = DateAdded from deleted;
select @new_date_added = DateAdded from inserted;
select @old_date_modified = DateModified from deleted;
select @new_date_modified = DateModified from inserted;
select @old_order_status = OrderStatus from deleted;
select @new_order_status = OrderStatus from inserted;
select @old_order_reason = OrderReason from deleted;
select @new_order_reason = OrderReason from inserted;
set @log_message = 'A product order was updated with the id: ' + try_cast(@old_id as varchar) + '.\n
Money and product quantities will be handled in the database depending on the status of the order.\n';
/* now depends on the status and here is a cheatsheet for status:
0 - awaiting processing
1 - prepaid
2 - paid in the moment of delivery
3 - directly paid
4 - generating invoice
5 - generating report
6 - processing
7 - cancelled order
8 - returned order
9 - completed
That way let's make the order trigger control where the money go and where the stonk goes*/
declare @current_client_balance as money;
declare @final_client_balance as money;
declare @current_employee_balance as money;
declare @final_employee_balance as money;
declare @current_product_quantity as int;
declare @final_product_quantity as int;
if (@old_order_status = 0 or @old_order_status = 1 or @old_order_status = 3)
and (@new_order_status != 2 or @new_order_status != 7 or @new_order_status != 8 or @new_order_status != 9)
begin
if @new_client_id >= 0
begin
select @current_client_balance = UserBalance from Users where ID = @new_client_id;
set @final_client_balance = @current_client_balance - @new_order_price;
update Users set UserBalance = @final_client_balance where ID = @new_client_id;
end
end
if (@old_order_status != 0 and @old_order_status != 1 and @old_order_status = 2)
and (@new_order_status != 7 or @new_order_status != 8 or @new_order_status != 9)
begin
if @new_client_id >= 0
begin
select @current_client_balance = UserBalance from Users where ID = @new_client_id;
set @final_client_balance = @current_client_balance - @new_order_price;
update Users set UserBalance = @final_client_balance where ID = @new_client_id;
end
if @new_employee_id >= 0
begin
select @current_employee_balance = UserBalance from Users where ID = @new_employee_id;
set @final_employee_balance = @current_employee_balance + @new_order_price;
update Users set UserBalance = @final_employee_balance where ID = @new_employee_id;
end
end
if (@old_order_status != 0 and @old_order_status != 1 and @old_order_status = 2 and @old_order_status != 9)
and (@new_order_status = 7 or @new_order_status = 8 and @new_order_status != 9)
begin
if @new_client_id >= 0
begin
select @current_client_balance = UserBalance from Users where ID = @new_client_id;
set @final_client_balance = @current_client_balance + @new_order_price;
update Users set UserBalance = @final_client_balance where ID = @new_client_id;
end
if @new_employee_id >= 0
begin
select @current_employee_balance = UserBalance from Users where ID = @new_employee_id;
set @final_employee_balance = @current_employee_balance - @new_order_price;
update Users set UserBalance = @final_employee_balance where ID = @new_employee_id;
end
end
if (@old_order_status != 9 or @old_order_status = 0 or @old_order_status = 1 or @old_order_status = 3 or @old_order_status = 2 or @old_order_status != 7 or @old_order_status != 8)
and (@new_order_status != 7 or @new_order_status != 8 or @new_order_status  = 9)
begin
if @new_client_id >= 0
begin
select @current_client_balance = UserBalance from Users where ID = @new_client_id;
set @final_client_balance = @current_client_balance - @new_order_price;
update Users set UserBalance = @final_client_balance where ID = @new_client_id;
end
if @new_employee_id >= 0
begin
select @current_employee_balance = UserBalance from Users where ID = @new_employee_id;
set @final_employee_balance = @current_employee_balance + @new_order_price;
update Users set UserBalance = @final_employee_balance where ID = @new_employee_id;
end
if @new_product_id >= 0
begin
select @current_product_quantity = ProductQuantity from Products where ID = @new_product_id;
set @final_product_quantity = @current_product_quantity - @new_desired_quantity;
update Products set ProductQuantity = @final_product_quantity where ID = @new_product_id;
end
end
set @additional_information = 'Old Order ID: ' + try_cast(@old_id as varchar) + '\n' + 'Old Product ID: ' + try_cast(@old_product_id as varchar) + '\n' +
'Old Desired Quantity: ' + try_cast(@old_desired_quantity as varchar) + '\n' + 'Old Price: ' + try_cast(@old_order_price as varchar) + '\n' +
'Old Client ID: ' + try_cast(@old_client_id as varchar) + '\n' + 'Old Employee ID: ' + try_cast(@old_employee_id as varchar) + '\n' + 
'Old Date Added: ' + try_cast(@old_date_added as varchar) + '\n' + 'Old Date Modified: ' + try_cast(@old_date_modified as varchar) + '\n' +
'Old Status ID: ' + try_cast(@old_order_status as varchar) + '\n' + 'Old Reason: ' + try_cast(@old_order_reason as varchar) + '\n' + 
'New Order ID: ' + try_cast(@new_id as varchar) + '\n' + ' New Product ID: ' + try_cast(@new_product_id as varchar) + '\n' +
'New Desired Quantity: ' + try_cast(@new_desired_quantity as varchar) + '\n' + 'New Price: ' + try_cast(@new_order_price as varchar) + '\n' +
'New Client ID: ' + try_cast(@new_client_id as varchar) + '\n' + 'New Employee ID: ' + try_cast(@new_employee_id as varchar) + '\n' + 
'New Date Added: ' + try_cast(@new_date_added as varchar) + '\n' + 'New Date Modified: ' + try_cast(@new_date_modified as varchar) + '\n' +
'New Status ID: ' + try_cast(@new_order_status as varchar) + '\n' + 'New Reason: ' + try_cast(@new_order_reason as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Product Order Updated', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger ProductOrders_OnDelete on ProductOrders for delete
as
begin
set nocount on;
declare @old_id as int;
declare @old_product_id as int;
declare @old_desired_quantity as int;
declare @old_order_price as money;
declare @old_client_id as int;
declare @old_employee_id as int;
declare @old_date_added as date;
declare @old_date_modified as date;
declare @old_order_status as int;
declare @old_order_reason as varchar(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @old_id = ID from deleted;
select @old_product_id = ProductID from deleted;
select @old_desired_quantity = DesiredQuantity from deleted;
select @old_order_price = OrderPrice from deleted;
select @old_client_id = ClientID from deleted;
select @old_employee_id = EmployeeID from deleted;
select @old_date_added = DateAdded from deleted;
select @old_date_modified = DateModified from deleted;
select @old_order_status = OrderStatus from deleted;
select @old_order_reason = OrderReason from deleted;
set @log_message = 'A product order was removed list with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Old Order ID: ' + try_cast(@old_id as varchar) + '\n' + 'Old Product ID: ' + try_cast(@old_product_id as varchar) + '\n' +
'Old Desired Quantity: ' + try_cast(@old_desired_quantity as varchar) + '\n' + 'Old Price: ' + try_cast(@old_order_price as varchar) + '\n' +
'Old Client ID: ' + try_cast(@old_client_id as varchar) + '\n' + 'Old Employee ID: ' + try_cast(@old_employee_id as varchar) + '\n' + 
'Old Date Added: ' + try_cast(@old_date_added as varchar) + '\n' + 'Old Date Modified: ' + try_cast(@old_date_modified as varchar) + '\n' +
'Old Status ID: ' + try_cast(@old_order_status as varchar) + '\n' + 'Old Reason: ' + try_cast(@old_order_reason as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date,
@logtitle='[XTremePharmacyDB] Product Order Removed', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go
/* the order deliveries triggers will be the same as the product orders and there will be a Hell to pay */
go
create or alter trigger OrderDeliveries_OnAdd on OrderDeliveries for insert
as
begin
set nocount on;
declare @new_id as int;
declare @new_order_id as int;
declare @new_service_id as int;
declare @new_method_id as int;
declare @new_total_price as money;
declare @new_date_added as date;
declare @new_date_modified as date;
declare @new_delivery_status as int;
declare @new_delivery_reason as varchar(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
declare @current_date as date;
select @new_id = ID from inserted;
select @new_order_id = OrderID from inserted;
select @new_service_id = DeliveryServiceID from inserted;
select @new_method_id = PaymentMethodID from inserted;
select @new_total_price = TotalPrice from inserted;
select @new_date_added = DateAdded from inserted;
select @new_date_modified = DateModified from inserted;
select @new_delivery_status = DeliveryStatus from inserted;
select @new_delivery_reason = DeliveryReason from inserted;
set @log_message = 'An order delivery was added to the list with the id: ' + try_cast(@new_id as varchar);
set @additional_information = 'Delivery ID: ' + try_cast(@new_id as varchar) + '\n' + 'Order ID: ' + try_cast(@new_order_id as varchar) + '\n' +
'Delivery Service ID: ' + try_cast(@new_service_id as varchar) + '\n' + 'Payment Method ID: ' + try_cast(@new_method_id as varchar) + '\n' +
'Total Price: ' + try_cast(@new_total_price as varchar) + '\n' + 'Date Added: ' + try_cast(@new_date_added as varchar) + '\n' +
'Date Modified: ' + try_cast(@new_date_modified as varchar) + '\n' + 'Delivery Status ID: ' + try_cast(@new_delivery_status as varchar) + '\n' +
'Delivery Reason: ' + try_cast(@new_delivery_reason as varchar) + '\n';
set @current_date = getdate();
exec AddLog @logdate = @current_date, 
@logtitle='[XTremePharmacyDB] Order Delivery Added', 
@logmessage = @log_message,
@additionalinformation = @additional_information;
end
go

go
create or alter trigger OrderDeliveries_OnUpdate on OrderDeliveries for update
as
begin
set nocount on;
declare @old_id as int;
declare @new_id as int;
declare @old_order_id as int;
declare @new_order_id as int;
declare @old_service_id as int;
declare @new_service_id as int;
declare @old_method_id as int;
declare @new_method_id as int;
declare @old_total_price as int;
declare @new_total_price as money;
declare @old_date_added as date;
declare @new_date_added as date;
declare @old_date_modified as date;
declare @new_date_modified as date;
declare @old_delivery_status as int;
declare @new_delivery_status as int;
declare @old_delivery_reason as varchar(max);
declare @new_delivery_reason as varchar(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
select @old_id = ID from deleted;
select @new_id = ID from inserted;
select @old_order_id = OrderID from deleted;
select @new_order_id = OrderID from inserted;
select @old_service_id = DeliveryServiceID from deleted;
select @new_service_id = DeliveryServiceID from inserted;
select @old_method_id = PaymentMethodID from deleted;
select @new_method_id = PaymentMethodID from inserted;
select @old_total_price = TotalPrice from deleted;
select @new_total_price = TotalPrice from inserted;
select @old_date_added = DateAdded from deleted;
select @new_date_added = DateAdded from inserted;
select @old_date_modified = DateModified from deleted;
select @new_date_modified = DateModified from inserted;
select @old_delivery_status = DeliveryStatus from deleted;
select @new_delivery_status = DeliveryStatus from inserted;
select @old_delivery_reason = DeliveryReason from deleted;
select @new_delivery_reason = DeliveryReason from inserted;
set @log_message = 'An order delivery was updated with the id: ' + try_cast(@old_id as varchar);
/* set the updated order deliveries and orders based on the delivery status */
/* let's make a cheatsheet for statuses so it will be easier for us to tell the delivery what to do on each status */
/*
0 - pending delivery
1 - prepaid
2 - directly paid
3 - paid on delivery
4 - generating invoice
5 - generating report
6 - on the move
7 - cancelled delivery
8 - returned delivery
9 - delivery completed
*/
declare @current_delivery_price as money; /* current delivery price from the delivery service assigned to the delivery */
declare @current_client_id as int; /* current client assigned to the order that is assigned to that delivery */
declare @current_client_balance as money /* current client balance from the order that the delivery is assigned to */
declare @final_client_balance as money /* final client balance after the delivery price is paid */
if (@old_delivery_status = 1 or @old_delivery_status = 2 and @old_delivery_status != 3 and
@old_delivery_status != 7 and @old_delivery_status != 8 and @old_delivery_status != 9) 
and ( @new_delivery_status = 1 or @new_delivery_status = 1 and @new_delivery_status != 3
and @new_delivery_status != 7 and @new_delivery_status != 8 and @new_delivery_status != 9)
begin
select @current_delivery_price = ServicePrice from DeliveryServices where ID = @new_service_id;
select @current_client_id = ClientID from ProductOrders where ID = @new_order_id;
select @current_client_balance = UserBalance from Users where ID = @current_client_id;
set @final_client_balance = @current_client_balance - @current_delivery_price;
update Users set UserBalance = @final_client_balance where ID = @current_client_id;
update ProductOrders set OrderStatus = 6 where ID = @new_order_id;
end
if (@old_delivery_status != 1 and @old_delivery_status != 2 and @old_delivery_status = 3 and
@old_delivery_status != 7 and @old_delivery_status != 8 and @old_delivery_status != 9) 
and ( @new_delivery_status != 1 and @new_delivery_status != 1 and @new_delivery_status = 3
and @new_delivery_status != 7 and @new_delivery_status != 8 and @new_delivery_status != 9)
begin
select @current_delivery_price = ServicePrice from DeliveryServices where ID = @new_service_id;
select @current_client_id = ClientID from ProductOrders where ID = @new_order_id;
select @current_client_balance = UserBalance from Users where ID = @current_client_id;
set @final_client_balance = @current_client_balance - @current_delivery_price;
update Users set UserBalance = @final_client_balance where ID = @current_client_id;
update ProductOrders set OrderStatus = 6 where ID = @new_order_id;
end
if (@old_delivery_status != 1 and @old_delivery_status != 2 and @old_delivery_status != 3 and
@old_delivery_status != 7 and @old_delivery_status != 8 and @old_delivery_status = 9) 
and ( @new_delivery_status != 1 or @new_delivery_status != 1 and @new_delivery_status != 3
and @new_delivery_status != 7 and @new_delivery_status != 8 and @new_delivery_status = 9)
begin
select @current_delivery_price = ServicePrice from DeliveryServices where ID = @new_service_id;
select @current_client_id = ClientID from ProductOrders where ID = @new_order_id;
select @current_client_balance = UserBalance from Users where ID = @current_client_id;
set @final_client_balance = @current_client_balance - @current_delivery_price;
update Users set UserBalance = @final_client_balance where ID = @current_client_id;
update ProductOrders set OrderStatus = 9 where ID = @new_order_id;
end
if (@old_delivery_status != 1 and @old_delivery_status != 2 and @old_delivery_status != 3 and
@old_delivery_status != 7 and @old_delivery_status != 8 and @old_delivery_status = 9) 
and ( @new_delivery_status != 1 or @new_delivery_status != 1 and @new_delivery_status != 3
and @new_delivery_status = 7 and @new_delivery_status != 8 and @new_delivery_status = 9)
begin
select @current_delivery_price = ServicePrice from DeliveryServices where ID = @new_service_id;
select @current_client_id = ClientID from ProductOrders where ID = @new_order_id;
select @current_client_balance = UserBalance from Users where ID = @current_client_id;
set @final_client_balance = @current_client_balance + @current_delivery_price;
update Users set UserBalance = @final_client_balance where ID = @current_client_id;
update ProductOrders set OrderStatus = 7 where ID = @new_order_id;
end
if (@old_delivery_status != 1 and @old_delivery_status != 2 and @old_delivery_status != 3 and
@old_delivery_status != 7 and @old_delivery_status != 8 and @old_delivery_status = 9) 
and ( @new_delivery_status != 1 or @new_delivery_status != 1 and @new_delivery_status != 3
and @new_delivery_status != 7 and @new_delivery_status = 8 and @new_delivery_status = 9)
begin
select @current_delivery_price = ServicePrice from DeliveryServices where ID = @new_service_id;
select @current_client_id = ClientID from ProductOrders where ID = @new_order_id;
select @current_client_balance = UserBalance from Users where ID = @current_client_id;
set @final_client_balance = @current_client_balance + @current_delivery_price;
update Users set UserBalance = @final_client_balance where ID = @current_client_id;
update ProductOrders set OrderStatus = 8 where ID = @new_order_id;
end
set @additional_information = 'Old Delivery ID: ' + try_cast(@old_id as varchar) + '\n' + 'Old Order ID: ' + try_cast(@old_order_id as varchar) + '\n' +
'Old Delivery Service ID: ' + try_cast(@old_service_id as varchar) + '\n' + 'Old Payment Method ID: ' + try_cast(@old_method_id as varchar) + '\n' +
'Old Total Price: ' + try_cast(@old_total_price as varchar) + '\n' + 'Old Date Added: ' + try_cast(@old_date_added as varchar) + '\n' +
'Old Date Modified: ' + try_cast(@old_date_modified as varchar) + '\n' + 'Old Delivery Status ID: ' + try_cast(@old_delivery_status as varchar) + '\n' +
'Old Delivery Reason: ' + try_cast(@old_delivery_reason as varchar) + '\n' +
'New Delivery ID: ' + try_cast(@new_id as varchar) + '\n' + 'New Order ID: ' + try_cast(@new_order_id as varchar) + '\n' +
'New Delivery Service ID: ' + try_cast(@new_service_id as varchar) + '\n' + 'New Payment Method ID: ' + try_cast(@new_method_id as varchar) + '\n' +
'New Total Price: ' + try_cast(@new_total_price as varchar) + '\n' + 'New Date Added: ' + try_cast(@new_date_added as varchar) + '\n' +
'New Date Modified: ' + try_cast(@new_date_modified as varchar) + '\n' + 'New Delivery Status ID: ' + try_cast(@new_delivery_status as varchar) + '\n' +
'New Delivery Reason: ' + try_cast(@new_delivery_reason as varchar) + '\n';
exec AddLog @logdate = getdate, 
@logtitle='[XTremePharmacyDB] Order Delivery Updated', 
@logmessage = @log_message,
@additionalloginformation = @additional_information;
end
go

go
create or alter trigger OrderDeliveries_OnDelete on OrderDeliveries for delete
as
begin
set nocount on;
declare @old_id as int;
declare @new_id as int;
declare @old_order_id as int;
declare @new_order_id as int;
declare @old_service_id as int;
declare @new_service_id as int;
declare @old_method_id as int;
declare @new_method_id as int;
declare @old_total_price as int;
declare @new_total_price as money;
declare @old_date_added as date;
declare @new_date_added as date;
declare @old_date_modified as date;
declare @new_date_modified as date;
declare @old_delivery_status as int;
declare @new_delivery_status as int;
declare @old_delivery_reason as varchar(max);
declare @new_delivery_reason as varchar(max);
declare @log_message as varchar(max);
declare @additional_information as varchar(max);
select @old_id = ID from deleted;
select @old_order_id = OrderID from deleted;
select @old_service_id = DeliveryServiceID from deleted;
select @old_method_id = PaymentMethodID from deleted;
select @old_total_price = TotalPrice from deleted;
select @old_date_added = DateAdded from deleted;
select @old_date_modified = DateModified from deleted;
select @old_delivery_status = DeliveryStatus from deleted;
select @old_delivery_reason = DeliveryReason from deleted;
set @log_message = 'An order delivery was removed list with the id: ' + try_cast(@old_id as varchar);
set @additional_information = 'Old Delivery ID: ' + try_cast(@old_id as varchar) + '\n' + 'Old Order ID: ' + try_cast(@old_order_id as varchar) + '\n' +
'Old Delivery Service ID: ' + try_cast(@old_service_id as varchar) + '\n' + 'Old Payment Method ID: ' + try_cast(@old_method_id as varchar) + '\n' +
'Old Total Price: ' + try_cast(@old_total_price as varchar) + '\n' + 'Old Date Added: ' + try_cast(@old_date_added as varchar) + '\n' +
'Old Date Modified: ' + try_cast(@old_date_modified as varchar) + '\n' + 'Old Delivery Status ID: ' + try_cast(@old_delivery_status as varchar) + '\n' +
'Old Delivery Reason: ' + try_cast(@old_delivery_reason as varchar) + '\n';
exec AddLog @logdate = getdate, 
@logtitle='[XTremePharmacyDB] Order Delivery Removed', 
@logmessage = @log_message,
@additionalloginformation = @additional_information;
end
go
 /*  logon trigger so we can gatekeep the logins and prevent any logins from users that haven't been registered in the database */
 /* first time I am doing such a trigger so I did some research on our good world wide web to do it */
 go
 create or alter trigger XPDB_OnLogon on all server for logon
 as
 begin
 if db_id('XTremePharmacyDB') is not null
 begin
 declare @success_message as varchar(max);
 declare @failed_message  as varchar(max);
 declare @found_user_id as int;
 declare @logmessage as varchar(max);
 declare @additionalloginformation as varchar(max);
 declare @current_date as date;
 set @current_date = getdate();
 set @success_message ='Welcome, ' + original_login() + '.';
 set @failed_message = 'Sorry, ' + original_login() + ' you aren''t allowed to access the database.\nPossible unauthorised login so access denied.\n
 Please ask an existing user to register you.';
 print original_login();
 set @found_user_id = -1;
 select @found_user_id = ID from XTremePharmacyDB.dbo.Users where UserName = original_login();
 /* let's check what the found user id returns, if it is above 0 the user is valid and not a dummy so we authorise access */
 if @found_user_id >0 /* on success give a message with an ID */
 begin
 print @success_message;
 set @logmessage = 'User ' + original_login() + 'has logged in successfully.';
 set @additionalloginformation = 'Host Name: ' + HOST_NAME() + '\n';
 exec XTremePharmacyDB.dbo.AddLog @logdate=getdate,
 @logtitle='[XTremePharmacyDB] User login',
 @logmessage = @logmessage,
 @additionalloginformation= @additionalloginformation;
 end
 else /* on failure send the failure message and rollback the login, a.k.a. deny access */
 begin
 print @failed_message;
 set @logmessage = 'User ' + original_login() + 'has failed to login.';
 set @additionalloginformation = 'Host Name: ' + HOST_NAME() + '\n';
 exec XTremePharmacyDB.dbo.AddLog @logdate=@current_date,
 @logtitle='[XTremePharmacyDB] User login',
 @logmessage = @logmessage,
 @additionalinformation= @additionalloginformation;
 rollback;
 end
 end
 end
 go

/* now disable the trigger when the current used database is not our database */
go
if db_name() = 'XTremePharmacyDB'
begin
enable trigger XPDB_OnLogon on all server;
end
else
begin
disable trigger XPDB_OnLogon on all server;
end
go

select * from Logs;
select * from Users;