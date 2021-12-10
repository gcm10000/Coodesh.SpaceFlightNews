# Desafio Coodesh
## Descrição: API pública com informações relacionadas a voos espaciais

Linguagem:

• C#

Frameworks:

• .NET Core 3.1

• AutoMapper

• Entity Framework Core

• Swagger

• Quartz

• Moq

Banco de dados:

• PostgreSQL hospedado em Heroku


****

Para baixar e instalar é necessário que tenha [git](https://git-scm.com/downloads) e [https://www.docker.com/products/docker-desktop](docker) instalado,
caso já tenha, basta executar no prompt de comando: 

`git clone https://github.com/gcm10000/Coodesh.SpaceFlightNews && cd Coodesh.SpaceFlightNews && docker build -t coodesh-spaceflightnews -f Dockerfile .`

Após gerar a imagem, basta executá-la:
`docker run -p 5000:5000 coodesh-spaceflightnews`

Com o comando acima, o servidor roda dentro de um container docker utilizando a porta 5000.
Para testar, a rota `/` deve retornar status 200 e uma mensagem "Back-end Challenge 2021 🏅 - Space Flight News"

As rotas foram desenvolvidas conforme o desafio solicita.

