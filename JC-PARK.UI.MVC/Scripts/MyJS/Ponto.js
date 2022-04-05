var urlPath = window.location.pathname;

$(function () {
    Example.init({ "selector": ".bb-alert" });
});

$("#lnk-ponto").on("click", function (e) {
    e.preventDefault();
    bootbox.confirm("Tem certeza que deseja bater seu PONTO ???", function (result) {
        if (result) {
            //$("#progress").show();
            var strUrl = "/Usuario/Ponto";

            $.post(strUrl, "", function (data) {
                bootbox.alert(data);
                //debugguer;
                //Example.show(data);
            }, "json");

            //$("#progress").hide();
        }
    });
});



