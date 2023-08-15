API de Filmes
Esta API permite que você gerencie informações sobre filmes, incluindo detalhes como título, gênero e duração. A API é construída usando ASP.NET Core e fornece endpoints para realizar operações CRUD (Criar, Ler, Atualizar e Deletar) em filmes.

Configuração
Pré-requisitos
Certifique-se de ter o seguinte software instalado em seu sistema:

.NET 6 SDK
Git (opcional, mas recomendado para clonar o repositório)

Instalação
Clone este repositório para o seu sistema local (ou faça o download do arquivo ZIP).

git clone https://github.com/marcosmmatos/FilmesApi.git

Navegue até o diretório do projeto.

cd api-filmes

Execute a aplicação.

dotnet run

A API estará em execução no endereço https://localhost:7106 (ou http://localhost:5106 se não estiver usando HTTPS).

Endpoints
A API de Filmes oferece os seguintes endpoints:

GET /Filme
Retorna a lista de todos os filmes cadastrados.

GET /Filme/{id}
Retorna os detalhes de um filme específico com base no ID fornecido.

POST /Filme
Cria um novo filme com base nos dados fornecidos no corpo da solicitação.

PUT /Filme/{id}
Atualiza os detalhes de um filme específico com base no ID fornecido e nos dados fornecidos no corpo da solicitação.

PATCH /Filme/{id}
Atualiza os detalhes de um filme específico com base no ID fornecido e nos dados fornecidos no corpo da solicitação (Sem informar todos os dados).

DELETE /filmes/{id}
Exclui um filme específico com base no ID fornecido.

Exemplo de Requisição e Resposta

GET /filmes/1
Resposta:

{
  "id": 1,
  "titulo": "O Senhor dos Anéis: A Sociedade do Anel",
  "genero": "Fantasia".
  "Duracao": 100
}
