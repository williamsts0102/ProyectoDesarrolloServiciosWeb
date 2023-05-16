var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable =
        $('#tblData').DataTable({
            "ajax": {url : '/admin/producto/getall'},
            "columns" : [
                { data: 'nombreProducto', "width": "15%"},
                { data: 'descripcion', "width": "15%" },
                { data: 'precio', "width": "15%" },
                { data: 'categoria.nombre', "width": "15%" },
                {
                    data: 'idProducto',
                    "render": function (data) {
                        return `<div class="w-75 btn-group" role="group">
                                    <a href="/admin/producto/upsert?idProducto=${data}" class="btn btn-primary mx-2">
                                    <i class="bi bi-pencil-square"></i>Actualizar</a>
                                    <a onClick=Delete('/admin/producto/deletepro/${data}') class="btn btn-danger mx-2">
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
