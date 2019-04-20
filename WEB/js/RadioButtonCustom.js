$(document).ready(function () {
	$("input[type='radio']").click(function () {
		var radioValue = $("input[name='Servicios']:checked").val();
		$("[id*=txtresultadoChecbox]").val(radioValue);
	})
});
function abrirModalAsignarCurso() {
	$('#modalAsignarCurso').modal('show');
}