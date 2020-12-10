create schema ventas;
use ventas;
create table usuario(
id int primary key auto_increment,
nombres varchar(150),
email varchar(150) unique,
edad varchar(3),
telefono char(30),
tipo_doc char(2),
numerodo char(20),
tipous char(1),
imagen_usuario varchar(1000) not null default 'targetblank.png',
password varchar(250)
);

create table productos(
id int primary key auto_increment,
nombre_producto varchar(40) not null,
precio_producto double not null,
descripcion_producto varchar(155) not null,
imagen_producto varchar(1000) not null default 'targetblank.png',
cantidad_producto varchar(1000) not null,
codigo_producto int not null,
foreign key(codigo_producto) references usuario(id)
);

create table carrito(
id int primary key auto_increment,
codigo_producto_carrito int not null,
cantidad_producto varchar(1000) not null,
id_comprador int not null,
foreign key(codigo_producto_carrito) references productos(id),
foreign key(id_comprador) references usuario(id)
);

create table productos_adquiridos(
id int primary key auto_increment,
fecha_de_compra datetime not null,
codigo_producto_adquirido int not null,
id_vendedor_producto int not null,
id_comprador_producto int not null,
nombre_producto_adquirido varchar(150) not null,
imagen_producto_adquirido varchar(1000) not null,
descripcion_producto_adquirido varchar(1000) not null,
precio_producto_adquirido double not null,
cantidad_producto_adquirido varchar(1000) not null,
valor_total_pagado double not null,
/*foreign key(codigo_producto_adquirido) references productos(id),*/
foreign key(id_vendedor_producto) references usuario(id),
foreign key(id_comprador_producto) references usuario(id)
);