#language: pt-br

Funcionalidade: CriarUsuario
	Como um usuário
	Desejo acessar a aplicação para criar um usuario
	Para acessar a aplicação posteriormente

@mytag
Cenario: 1 - Cadrastrar um Usuario
	Dado Um usuario acessar a tela inicial
	Quando O carregamento finalizar
	E Clicar no Botão Comecar Automacao Web
	E Clicar no Botão Formulario
	E Clicar no Botão Criar Usuarios
	E Preencher Todos os Campos
	E Clicar em Criar
	Entao A seguinte mensagem será exibida: Usuário Criado com sucesso



Cenario: 2 - Validar Campos Obrigatorios no Cadastro
	Dado Um usuario acessar a tela inicial
	Quando O carregamento finalizar
	E Clicar no Botão Comecar Automacao Web
	E Clicar no Botão Formulario
	E Clicar no Botão Criar Usuarios
	E Nao Preencher os Campos Obrigatorios
	Entao A aplicação retornará erro
	 

Cenario: 3 - Validar Voltar
	Dado Um usuario acessar a tela inicial
	Quando O carregamento finalizar
	E Clicar no Botão Comecar Automacao Web
	E Clicar no Botão Formulario
	E Clicar no Botão Criar Usuarios
	E Clicar no Botão Voltar
	Entao Sera Direcionado para tela de Automacao
