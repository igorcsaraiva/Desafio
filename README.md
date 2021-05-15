<h1 align="center">Desafio</h1>

<p align="center">Api to register a user and recommend songs based on hometown.</p>

<h4 align="center"> 
	🚧  Desafio 🚀 Finalizado...  🚧
</h4>

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Docker](https://docs.docker.com/docker-for-windows/install/) se for Windows, [.Net Core 5](https://dotnet.microsoft.com/download).

### Descrição do desafio.

Business Rules
The API has to register these user's fields:
name;
email;
password;
personal notes (multiples);
hometown.
Personal notes and password shouldn't be visible on database.
Auth route should work with JWT method.
The API has to provide a reset and forgot password mechanism.
Log all requests for future auditory.
Based on hometown and its current temperature, you have to recommend a playlist as
follow:
if temperature (celcius) is above 30 degrees, suggests tracks for party;
in case temperature is between 15 and 30 degrees, suggests pop music tracks;
if it's a bit chilly (between 10 and 14 degrees), suggests rock music tracks.
otherwise, if it's freezing outside, suggests classical music tracks.

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

# Acesse a pasta Desafio.API do projeto no terminal/cmd
# execute o comando: dotnet publish -c Release

# Vá para a pasta Desafio
# execute o comando: docker-compose -f docker-compose.yml up

# A Api inciará na porta:80 - acesse <http://localhost:56504>

```
### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [.Net Core 5](https://dotnet.microsoft.com/download)
- [Docker](https://docs.docker.com/docker-for-windows/install/)
