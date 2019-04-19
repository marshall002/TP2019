$(document).ready(function () {
	$("input[type='radio']").click(function () {
		var radioValue = $("input[name='Servicios']:checked").val();
		if (radioValue) {
			alert("Your are a - " + radioValue);
		}
		$("[id*=txtresultadoChecbox]").val(radioValue);
	})
	});