$(function () {
    binds();
});

function binds() {
    $("#btnSalvar").click(function () {
        if (!validaCampos()) {
            if (!confirmar || confirm(confirmar)) {
                salvar();
            }
        }
        return false;
    });
}

function salvar() {
    $.ajax({
        type: "POST",
        url: rootUrlController + "/Salvar",
        data: $("#frmManter").serializeArray(),
        success: function (retorno) {
            if (retorno) {
                alert(retorno);
                window.location.href = rootUrlController + "/Index";
            }
        }
    });
}