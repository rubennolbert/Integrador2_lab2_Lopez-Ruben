create database ATLETAS_TEST_DB;
GO
use ATLETAS_TEST_DB;

create table atletas(
DNI int primary key not null,
NOMBRE varchar(100) not null,
APELLIDO varchar(100) not null,
FECHA_NACIMIENTO date not null,
PASE int not null,
)

create table cuotas(
ID_CUOTA int identity primary key,
METODO_DE_PAGO int not null,
PASE int not null,
IMPORTE int not null,
FECHA_CUOTA date not null,
DNI int foreign key references atletas(dni) not null,
)

insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (38808854, 'Willem', 'Major', '2022-05-28', 0);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (75727366, 'Martha', 'Eliasson', '2022-03-22', 1);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (63629527, 'Agneta', 'Buer', '2021-12-05', 1);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (16675451, 'Darin', 'Cowndley', '2021-06-26', 0);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (44266700, 'Karlan', 'Henden', '2022-05-11', 0);

insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (69462045, 'Yasmin', 'Prendiville', '2022-03-21', 1);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (49094246, 'Evania', 'Robers', '2022-03-09', 0);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (43609717, 'Eustacia', 'Matyas', '2022-01-27', 0);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (56099390, 'Ardenia', 'Loy', '2021-09-05', 1);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (43258440, 'Jess', 'Clemmensen', '2022-03-09', 0);

insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (97977736, 'Tate', 'Wickie', '2022-04-04', 1);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (10077647, 'Dannie', 'Morrilly', '2021-09-16', 0);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (45578223, 'Noami', 'Abrahmer', '2021-07-26', 1);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (52975132, 'Kingsly', 'Rotlauf', '2021-06-21', 0);
insert into ATLETAS (DNI, nombre, apellido, fecha_nacimiento, pase) values (62304520, 'Kermy', 'Gonthier', '2022-02-18', 0);

insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (1, 0, 2971, '2022-05-01', 38808854);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (1, 1, 2195, '2022-05-01', 75727366);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 1, 4379, '2022-05-01', 63629527);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (1, 0, 3981, '2022-05-01', 16675451);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (3, 0, 3898, '2022-05-01', 44266700);

insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (1, 1, 4485, '2022-05-01', 69462045);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (3, 1, 4913, '2022-05-01', 49094246);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 0, 3326, '2022-05-01', 43609717);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 1, 2933, '2022-05-01', 56099390);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 0, 3744, '2022-05-01', 43258440);

insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 1, 2645, '2022-05-01', 97977736);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 1, 4869, '2022-05-01', 10077647);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (1, 0, 3134, '2022-05-01', 45578223);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (3, 0, 2930, '2022-05-01', 52975132);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 1, 2222, '2022-05-01', 62304520);

insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 1, 2800, '2022-06-01', 38808854);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 0, 2674, '2022-06-01', 75727366);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (1, 1, 2386, '2022-06-01', 63629527);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (1, 1, 2356, '2022-06-01', 16675451);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (3, 1, 4791, '2022-06-01', 44266700);

insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 1, 2800, '2022-04-01', 38808854);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (0, 0, 2674, '2022-04-01', 75727366);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (1, 1, 2386, '2022-04-01', 63629527);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (1, 1, 2356, '2022-04-01', 16675451);
insert into CUOTAS (metodo_de_pago, pase, importe, fecha_cuota, dni) values (3, 1, 4791, '2022-04-01', 44266700);  