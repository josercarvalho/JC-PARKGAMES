
var urlPath = window.location.pathname;
var dataAtual = new Date();

$(document).ready(function () {
    $("input.dinheiro").maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: "." });
    $("#DataCadastro").mask("99/99/9999");
    $("#TelefonePai").mask("(99) 99999-9999");
    $("HoraEntrada").mask("99:99:99");
    //$("HoraSaida").mask("99:99:99");
    //var d = dataAtual.toLocaleDateString();
    //$("#DataCadastro").val(d);
});

$("#EtiquetaId").blur(function () {
    $("#progress").show();
    var etiqueta = $("#EtiquetaId").val();
    var d = new Date();
    if (etiqueta !== "") {
        $.getJSON("ValidarEtiqueta/", { etiqueta: etiqueta }, function (data) {
            if (data.erro.length === 0) {
                var h = d.toLocaleTimeString();
                $("#HoraEntrada").val(h);
            } else {
                bootbox.alert(data.erro);
                $("#EtiquetaId").val("");
                $("#EtiquetaId").focus();
            }
        }).fail(function (xhr, textStatus, err) { bootbox.alert(err); });
    }
    $("#progress").hide();
})

$("#btn-reset").on("click", function (e) {
    e.preventDefault();
    $("#NomeCrianca").val("");
    $("#NomePai").val("");
    $("#TelefonePai").val("");
    $("#EtiquetaId").val("");
    $("#HoraEntrada").val("");
});

