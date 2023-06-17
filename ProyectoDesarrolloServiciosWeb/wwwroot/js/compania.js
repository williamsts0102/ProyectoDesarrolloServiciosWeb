var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable =
        $('#tblData').DataTable({
            "ajax": { url: '/admin/company/getall' },
            "columns": [
                { data: 'nombre', "width": "15%" },
                { data: 'direccion', "width": "15%" },
                { data: 'ciudad', "width": "15%" },
                { data: 'codigoPostal', "width": "15%" },
                { data: 'telefono', "width": "15%" },
                {
                    data: 'id',
                    "render": function (data) {
                        return `<div class="w-75 btn-group" role="group">
                                    <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2">
                                    <i class="bi bi-pencil-square"></i>Actualizar</a>
                                    <a onclick="Delete('/admin/company/delete?id=${data}')" class="btn btn-danger mx-2 mb-3">
                                     <i class="bi bi-trash-fill"></i>Eliminar</a>
                                </div>`
                    },
                    "width": "15%"
                }
            ]
        });
}

function Delete(url) {
    Swal.fire({
        title: '¿Estas seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: '¡Sí, bórralo!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}