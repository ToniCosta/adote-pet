/*
    drop table racas_animais;
    drop table tipos_animais;
    drop table tutores;
	drop table usuarios;
*/
create table if not exists usuarios (
	id        int auto_increment not null,

	nome      varchar(255) not null,
	login     varchar(255) not null,
	email     varchar(255) not null,
	senha     varchar(255) not null,
	tipo      varchar(20) not null,

	primary key pk_usuarios (id),
	CHECK (tipo in ('ADMIN', 'TUTOR', 'INSTITUICAO'))
);


create table if not exists tipos_animais (
	id        int not null,
	descricao varchar(100) not null,
	primary key pk_tipo_animal (id)
);


create table if not exists racas_animais (
	id             int auto_increment not null,
	tipo_animal_id int not null,
	descricao      varchar(100) not null,
	primary key pk_raca_animal (id),
	foreign key fk_raca_animal_tipo (tipo_animal_id) references tipos_animais (id)
);


create table if not exists tutores (
	id                  int auto_increment not null,

	usuario_id          int not null,
	idade               int null,
	sexo                varchar(30) null,
	estado_civil        varchar(30) null,
	rg                  varchar(30) null,
	cpf                 varchar(11) null,
	qtd_pessoas_reside  int null,
	
	logradouro          varchar(255) null,
	numero              varchar(255) null,
	complemento         varchar(255) null,
	bairro              varchar(255) null,
	cidade              varchar(255) null,
	uf                  varchar(2) null,
	cep              varchar(15) null,
	possui_area_lazer   varchar(500) null,
	veterinario_proximo varchar(500) null,
	tipo_residencia     varchar(25) null,


	primary key pk_tutores (id),
	foreign key fk_tutor_usuario (usuario_id) references usuarios (id),
	CHECK (sexo in ('Masculino', 'Feminino', 'Não informar')),
	CHECK (estado_civil in ('Solteiro', 'Casado', 'União estável', 'Viúvo', 'Separado'))
);


