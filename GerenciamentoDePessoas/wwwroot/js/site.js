// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

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
