var urlPath = window.location.pathname;

$(function () {
    $("#DataInicial").mask("99/99/9999");
    $("#DataFinal").mask("99/99/9999");
    $("#HoraEntrada").mask("99:99");
    $("#HoraSaida").mask("99:99");

    $('.datetimepicker input').datepicker({
        olanguage: "pt-BR",
        orientation: "bottom left",
        autoclose: true,
        todayBtn: true
    });

    $('#DataInicial').blur(function () {
        $('#DataFinal').val($('#DataInicial').val());
    });

    //Funcionando, ver depois onde colocar e testar nos usuario da lista

    $('#usuarioNome').typeahead({
        source: function (term, process) {
            var url = '@Url.Content("/Eventos/GetNames")';

            return $.getJSON(url, { term: term }, function (data) {
                return process(data);
            });
        }
    });

    var viewModel = new UsuarioViewModel();
    ko.applyBindings(viewModel);
});

function UsuarioViewModel() {

    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI
    self.EventoId = ko.observable();
    self.UsuarioId = ko.observable();
    self.UsuarioNome = ko.observable();
    self.HoraEntrada = ko.observable();
    self.HoraSaida = ko.observable();

    var UserEvent = {
        EventoId: self.EventoId,
        UsuarioId: self.UsuarioId,
        UsuarioNome: self.UsuarioNome,
        HoraEntrada: self.HoraEntrada,
        HoraSaida: self.HoraSaida
    };

    self.UserEvent = ko.observable();
    self.listaUsuarios = ko.observableArray();   // Contains the list of users

    var eventoId = $("#Add-btn").data('id');

    // Initialize the view-model
    $.ajax({
        url: '/Eventos/GetEvento/',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        dataType: "JSON",
        data: { eventoId },
        success: function (data) {
            if (data !== null) {
                self.listaUsuarios(data); //Put the response in ObservableArray
            }
        }
    });

    //Busca Codigo do Usuário pelo Nome para incluir na variável usuarioId
    UserEvent.UsuarioId.subscribe(function () {
        $("#progress").show();
        var id = UserEvent.UsuarioId();
        //var strUrl = '@Url.Action("BuscaFuncionario", "Eventos")';
        if (UserEvent.UsuarioId() !== "") {
            $.getJSON("/Eventos/BuscaFuncionario/", { "UsuarioId": id }, function (data) {
                if (data !== null) {
                    self.UsuarioNome(data);
                    $("#horaEntrada").focus();
                } else {
                    bootbox.alert('ATENÇÃO! Funcionário não CADASTRADO ou INATIVO.');
                    self.reset();
                }
            });
        }
        $("#progress").hide();
    });

    //Add New Item
    self.adcionarItem = function () {

        if (UserEvent.UsuarioNome() === null || UserEvent.UsuarioNome() === "") {
            bootbox.alert("Verifique a disponibilidade do Funcionário");
            return;
        }

        self.EventoId(eventoId);
        UserEvent.EventoId(eventoId);
        if (UserEvent.UsuarioId() !== "" && UserEvent.HoraEntrada() !== "" && UserEvent.HoraSaida() !== "") {
            $.ajax({
                url: '/Eventos/SalvarUsuarioEvento/',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(UserEvent),
                success: function (data) {
                    self.listaUsuarios.push(data);
                    //self.listaUsuarios.push({ UsuarioNome: UserEvent.UsuarioNome(), HoraEntrada: UserEvent.HoraEntrada(), HoraSaida: UserEvent.HoraSaida() });
                    self.reset();
                }
            }).fail(
         function (xhr, textStatus, err) {
             bootbox.alert(err);
         });
        }
        else {
            bootbox.alert('Por favor, entre com todos os dados !!');
        }
    }; // Delete product details
    self.excluir = function (Usuario) {
        bootbox.confirm("Confirme exclusão do " + Usuario.UsuarioNome + " ??", function (result) {
            if (result === true) {
                var id = Usuario.EventoId;
                var nome = Usuario.UsuarioId;

                $.ajax({
                    url: '/Eventos/ExcluirUsuarioEvento/',
                    cache: false,
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: ko.toJSON({ "id": id, "nomeEvento": nome }),
                    success: function (data) {
                        self.listaUsuarios.remove(Usuario);
                        bootbox.alert("Registro Excluído com Sucesso!");
                    }
                }).fail(
                 function (xhr, textStatus, err) {
                     bootbox.alert(err);
                 });
            }
        });
    }; // Reset usuario details
    self.reset = function () {
        self.UsuarioNome("");
        self.HoraEntrada("");
        self.HoraSaida("");
    }; // Cancel Usuario details
    self.cancel = function () {
        self.UserEvent(null);

    };
}
