jQuery.noConflict();
(function ($) {
    $(document).ready(function () {
        $('#TabelaPessoas').DataTable(
            {
                language: {
                    url: '//cdn.datatables.net/plug-ins/2.2.1/i18n/pt-BR.json',
                }
            }
        );
    });
})(jQuery);
