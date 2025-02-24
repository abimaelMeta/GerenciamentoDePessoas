﻿jQuery.noConflict();
(function ($) {
    $(document).ready(function () {
        $('.tabela-pessoas').DataTable(
            {
                language: {
                    url: '//cdn.datatables.net/plug-ins/2.2.1/i18n/pt-BR.json',
                }
            }
        );
    });
})(jQuery);

// Write your JavaScript code.


$(document).ready(function () {
    $('#buscarTotalPessoas').click(function () {
        $('#resultado').text('');

        $.ajax({
            method: "GET",         // Método HTTP
            url: "/Pessoa/Total", // URL do endpoint
            dataType: "text",       // Tipo da resposta esperada
            success: function (data) {
                $('#resultado').text(`Total de pessoas: ${data}`);
            },
            error: function (xhr, status, error) {
                console.error(`Erro: ${status} - ${error}`);
                $('#result').text('Erro ao buscar total de pessoas.');
            }
        });
    });
});


$('#botaoBusca').click(function () {
    var termo = $('#termoBusca').val();
    if (!termo) {
        alert('Informe um termo para busca.');
        return;
    }

    $.ajax({
        url: '/Pessoa/BuscarPessoasNome',
        type: 'GET',
        data: { termo: termo },
        success: function (data) {
            $('#resultadoPessoa').empty();
            if (data.length === 0) {
                $('#resultadoPessoa').append('<li class="list-group-item">Nenhuma pessoa encontrada.</li>');
            } else {
                data.forEach(function (pessoa) {
                    $('#resultadoPessoa').append('<li class="list-group-item">' + pessoa + '</li>');
                });
            }
        },
        error: function () {
            alert('Erro ao buscar pessoas.');
        }
    });
});                
