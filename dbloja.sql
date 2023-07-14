drop database dbLojaABC;

create database dbLojaABC;
use dbLojaABC;

create table tbFuncionarios(
codigo int not null auto_increment,
nome varchar(100),
cpf char(14) not null unique,
dataNasc date,
endereco varchar(100),
numero char(10),
bairro varchar(100),
cidade varchar(100),
siglaEst char(2),
cep char(9),
primary key(codigo));

insert into tbFuncionarios(nome,cpf,dataNasc,endereco,numero,bairro,cidade,siglaEst,cep)values();

show databases;

desc tbFuncionarios;

select * from tbFuncionarios;
