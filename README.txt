Projeto: Desafio Games
Desenvolverdor: Fabricio Lara
Equipe: Sustentação
Data: 13/08/2018

O desafio
Crie um sistema para o gerenciamento de uma loja de Games. Deverá ser feito o Back e Front-End.

O Projeto Desafio Games:

 - Descrição do Projeto.
 
	Conforme os procedimentos e requisitos para implementação do sistema de gerenciamento de games. O projeto desafio games foi desenvolvido em camadas para melhor organização, desaclopamento, cada camada com suas responsabilidades e torna o projeto mais flexivel a mudanças e melhor reaproveitamento das funcionalidades, dominios, etc. A parte web foi desenvolvida em MVC, Utilizando Entity Framework para acesso a dados.
    O sistema composto pelos seguintes menus:
	   > Home
	          - Na tela Home, Toda a funcionalidade (salvar, atualizar, pesquisr, excluir, cancelar) e interação foi implementado utilizando Knockout.JS
	   > Jogos: 
	          - No menu jogos possui telas para consultar, cadastrar, editar e exclusão dos jogos.
			  
    Na parte web foi aplicado o pattern View Model para trabalhar de forma correta com as data annotation permitindo que a entidade permanecesse pura, e apropriada para ser utilizada a outros projetos.
    Foi também utilizado o Auto Mapper 7.2 onde foi configurado uma classe para gerenciar essa converção do objeto a ser manipulado.
	
	- No projeto Core, foi implementado as entidades pra coneção com banco de dados, configuração da entidade a ser criada no banco de dados.
	- No Projeto COMUM,  implementado de forma generica toda logica do CRUD e tambem criação da Interface generica para sua utilização. 
	

    	
	
			 
	
	
