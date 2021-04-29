$(function () {
    $("#frmLogin").validate({

        rules: {
            userName: { required: true, email: true },
            password: { required: true },
        },
        messages: {
            userName: { required: "Es un valor requerido" },
            password: { required: "Es un valor requerido" }
        },
        submitHandler: function (form) {
            $.ajax({
                url: form.urlTo.value,
                type: "POST",
                data: $("#frmLogin").serialize(),
                success: function (data) {
                    console.log(data);
                    swal({
                        type: 'success',
                        icon: 'success',
                        title: "Acceso consedido",
                        timer: 2000
                    }).then(willDelete => {
                        location.href = "/Home/Index";
                    });
                    //if (data.Id > 0) {
                    //    swal("Operación exitosa",
                    //        "Registro exitoso",
                    //        "success").then(willDelete => {
                    //            //location.reload()
                    //        });
                        
                    //} else {
                    //    swal("error", data.ResponseText, "error");
                    //}
                },
                error: function (data) {
                    console.log(data);
                    console.log("Error");
                    swal("error", "No se pudo realizar la operación", "error");
                }
            });
        }
    });
});