$(document).ready(function () {
	$("input[type='radio']").click(function () {
		var radioValue = $("input[name='Servicios']:checked").val();
		$("[id*=txtresultadoChecbox]").val(radioValue);
	})
});
function abrirModalAsignarCurso() {
	$('#modalAsignarCurso').modal('show');
}

function SeleccionarRadioButton(ValueRadiobutton) {
	if (ValueRadiobutton == 1) {
		$("#cbx_Nutricionista").prop('checked', true);
	}
	else if (ValueRadiobutton == 2) {
		$("#cbx_Fisioterapeuta").prop('checked', true);
	}
	$("[id*=txtresultadoChecbox]").val(ValueRadiobutton);

}
function DeshabilitarCampos() {
	$("[id*=cbx_Fisioterapeuta]").prop('disabled', true);
	$("[id*=cbx_Nutricionista]").prop('disabled', true);
	$("[id*=txtFecha]").prop('disabled', true);
	$("[id*=txtHoras]").prop('disabled', true);
	$("[id*=txtDudaConsulta]").prop('disabled', true);
	$("[id*=btnGuardar1]").attr('disabled', 'disabled');
	debugger;
}