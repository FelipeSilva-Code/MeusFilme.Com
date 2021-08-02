-- create database db_filme;

-- use db_filme;

-- create table tb_usuario(
-- 	id_usuario int primary key auto_increment,
--     nm_usuario varchar(100),
--     ds_email   varchar(60),
--     ds_senha   varchar(60),
--     ds_permissao varchar(30),
--     ds_foto		varchar(30)
-- );

-- create table tb_ator (
-- 	id_ator int primary key auto_increment,
--     nm_ator varchar(50),
--     ds_descricao varchar(50),
--     dt_nascimento date,
--     nm_pais varchar(20),
--     ds_foto	varchar(30)
-- );

-- create table tb_diretor (
-- 	id_diretor int primary key auto_increment,
--     nm_diretor varchar(50),
--     ds_descricao varchar(50),
--     dt_nascimento date,
--     nm_pais varchar(20),
--     ds_foto varchar(30)
-- );

-- create table tb_filme (
-- 	id_filme int primary key auto_increment,
--     fk_diretor int,
--     nm_filme varchar(50),
--     ds_descricao varchar(50),
--     dt_lancamento date,
--     ds_genero varchar(20),
--     nr_nota decimal(15, 2),
--     ds_lingua varchar(20),
--     ds_tipo varchar(10),
--     ds_foto varchar(30),
--     foreign key (fk_diretor) references tb_diretor (id_diretor) on delete cascade
-- );

-- create table tb_filme_ator (
-- 	id_filme_ator int primary key auto_increment,
--     fk_filme int,
--     fk_ator int,
--     nm_personagem varchar(50),
--     ds_foto	varchar(30),
-- 	foreign key (fk_filme) references tb_filme (id_filme) on delete cascade,
-- 	foreign key (fk_ator)  references tb_ator (id_ator) on delete cascade
-- );