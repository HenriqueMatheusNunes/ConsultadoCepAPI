📍 Consulta de CEP em C# (.NET)

Aplicação de terminal (Console Application) desenvolvida em C# para consultar endereços brasileiros utilizando a API gratuita ViaCEP.

O projeto foi desenvolvido para praticar o consumo de APIs REST, validação de dados, desserialização JSON e tratamento de erros.

🛠️ Tecnologias Utilizadas
Linguagem: C# (.NET)
Comunicação HTTP: System.Net.Http.HttpClient
Desserialização JSON: System.Text.Json (com mapeamento [JsonPropertyName])
Interface: Console Application (Terminal)

📌 Funcionalidades
Sanitização de Entrada: Remove automaticamente hífens (-) e espaços em branco digitados pelo usuário.
Validação do CEP: Verifica se o CEP possui exatamente 8 dígitos numéricos antes de realizar a requisição HTTP.
Tratamento de CEP não encontrado: Identifica quando a API retorna a propriedade "erro": "true", mesmo com o status HTTP 200 OK.
Exibição dos Dados: Apresenta logradouro, bairro, cidade e estado (UF) de forma organizada no terminal.

📂 Estrutura do Projeto
text
ConsultandoCep/
├── Program.cs          # Fluxo principal, validações e chamada à API
└── Informacoes.cs      # Modelo para mapear a resposta JSON do ViaCEP

🚀 Como executar

Pré-requisito: ter o .NET SDK instalado.

bash
# Clonar o repositório
git clone URL_DO_REPOSITORIO

# Entrar na pasta do projeto
cd ConsultandoCep

# Executar a aplicação
dotnet run
