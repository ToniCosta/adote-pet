# Adote Pet [PI SENAC]
### Autores
Grupo 01
- Antônio Simões da Costa Neto
- Eduardo Ribeiro Azevedo
- Elton Douglas Souza
- Felipe Carneiro dos Anjos
- Vinícius Dumbra


## Sobre o projeto

O sistema Adote Pet tem como proposta facilitar o processo de adoção de um pet, disponibilizando uma lista de pets cadastrados por ONGs/protetores de todo o brasil. Nós fazemos a ponte para que cães e gatos encontrem um novo lar todos os dias.
A aplicação tem três papéis: 
- O administrador do sistema, representante do Adote Pert e responsável por conferir a documentação enviada pelas ONGs
- O representante das ONGs/Instituições (pessoas jurídicas), que são os responsáveis por cadastrar os pets para adoção e revisar a documentação de quem pretende adotar um pet
- Os tutores, pessoas físicas que desejam adotar os pets.

Atualmente, os fluxos de controle desses cadastros e validações estão parcialmente implementados.
Outro ponto importante é que o sistema conta com georeferenciamento, através de API do Mapbox, isso é utilizado para buscar os pets para adoção mais próximos do tutor.

<hr />

## Ambiente de demonstração
O sistema está disponível para ser acessado e testado na url https://adotepet.app.
Você pode se cadastrar como um tutor ou com uma ong/instituição.

Há uma pequena quantidade de ongs, tutores e pets cadastrados que podem ser usados para teste do ambiente de domonstração.
#### Cadastros de Ongs com dados
- Email: ong1@teste.com / Senha: 123456
- Email: ong2@teste.com / Senha: 123456
- Email: ong3@teste.com / Senha: 123456
- Email: ong4@teste.com / Senha: 123456

#### Cadastros de Tutores com dados
- Email: tutor1@teste.com / Senha: 123456
- Email: tutor2@teste.com / Senha: 123456

<hr />

## Tecnologias Utilizadas
### Banco de dados
- MySQL 8

### Backend
- API C# / NetCore 6

### Frontend
- Framework reativo Vue.js versão 2.6
- Pacote de componentes de UI Vuetify

### IDEs
Para o frontend utilizamos o Visual Studio Code e para o backend foi utilizado o Visual Studio Community 2022.
Para manipulação dos scripts de banco de dados usamos o gerenciador de banco de dados DBeaver Community.

Todas essas ferramentas são gratuítas para uso.

## Estrutura de pastas do projeto
O projeto está divido em algumas pastas:
- **api**: Pasta onde está a aplicação C# NetCore (a API).
- **app**: Pasta onde está a aplicação frontend vuejs.
- **docker**: Pasta com um docker-compose para subir a API e o APP na estrutura onde a aplicação foi implantada para demonstração.
- **sql**: Pasta contendo os scripts de banco de dados para iniciar a instância da aplicação. Deve ser executada na ordem numerada no nome dos arquivos.

<hr />

## Como executar o projeto
### Clonar repositório
O primeiro passo é clonar o repositório para a sua máquina, para isso é necessário que o GIT esteja instalado em sua máquina.
Execute o comando de clonagem do repositório:

```bash
$ git clone https://github.com/ToniCosta/adote-pet.git
```

### Banco de dados
Deve ser criado um banco de dados mysql (versão 8). O nome do banco, usuário e senha são a seu critério.
Após criado o banco de dados, executar os scripts abaixo (na ordem apresentada):
- sql/01.tabelas.sql
- sql/02.dados_iniciais.sql
- sql/03.cidades.sql

### API (backend)
Para executar a API você deve primeirament instalar a SDK do netcore 6.
Você encontra instruções de como instalar em windows, linux e mac os na url abaixo:
https://docs.microsoft.com/pt-br/dotnet/core/install/windows?tabs=net60

Antes de executar o projeto, você deverá ajustar a string de conexão, com os dados do banco de dados que você criou anteriormente. O arquivo a ser editado é **api/appsettings.Development.json**:
```json
{
  "ConnectionStrings": {
    "mysql": "Server={HOST};Port={POST};Database={NOME BANCO};Uid={USUARIO BANCO};Pwd={SENHA BANCO};"
  },
  "FilesPath": "/var/uploads",
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```
Para executar a API, abra um prompt de comando e, a partir da pasta **api**, digite:
 ```bash
 $ dotnet run
 ```
 Isso executará um servidor web local que responderá em http://localhost:5000

### Frontend
Para executar a aplicação de frontend é necessário que a máquina possua o node js versão 16 instalado. Mais informações e o instalador você encontra em https://nodejs.org.

Os comandos abaixo devem ser executados a partir da pasta **app**.

Primeiro, você deve instalar as dependências do projeto, através do comando (esse comando pode demorar um pouco para ser executado):
```bash
$ npm install
``` 

Após instalado as dependências do projeto, você vai executá-lo através do comando:
```bash
$ npm run serve
```
Se tudo deu certo, você poderá acessar a aplicação através de URL http://localhost:8080

