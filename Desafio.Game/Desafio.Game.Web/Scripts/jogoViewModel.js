
var GameViewModel = function () {

    var self = this;

    self.Id = ko.observable("0");
    self.Titulo = ko.observable("");
    self.Genero = ko.observable("");
    self.Plataforma = ko.observable("");
    self.Fornecedor = ko.observable("");
    self.Descricao = ko.observable("");
    self.Link = ko.observable("");
    self.DataAdquirida = ko.observable("");
    self.TituloPesquisa = ko.observable();
    self.FornecedorPesquisa = ko.observable();

    var Jogo = {
        Id: self.Id,
        Titulo: self.Titulo,
        Genero: self.Genero,
        Plataforma: self.Plataforma,
        Fornecedor: self.Fornecedor,
        Descricao: self.Descricao,
        Link: self.Link,
        DataAdquirida: self.DataAdquirida
    };

    self.Jogo = ko.observable();
    self.Jogos = ko.observableArray([]);

    GetJogos();

    self.Validar = function () {

        if ((typeof self.Titulo()) == "undefined" || self.Titulo() == null || self.Titulo() == "") {
            self.mensagemAlerta($("#htmlMensagem").val(), "O campo Título é Obrigatório.", "Informa", null, 4000, 4000, false);
            return false;
        }

        if ((typeof self.Genero()) == "undefined" || self.Genero() == null || self.Genero() == "") {
            self.mensagemAlerta($("#htmlMensagem").val(), "O campo Gênero é Obrigatório.", "Informa", null, 4000, 4000, false);
            return false;
        }

        if ((typeof self.Plataforma()) == "undefined" || self.Plataforma() == null || self.Plataforma() == "") {
            self.mensagemAlerta($("#htmlMensagem").val(), "O campo Plataforma é Obrigatório.", "Informa", null, 4000, 4000, false);
            return false;
        }

        if ((typeof self.Fornecedor()) == "undefined" || self.Fornecedor() == null || self.Fornecedor() == "") {
            self.mensagemAlerta($("#htmlMensagem").val(), "O campo Fornecedor é Obrigatório.", "Informa", null, 4000, 4000, false);
            return false;
        }

        if ((typeof self.Descricao()) == "undefined" || self.Descricao() == null || self.Descricao() == "") {
            self.mensagemAlerta($("#htmlMensagem").val(), "O campo Descrição é Obrigatório.", "Informa", null, 4000, 4000, false);
            return false;
        }

      
        return true;
    }

    self.Salvar = function () {

        if (self.Validar()) {
            $.ajax({
                type: "POST",
                url: "/Home/CadastrarJogo",
                cache: false,
                data: ko.toJSON(Jogo),
                contentType: "application/json",
                success: function (data) {
                    self.limparCampos();
                    GetJogos();
                    self.mensagemAlerta($("#htmlMensagem").val(), "Registro salvo com sucesso", "Sucesso", null, 4000, 4000, false);
                },
                error: function (error) {
                    self.mensagemAlerta($("#htmlMensagem").val(), "Erro: Status-> " + error.status + " Descricao-> " + error.responseText, "Error", null, 6000, 6000, false);
                }
            });
        }
    };

    self.Editar = function (_jogo) {
        $("#formEditar").show();
        self.Jogo(_jogo);
    }

    self.Atualizar = function () {

            var Jogo = self.Jogo();
            var Url = "/Home/AtualizarJogo/";

            $.ajax({
                type: "POST",
                url: Url,
                data: JSON.stringify(Jogo),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    self.limparCampos();
                    GetJogos();
                    self.mensagemAlerta($("#htmlMensagem").val(), "Registro atualizado com sucesso", "Sucesso", null, 4000, 4000, false);
                },
                error: function (error) {
                    self.mensagemAlerta($("#htmlMensagem").val(), "Erro: Status-> " + error.status + " Descricao-> " + error.responseText, "Error", null, 6000, 6000, false);
                }
            });

    };

    self.Deletar = function (_jogo) {
        $.ajax({
            type: "GET",
            url: "/Home/ExcluirJogo/" + _jogo.Id,
            success: function (data) {
                self.Jogos.remove(_jogo);
                GetJogos();
                self.mensagemAlerta($("#htmlMensagem").val(), "Registro deletado com sucesso", "Sucesso", null, 4000, 4000, false);
            },
            error: function (error) {
                self.mensagemAlerta($("#htmlMensagem").val(), "Erro: Status-> " + error.status + " Descricao-> " + error.responseText, "Error", null, 6000, 6000, false);
            }
        });
    };

    self.Cancelar = function () {
        self.limparCampos();
    }

    function GetJogos() {
       
        $.ajax({
            type: "GET",
            url: "/Home/ListarJogos",
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.Jogos(data);
            },
            error: function (error) {
                console.log(error.status + "<--and--> " + error.responseText);
            }
        });
    };

    self.Pesquisar = function () {
        
        var dataParam = {
            titulo: self.TituloPesquisa(),
            fornecedor: self.FornecedorPesquisa()
        };
        $.ajax({
            type: "POST",
            url: "/Home/Pesquisar/",
            data: JSON.stringify(dataParam),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                self.TituloPesquisa("");
                self.FornecedorPesquisa("");
                self.Jogos(data);
            },
            error: function (error) {
                self.mensagemAlerta($("#htmlMensagem").val(), "Erro: Status-> " + error.status + " Descricao-> " + error.responseText, "Error", null, 6000, 6000, false);
            }
        });
    }

    function HabilitarBotoes(isSalvar, isAtualizar, isCancelar) {

        if (isSalvar) {
            $("#btnSalvar").hide();
            $("#btnSalvarEdit").hide();
        }
        else {
            $("#btnSalvar").show();
        }

        if (isAtualizar) {
            $("#btnAtualizar").hide();
            $("#btnAtualizarEdit").hide();
        }
        else {
            $("#btnAtualizar").show();
        }

        if (isCancelar) {
            $("#btnCancelar").hide();
            $("#btnCancelarEdit").hide();
        }
        else {
            $("#btnCancelar").show();
        }

    }

    self.SelecionarJogo = function (_jogo) {
            self.Id = _jogo.Id,
            self.Titulo = _jogo.Titulo,
            self.Genero = _jogo.Genero,
            self.Plataforma = _jogo.Plataforma,
            self.Fornecedor = _jogo.Fornecedor,
            self.Descricao = _jogo.Descricao,
            self.Link = _jogo.Link
    };

    self.limparCampos = function () {
        self.Titulo("");
        self.TituloPesquisa("");
        self.Genero("");
        self.Plataforma("");
        self.Fornecedor("");
        self.FornecedorPesquisa("");
        self.Descricao("");
       
        self.Link("");
        self.Jogo(null);
    };

    self.mensagemAlerta = function (htmlMsg, msg, estilo, pagina, delayMsg, duracaoRedirecionar, isPaginaRedirect) {

        if (estilo === "Sucesso") {
            if (htmlMsg !== null) {
                $("#" + htmlMsg).html('<div class="alert alert-success" id="success-alert"><strong>Sucesso: </strong> ' + msg + ' </div>').show();
                $("#" + htmlMsg).delay(delayMsg).fadeOut(200);
            }
            if (isPaginaRedirect)
                setTimeout("window.location.href", duracaoRedirecionar);

        } else if (estilo === "Informa") {
            if (htmlMsg !== null) {
                $("#" + htmlMsg).html('<div class="alert alert-warning" id="warning-alert"><strong>Informa: </strong> ' + msg + ' </div>').show();
                $("#" + htmlMsg).delay(delayMsg).fadeOut(200);
            }
            if (isPaginaRedirect)
                setTimeout("window.location.href", duracaoRedirecionar);

        } else if (estilo === "Error") {

            if (htmlMsg !== null) {
                $("#" + htmlMsg).html('<div class="alert alert-danger" id="danger-alert"><strong>Error: </strong>' + msg + '</div>').show();
                $("#" + htmlMsg).delay(delayMsg).fadeOut(200);
            }
            if (isPaginaRedirect)
                setTimeout("window.location.href", duracaoRedirecionar);
        }
    }
}

ko.applyBindings(new GameViewModel());