
$("input[type='checkbox']").change(function () {
	debugger;
    if ($(this).is(":checked")) {
        var checkboxradio = 1;
        $('[id*=btnReprogramar]').hide();
        $("[id*=txtresultadoChecbox]").val(checkboxradio);

    }
    else {
        var checkboxradio = 8;
        $("[id*=txtresultadoChecbox]").val(checkboxradio);
        $('[id*=btnReprogramar]').show();
    }


})
$("#btnaceptar").click(function () {
    var checkboxradio = 3;
    $("[id*=txtresultadoChecbox]").val(checkboxradio);
});
function DeshabilitarCampos() {
	$("[id*=cbx_Fisioterapeuta]").prop('disabled', true);
	$("[id*=cbx_Nutricionista]").prop('disabled', true);
	$("[id*=txtFecha]").prop('disabled', true);
	$("[id*=txtHoras]").prop('disabled', true);
	$("[id*=txtDudaConsulta]").prop('disabled', true);
	$("[id*=btnGuardar1]").attr('disabled', 'disabled');
	debugger;
}