$(document).ready(function () {
    $("[id*=txtasistenciaChecbox]").val('7');
});
$("input[type='checkbox']").change(function () {
    if ($(this).is(":checked")) {
        var checkboxradio = 6;
        $('[id*=btnReprogramar]').hide();
        $("[id*=txtasistenciaChecbox]").val(checkboxradio);

    }
    else {
        checkboxradio = 7;
        $("[id*=txtasistenciaChecbox]").val(checkboxradio);
        $('[id*=btnReprogramar]').show();
    }
})
$("#btnReprogramar").click(function () {
    var checkboxradio = 9;
    $("[id*=txtasistenciaChecbox]").val(checkboxradio);
});