$(function () {
    LoadingAjax();
});

function RecuperaConfiguracoesDataTable(config) {

    var configBaseDataTable = {
        bJQueryUI: false,
        bFilter: false,

        "bPaginate": config.bPaginate,
        "bProcessing": false,
        "iDisplayLength": config.iDisplayLength || 10,
        "sPaginationType": "full_numbers",
        "bServerSide": true,
        "aaSorting": config.aaSorting || [[0, 'asc']],
        'bFilter': false,
        "bDeferRender": true,
        "bDestroy": true,
        "bAutoWidth": false,
        "bLengthChange": false,
        "bInfo": config.bInfo,
        "oLanguage": config.oLanguage || {
            "sProcessing": "Processando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": config.sZeroRecords || "Nenhum registro encontrado.",
            "sInfo": config.sInfo || "Nº de registros  <b> _TOTAL_</b>",
            "sInfoEmpty": "Nº de registros 0",
            "sInfoFiltered": "",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": " <i class='glyphicon glyphicon-backward'></i> ",
                "sPrevious": "<i class='glyphicon glyphicon-triangle-left'></i> ",
                "sNext": " <i class='glyphicon glyphicon-triangle-right'></i> ",
                "sLast": " <i class='glyphicon glyphicon-forward'></i>"
            }
        }
    };

    return configBaseDataTable;
}

function validaCampos() {
    var erro = false;
    $(".error").remove();

    if (!validaObrigatorio()) {
        erro = true;
    }

    return erro;
}

function validaObrigatorio() {
    $required = $('.required');
    var erro = false;
    for (var i = 0; i < $required.length; i++) {
        var $obj = $($required[i]);
        if (!$obj.val()) {
            erro = true;
            var divCampo = $obj.parent();
            var fieldHtml = divCampo.append("<span class='error'>Obrigatorio </span>");
        }
    }
    return !erro;
}

function controlarCampoDataObrigatorio($obj) {
    var erro = false;
    if ($obj.val() && !validaData($obj.val())) {
        erro = true;
        var divCampo = $obj.parent();
        var fieldHtml = divCampo.append("<span class='error'>Formato Incorreto (DD/MM/AAAA)</span>");
    }
    return !erro;
}

function EmailValido(email) {
    var exp = /^([\w]+)(\.[\w]+)*@([\w\-]+\.){1,5}([A-Za-z]){2,4}$/;
    return exp.test(email);
}

function htmlEscape(str) {
    return String(str)
            .replace(/&/g, '&amp;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;');
}

function SobeScroll() {

    $("html, body").animate({ scrollTop: 0 }, "slow");

}

function LoadingAjax() {

    //carrega imagem de loading
    $(document).ajaxStart(function () {
        var container = $('<div id="load">');
        var mask = $('<div id="mask">');
        var ajax = $('<div id="ajax">');
        var img = $('<img src="' + rootUrl + 'Content/Images/ajax-loader.gif"/>');

        img.appendTo(ajax);
        mask.appendTo(container);
        ajax.appendTo(container);

        $('body').prepend(container);
        CriaDivCarregando();
    }).ajaxStop(function () {
        $('#load').remove();
    });
}

function CriaDivCarregando() {
    $('#ajax').css({
        width: '128px',
        height: '128px',
        position: 'fixed',
        top: '50%',
        left: '50%',
        marginTop: '-64px',
        marginRight: '0px',
        marginBottom: '0px',
        marginLeft: '-64px',
        zIndex: 9999
    });
    $('#mask').css({
        backgroundColor: '#fff',
        opacity: '0.6',
        top: '0',
        left: '0',
        width: '100%',
        height: $(document).height(),
        position: 'fixed',
        zIndex: 9998
    });
}

Array.prototype.remove = function (item) {
    var indiceItem = this.indexOf(item);
    if (indiceItem > -1) {
        for (var indice = indiceItem; indice < this.length - 1; indice++) {
            this[indice] = this[indice + 1];
        }
        this.pop();
    }
};

String.prototype.replaceAll = function (search, replacement) {
    var target = this;
    return target.split(search).join(replacement);
};