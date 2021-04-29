function generar(url) {

    console.log(url);

    $.ajax({
        url: url,
        type: "POST",
        success: function (data) {
            swal("Operación exitosa",
                "Registro exitoso",
                "success").then(willDelete => {
                    //location.reload()
                });
        },
        error: function (data) {
            swal("Error",
                "No se pudo realizar la operación",
                "error");
        },
    });
}