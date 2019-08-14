function ValidarNumber() {

    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    }

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    }      
}

function ValidarDataDeNascimento() {
    $('#DataDeNascimento').datepicker({
        format: "dd/mm/yyyy",
        startDate: '-70y',
        endDate: '-18y',
        language: "pt-BR",
        orientation: "bottom right",
        autoclose: true
    });
}

function ValidarNotification() {
    toastr.options = {
        "closeButton": false,
        "debug": true,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

function AjaxAutoComplete() {

    $(document).ready(function () {

        $(function () {

            if ($("#Endereco_Cidade_UF").val() != "") {
                atualizarListaDeCidades($("#Endereco_Cidade_UF").val());
            }
            else {
                atualizarListaDeCidades("AC");
            }

            $("#Endereco_Cidade_UF").change(function () {
                var uf = $(this).val();
                atualizarListaDeCidades(uf);
                $("#hidden-cidade").val(0);
                $("#txt-cidade").val("");
            });

        });

    });

}

function atualizarListaDeCidades(uf) {

    var getData = function (request, response) {
        $.getJSON(
            '/Agencia/ListarCidadesUF', { uf: uf, term: request.term },
            function (data) {
                response($.map(data, function (item) { return {label: item.nome, valor: item.id} }));
            }
        );
    };

    var selectItem = function (event, ui) {
        $("#hidden-cidade").val(ui.item.valor);
    };

    $("#txt-cidade").autocomplete({
        source: getData,
        select: selectItem,
        minLength: 1,
        delay: 500,
        position: {
            my: 'left bottom',
            at: 'right bottom'
        }
    });

}

function AjaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            },
                                'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#EnderecoTarget').load(result.url); // Carrega o resultado HTML para a div demarcada
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });
}
