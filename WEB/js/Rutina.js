(function () {
    var index = 0;
    var template = {
        Rutina: '<div class="row">' +
            '<div class="col-md-3">' +
            '<label>Tipo Ejercicio: </label>' +
            '<select id={id} class="form-control seleTipoEjercicio"  style="width:180px;height:30px">' +
            '</select>' +
            '</div>' +
            '<div class="col-md-3">' +
            '<label>Ejercicio: </label>' +
            '<select id={id} class="form-control seleEjercicio" style="width:180px;height:30px">' +
            '</select>' + '</div>' +
            '<div class="col-md-3">' +
            '<label >Descripción: </label>' +
            '<br />' +
            '<input id="" class="form-control"  style="width:180px;height:30px"></input>' +
            '</div>' +
            '</div>' +
            '<br/>'
    };
    $(document).ready(function () {
        var cont = 0;
        $('#btnlist').click(addRutina);
        $(this).change(function () {
            console.log($(this).find(":selected").text());
        });
    });
    var addRutina = function () {
        $(".seleTipoEjercicio").html('');
        $(".seleEjercicio").html('');
        index = index + 1;
        var tempalte = template.Rutina.replace("{id}", index);
        index = index + 1;
        tempalte = tempalte.replace("{id}", index);
        $("#modal-rutina").append(tempalte);
        $.ajax({
            type: "POST",
            url: "AdministrarRutina.aspx/GetList",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response);
                response.d.dtoEjercicios.forEach(function (item) {
                    $(".seleEjercicio").append('<option class="optionEjercicio" data-id=' + item.PK_IE_Cod+' value=' + item.PK_IE_Cod + '>' + item.VE_Nombre + '</option>');
                });
                response.d.dtoTipoEjercicios.forEach(function (item) {
                    $(".seleTipoEjercicio").append('<option class="optionTipoEjercicio" data-id=' + item.PK_ITE_Cod +' value=' + item.PK_ITE_Cod + '>' + item.VTE_Nombre + '</option>');
                });
            },
            failure: function (response) {
                alert('gg');
            }
        });
    };
    function changeEjercicio(select) {
    }
})();