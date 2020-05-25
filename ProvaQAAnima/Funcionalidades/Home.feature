#language: pt-br

Funcionalidade: Home
	Como um usuário
	Desejo acessar a aplicação
	Assim posso navegar entre as funcionalidades

@mytag
Cenario: 1 - Quando um usuario acessar a aplicação, a menssagem Site para Automação deve ser validada
	Dado Um usuario acessar a tela inicial
	Quando O carregamento finalizar
	Então A seguinte mensagem será exibida: Site para Automação

Cenario: 2 - Quando um usuario acessar a aplicação, a URL deve ser validada
	Dado Um usuario acessar a tela inicial
	Quando O carregamento finalizar
	Então A url deve ser validada
