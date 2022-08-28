
DELIMITER $$

DROP PROCEDURE IF EXISTS preencher_dados_iniciais $$

CREATE PROCEDURE preencher_dados_iniciais () 
    BEGIN
	    if not exists (select * from usuarios) then
	    	insert into usuarios (id, nome, login, email, senha, tipo)
	    	values (1, 'Teste Tutor', 'tutor', 'tutor@teste.com', md5('1234567'), 'TUTOR');
	    
	    	insert into tutores (usuario_id, idade, sexo, estado_civil)
	    	values (1, 25, 'Masculino', 'Solteiro');
	    end if;
	    
	    if not exists (select * from tipos_animais) then
	    	insert into tipos_animais (id, descricao)
	    	values 
	    	(1, 'Cachorro'), 
	    	(2, 'Gato');
	    end if;
	   
	   if not exists (select * from racas_animais where tipo_animal_id = 1) then
	    	insert into racas_animais (tipo_animal_id, descricao)
	    	values 
	    	(1, 'Akita'),
			(1, 'Basset hound'),
			(1, 'Beagle'),
			(1, 'Bichon frisé'),
			(1, 'Boiadeiro australiano'),
			(1, 'Border collie'),
			(1, 'Boston terrier'),
			(1, 'Boxer'),
			(1, 'Buldogue francês'),
			(1, 'Buldogue inglês'),
			(1, 'Bull terrier'),
			(1, 'Cane corso'),
			(1, 'Cavalier king charles spaniel'),
			(1, 'Chihuahua'),
			(1, 'Chow chow'),
			(1, 'Cocker spaniel inglês'),
			(1, 'Dachshund'),
			(1, 'Dálmata'),
			(1, 'Doberman'),
			(1, 'Dogo argentino'),
			(1, 'Dogue alemão'),
			(1, 'Fila brasileiro'),
			(1, 'Golden retriever'),
			(1, 'Husky siberiano'),
			(1, 'Jack russell terrier'),
			(1, 'Labrador retriever'),
			(1, 'Lhasa apso'),
			(1, 'Lulu da pomerânia'),
			(1, 'Maltês'),
			(1, 'Mastiff inglês'),
			(1, 'Mastim tibetano'),
			(1, 'Pastor alemão'),
			(1, 'Pastor australiano'),
			(1, 'Pastor de Shetland'),
			(1, 'Pequinês'),
			(1, 'Pinscher'),
			(1, 'Pit bull'),
			(1, 'Poodle'),
			(1, 'Pug'),
			(1, 'Rottweiler'),
			(1, 'Schnauzer'),
			(1, 'Shar-pei'),
			(1, 'Shiba'),
			(1, 'Shih tzu'),
			(1, 'Staffordshire bull terrier'),
			(1, 'Weimaraner'),
			(1, 'Yorkshire'),
			(1, 'Sem raça definida');
	    end if;
	   
	   if not exists (select * from racas_animais where tipo_animal_id = 2) then
	    	insert into racas_animais (tipo_animal_id, descricao)
	    	values 
	    	(2, 'Abissínio'),
			(2, 'Angorá turco'),
			(2, 'Asiático de Pelo Semi-Longo'),
			(2, 'Azul Russo'),
			(2, 'Balinês'),
			(2, 'Bambino'),
			(2, 'Bicolor Oriental'),
			(2, 'Bobtail americano'),
			(2, 'Bobtail japonês'),
			(2, 'Bombaim'),
			(2, 'Burmês'),
			(2, 'Burmila'),
			(2, 'California Spangled'),
			(2, 'Cingapura'),
			(2, 'Chartreux'),
			(2, 'Chausie'),
			(2, 'Colorpoint de pelo curto'),
			(2, 'Cornish Rex'),
			(2, 'Curl Americano'),
			(2, 'Devon Rex'),
			(2, 'Donskoy'),
			(2, 'Dragon Li'),
			(2, 'Egeu'),
			(2, 'Gato-de-Bengala'),
			(2, 'Gato do Chipre'),
			(2, 'Exótico'),
			(2, 'Gato asiático'),
			(2, 'Gato Siberiano'),
			(2, 'Havana marrom'),
			(2, 'Himalaio'),
			(2, 'Javanês'),
			(2, 'Korat'),
			(2, 'Khao Manee'),
			(2, 'Kurilian Bobtail'),
			(2, 'LaPerml'),
			(2, 'Levkoy ucraniano'),
			(2, 'Lykoi'),
			(2, 'Maine Coon'),
			(2, 'Manx'),
			(2, 'Manx de pelo longo'),
			(2, 'Mau Árabe'),
			(2, 'Mau egípcio'),
			(2, 'Minskin'),
			(2, 'Mist Australiano'),
			(2, 'Munchkin'),
			(2, 'Nebelung'),
			(2, 'Norueguês da Floresta'),
			(2, 'Ocicat'),
			(2, 'Ojos Azules'),
			(2, 'Oregon Rex'),
			(2, 'Pelo curto americano'),
			(2, 'Pelo curto brasileiro'),
			(2, 'Pelo curto Europeu'),
			(2, 'Pelo curto inglês'),
			(2, 'Pelo longo Inglês'),
			(2, 'Pelo curto Oriental'),
			(2, 'Pelo longo Oriental'),
			(2, 'Persa'),
			(2, 'Peterbald'),
			(2, 'Pixie-bob'),
			(2, 'Raas'),
			(2, 'Ragamuffin'),
			(2, 'Ragdoll'),
			(2, 'Rex Alemão'),
			(2, 'Sagrado da Birmânia'),
			(2, 'Savannah'),
			(2, 'Scottish Fold'),
			(2, 'Selkirk Rex'),
			(2, 'Serengeti'),
			(2, 'Siamês'),
			(2, 'Singapura'),
			(2, 'Snowshoe'),
			(2, 'Sokoke'),
			(2, 'Somali'),
			(2, 'Sphynx'),
			(2, 'Suphalak'),
			(2, 'Thai'),
			(2, 'Tiffany-Chantilly'),
			(2, 'Tonquinês'),
			(2, 'Toyger'),
			(2, 'Van Turco'),
			(2, 'Wirehair Americano'),
			(2, 'Sem raça definida');
	    end if;
    END $$

DELIMITER ;

CALL preencher_dados_iniciais();

drop procedure preencher_dados_iniciais;