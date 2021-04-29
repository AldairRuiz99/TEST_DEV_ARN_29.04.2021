$(function () {

    $("#frmPersona").validate({
        rules: {
            nombre: {
                required: true,
                max: 50,
            },
            apaterno: {
                required: true,
                max: 50,
            },
            amaterno: {
                required: true,
                max: 50,
            },
            rfc: {
                required: true,
                max: 13,
            },
            fechana: { required: true }
        },
        messages: {
            nombre: { required: "Es un valor requerido" },
            apaterno: { required: "Es un valor requerido" },
            amaterno: { required: "Es un valor requerido" },
            rfc: { required: "Es un valor requerido" },
            fechana: { required: "Es un valor requerido" }
        },
        submitHandler: function (form) {

            $.ajax({
                url: form.urlTo.value,
                type: "POST",
                data: $("#frmPersona").serialize(),
                success: function (data) {
                    console.log(data);
                    swal({
                        type: 'success',
                        icon: 'success',
                        title: 'Registro Exitoso',
                        timer: 2000
                    }).then(willDelete => {
                        location.reload()
                    });

                },
                error: function (data) {
                    console.log("Error");
                    swal("Error", "No se pudo realizar la operación", "Error");
                }
            });
        }
    });

    $("#frmPersonaEditar").validate({
        rules: {
            nombre: { required: true },
            apaterno: { required: true },
            amaterno: { required: true },
            rfc: { required: true },
            fechana: { required: true }
        },
        messages: {
            nombre: { required: "Es un valor requerido" },
            apaterno: { required: "Es un valor requerido" },
            amaterno: { required: "Es un valor requerido" },
            rfc: { required: "Es un valor requerido" },
            fechana: { required: "Es un valor requerido" }
        },
        submitHandler: function (form) {

            console.log(form.urlTo.value);

            $.ajax({
                url: form.urlTo.value,
                type: "POST",
                data: $("#frmPersonaEditar").serialize(),
                success: function (data) {
                    swal({
                        type: 'success',
                        icon: 'success',
                        title: "Registro existoso",
                        timer: 2000
                    }).then(willDelete => {
                        location.href = form.urlRedirect.value;
                    });

                },
                error: function (data) {
                    console.log("Error");
                    swal("Error", "No se pudo realizar la operación", "Error");
                }
            });
        }
    });

});

function eliminar(Id, url) {
    console.log(Id);
    swal({
        title: "Eliminar Persona",
        text: "Estas seguro de eliminar el registro con el id " + Id,
        icon: "warning",
        closeOnClickOutside: false,
        buttons: [
            {
                text: "Confirmar",
                className: "btn btn-primary",
                value: true,
                visible: true,
                closeModal: true
            },
            {
                text: "Cancelar",
                className: "btn btn-danger",
                value: false,
                visible: true,
                closeModal: true
            }
        ]
    }).then((value) => {
        if (value === true) {
            $.ajax({
                url: url,
                data: { id: Id },
                type: "POST",
                success: function (data) {
                    swal("Operación exitosa",
                        "Registro eliminado",
                        "success").then(willDelete => {
                            location.reload()
                        });
                },
                error: function (data) {
                    swal("Error",
                        "No se pudo realizar la operación",
                        "error");
                },
            });
        } else {
            swal("Error", "Se cancelo la eliminación", "error");
        }
    });
}