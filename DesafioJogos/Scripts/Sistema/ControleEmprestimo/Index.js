$(function () {
    montaTablePaginada();
    binds();
});

function binds() {
    $("#btnPesquisar").click(function () {
        montaTablePaginada();
        return false;
    });
}

function montaTablePaginada() {

    var config = {
        "sAjaxSource": rootUrlController + '/ListarPaginado',
        "aSync": false,
        "aoColumns": [
                 {
                     'mData': 'Amigo.Nome',
                     'sTitle': 'Amigo',
                     'sWidth': '25%',
                     'sClass': 'quebra-linha',
                     'fnRender': function (o, val) {
                         return val;
                     }
                 },
                {
                    'mData': 'Jogo.Nome',
                    'sTitle': 'Nome do Jogo',
                    'sWidth': '10%',
                    'sClass': 'quebra-linha',
                    'fnRender': function (o, val) {
                        return val;
                    }
                },
                {
                    'mData': 'DataAtualizacao',
                    'sTitle': 'Data Atualização',
                    'sWidth': '10%',
                    'sClass': 'quebra-linha',
                    'fnRender': function (o, val) {
                        return val;
                    }
                },
              {
                  'mData': null,
                  'sTitle': 'Ações',
                  'sWidth': '10%',
                  'sClass': 'acoes125 text-center',
                  'bSortable': false,
                  'mRender': function (data, type, val) {
                      var html = '<a class="glyphicon glyphicon-pencil" onclick="alterar(' + val.Id + ')" title="Alterar" aria-hidden="true"></a>' +
                                  '<a class="glyphicon glyphicon-remove" title="Excluir" aria-hidden="true" onclick="excluir(' + val.Id + ')"></a>'
                      return html;
                  }
              }],
        "fnServerParams": function (aoData) {
            var model = $("#frmConsultar").serializeArray();

            for (var i = 0; i < model.length; i++) {
                aoData.push({
                    'name': model[i].name,
                    'value': model[i].value
                });
            }
        }
    };

    config.aaSorting = [[0, 'asc']];
    $.extend(config, RecuperaConfiguracoesDataTable(config));
    $("#tblResultado").dataTable(config);

}

function alterar(id) {
    window.location.href = rootUrlController + "/Manter/" + id;
}

function excluir(id) {
    if (confirm(MC02)) {
        $.ajax({
            type: "POST",
            url: rootUrlController + "/Excluir",
            data: { id: id },
            success: function (retorno) {
                montaTablePaginada();
                alert(retorno.mensagem);
            }
        });
    }
}