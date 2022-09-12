/*
    drop table pets;
    drop table racas_animais;
    drop table tipos_animais;
    drop table tutores;
    drop table entidades;
	drop table usuarios;
*/
create table if not exists usuarios (
	id        int auto_increment not null,

	nome      varchar(255) not null,
	sobrenome varchar(255) null,
	telefone  varchar(255) null,
	email     varchar(255) not null,
	senha     varchar(255) not null,
	tipo      varchar(20) not null,

	cadastro_preenchido bool not null,

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
	cep                 varchar(15) null,

	possui_area_lazer   varchar(500) null,
	veterinario_proximo varchar(500) null,
	tipo_residencia     varchar(25) null,

	tipo_animal_id      int null,
	raca_id             int null,
	porte               varchar(255) null,
	motivo_adocao       varchar(1000) null,

	latitude            numeric(14, 12) null,
	longitude           numeric(14, 12) null,

	primary key pk_tutores (id),
	foreign key fk_tutor_usuario (usuario_id) references usuarios (id),
	foreign key fk_tutor_tp_animal (tipo_animal_id) references tipos_animais (id),
	foreign key fk_tutor_raca (raca_id) references racas_animais (id),
	CHECK (sexo in ('Masculino', 'Feminino', 'Não informar')),
	CHECK (estado_civil in ('Solteiro', 'Casado', 'União estável', 'Viúvo', 'Separado'))
);


create table if not exists entidades (
	id                  int auto_increment not null,
	usuario_id          int not null,
	
	nome_diretor        varchar(255) null,
	cnpj                varchar(14) null,
	cpf_diretor         varchar(11) null,
	logomarca           varchar(255) null,
	cartao_cnpj         varchar(255) null,
	
	logradouro          varchar(255) null,
	numero              varchar(255) null,
	complemento         varchar(255) null,
	bairro              varchar(255) null,
	cidade              varchar(255) null,
	uf                  varchar(2) null,
	cep                 varchar(15) null,
	cadastro_aprovado   bool not null default false,
	data_aprovacao      datetime null,

	primary key pk_entidades (id),
	foreign key fk_entidade_usuario (usuario_id) references usuarios (id)
);

-- drop table cidades
create table if not exists cidades (
	id    int auto_increment not null,
	uf    varchar(2) not null, 
	nome  varchar(255) not null,
	primary key pk_cidades (id)
);

-- drop table pets
create table if not exists pets (
	id             int auto_increment not null,
	entidade_id    int not null,
	nome           varchar(255) null,
	cor            varchar(255) null,
	tamanho_pelo   varchar(255) null,
	tipo_animal_id int null,
	raca_id        int null,
	porte          varchar(255) null,
	peso           int null,
	idade          int null,
	comportamento  varchar(500) null,
	localizacao    varchar(255) null,
	descricao      text null,
	foto           varchar(255) null,

	latitude       numeric(14, 12) null,
	longitude      numeric(14, 12) null,
	
	status_pet     varchar(50) null not null,
	tutor_id       int null,

	primary key pk_pets (id),
	foreign key fk_pets_entidade (entidade_id) references entidades (id),
	foreign key fk_pets_tipo (tipo_animal_id) references tipos_animais (id),
	foreign key fk_pets_raca (raca_id) references racas_animais (id),
	foreign key fk_pets_tutor (tutor_id) references tutores (id),
	CHECK (status_pet in ('Para adoção', 'Em processo de adoção', 'Adotado'))
);

