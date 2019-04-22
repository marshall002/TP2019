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
	else if(ValueRadiobutton == 2) {
		$("#cbx_Fisioterapeuta").prop('checked', true);
	}
	$("[id*=txtresultadoChecbox]").val(ValueRadiobutton);

}