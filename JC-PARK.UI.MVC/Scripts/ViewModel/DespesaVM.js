var urlPath = window.location.pathname;

$(function () {
    $("#DataCadastro").val("").mask("99/99/9999");
    $('input.dinheiro').mask('#.##0,00', { reverse: true });

    $('.datetimepicker input').datepicker({
        language: "pt-BR",
        orientation: "bottom left",
        autoclose: true
    });

    var viewModel = new DespesaViewModel();
    ko.applyBindings(viewModel);
});

function formatCurrency(value) {
    return "R$ " + value.toFixed(2);
}

function DespesaViewModel() {

    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI
    self.EventoId = ko.observable();
    self.DataCadastro = ko.observable();
    self.ValorEntrada = ko.observable();
    self.ValorDespesa = ko.observable();

    var Despesas = {
        EventoId: self.EventoId,
        DataCadastro: self.DataCadastro,
        ValorEntrada: self.ValorEntrada,
        ValorDespesa: self.ValorDespesa
    };

    self.Despesas = ko.observable();
    self.listaDespesas = ko.observableArray();

    // Calcula Total Entrada
    self.TotalEntrada = ko.computed(function () {
        var sum = 0;
        var arr = self.listaDespesas();
        for (var i = 0; i < arr.length; i++) {
            sum += arr[i].ValorEntrada;
        }
        return formatCurrency(sum);
    });

    // Calcula Total Despesa
    self.TotalDespesa = ko.computed(function () {
        var sum = 0.0;
        var arr = self.listaDespesas();
        for (var i = 0; i < arr.length; i++) {
            sum += arr[i].ValorDespesa;
        }
        return formatCurrency(sum);
    });

    // Calcula Total Geral
    self.TotalGeral = ko.computed(function () {
        var sum = 0.0;
        var sumEntrada = 0.0;
        var sumDespesa = 0.0;
        var arr = self.listaDespesas();
        for (var i = 0; i < arr.length; i++) {
            sumEntrada += arr[i].ValorEntrada;
            sumDespesa += arr[i].ValorDespesa;
        }
        sum = sumEntrada - sumDespesa;
        return formatCurrency(sum);
    });

    var eventoId = $("#Add-btn").data('id');

    // Initialize the view-model
    $.ajax({
        url: '/Despesa/GetDespesa/',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        dataType: "JSON",
        data: { eventoId },
        success: function (data) {
            if (data !== null) {
                self.listaDespesas(data); //Add Dados na lista de Despesas
            }
        }
    });

    self.adcionarItem = function () {
        $("#progress").show();
        self.EventoId(eventoId);
        self.ValorEntrada($('#ValorEntrada').val());
        self.ValorDespesa($('#ValorDespesa').val());
        Despesas.EventoId(eventoId);

        if (checaCampos() !== false) {
            $.ajax({
                url: '/Despesa/Create/',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(Despesas),
                success: function (data) {
                    self.listaDespesas.push(data);
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
        $("#progress").hide();
        $("#Patio").focus();
    }
       
    function checaCampos() {
        if ($("#DataCadastro").val() === ""
            || $("#ValorEntrada").val() === ""
            || $("#ValorDespesa").val() === "") { return false };
    }

    // Reset usuario details
    self.reset = function () {
        self.DataCadastro("");
        self.ValorEntrada("");
        self.ValorDespesa("");
        //self.listaDespesas([]);
    }
}