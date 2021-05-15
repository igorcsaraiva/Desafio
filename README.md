<h1 align="center">Desafio</h1>

<p align="center">Microservice to register a user and recommend songs based on hometown.</p>

<h4 align="center"> 
	🚧  Desafio 🚀 Finalizado...  🚧
</h4>

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Docker](https://docs.docker.com/docker-for-windows/install/) se for Windows, [.Net Core 5](https://dotnet.microsoft.com/download).

### 🎲 Rodando o projeto no container 

```bash
# Clone este repositório
$ git clone <https://github.com/igorcsaraiva/Desafio.git>

# Crie uma conta no Spotify depois no link [Spotify](https://developer.spotify.com/) crie um app la sera fornecido um ClientID e um ClientSecret você usara essas duas 
#  informações para preencher no appsettings.json na parte onde se encontra o objeto Spotify.

# Crie uma conta no Openweathermap no link [Openweathermap](https://openweathermap.org) la será fornecido uma ApiKey você usara essas informação para preencher no 
# appsettings.json na parte onde se encontra o objeto OpenWeatherService

# Crie uma conta no SendGrid no link [SendGrid](https://sendgrid.com/) la será fornecido uma Key você usara essas informação para preencher no 
# appsettings.json na parte onde se encontra o objeto SendGrid

# Acesse a pasta do projeto no terminal/cmd
# \Desafio.API e execute o comando: dotnet publish -c Release

# Vá para a pasta server
# \Desafio e execute o comando: docker-compose -f docker-compose.yml up

# A Api inciará na porta:80 - acesse <http://localhost:56504>

```
### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [.Net Core 5](https://dotnet.microsoft.com/download)
- [Docker](https://docs.docker.com/docker-for-windows/install/)
