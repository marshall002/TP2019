﻿$(document).ready(function () {
	$("[id*=txtresultadoChecbox]").val('8');
});
$("input[type='checkbox']").change(function () {
	if ($(this).is(":checked")) {
		var checkboxradio = 2;
		$('[id*=btnReprogramar]').hide();
		$("[id*=txtresultadoChecbox]").val(checkboxradio);

	}
	else {
		checkboxradio = 8;
		$("[id*=txtresultadoChecbox]").val(checkboxradio);
		$('[id*=btnReprogramar]').show();
	}
})
$("#btnaceptar").click(function () {
	var checkboxradio = 3;
	$("[id*=txtresultadoChecbox]").val(checkboxradio);
});