create table Users
(
id int primary key identity(1,1),
first_name varchar(17) not null,
user_email varchar(127) unique,
user_role varchar(17) not null,
user_passord varchar(17) not null
)
create table Category
(
id_category int primary key identity(1,1),
category_name varchar(50) 
) 

create table Product 
(
id_product int primary key identity(1,1),
id_category int not null,
name_product varchar(50) not null,
description_product varchar(127),
price_product int not null,
availability_product int not null, 
foreign key (id_category) references Category(id_category)
)

create table DescriptionP
(
id_product int,
id_customer int,
review_text varchar(527) null,
review_rating int not null,
foreign key (id_product) references Product(id_product),
foreign key (id_customer) references Users(id),
primary key (id_product, id_customer)
)

create table Cart 
(
id_cart int primary key identity(1,1),
id_customer int not null,
foreign key (id_customer) references Users(id)
)

create table CartItem
(
id_product int not null,
id_cart int not null,
quantity int not null,
price int, 
foreign key (id_product) references Product(id_product),
foreign key (id_cart) references Cart(id_cart),
primary key (id_product, id_cart)
)

create table Booking
(
id_booking int primary key identity(1,1), 
id_cart int not null,
price_booking int,
status_booking varchar(17) not null,
delivery_booking varchar(50) not null,
address_booking varchar(100) not null,
foreign key (id_cart) references Cart(id_cart)
)

create table Filters
(
id_category int primary key not null,
category_name varchar(50) not null,
colour varchar(50)  not null,
material varchar(50)  not null,
[tables] varchar(50)  not null,
chairs varchar(50)  not null,
beds varchar(50)  not null,
sofas varchar(50)  not null,
wardrobes varchar(50)  not null,
foreign key (id_category) references Category(id_category)
)

