var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("enproceso")) {
        loadDataTable("enproceso");
    }
    else {
        if (url.includes("completado")) {
            loadDataTable("completado");
        }
        else {
            if (url.includes("pendiente")) {
                loadDataTable("pendiente");
            }
            else {
                if (url.includes("aprobado")) {
                    loadDataTable("aprobado");
                }
                else {
                    loadDataTable("todo");
                }
            }
        }
    }
});

function loadDataTable(status) {
    dataTable =
        $('#tblData').DataTable({
            "ajax": { url: '/admin/order/getall?status=' + status },
            "columns": [
                { data: 'id', "width": "15%" },
                { data: 'nombre', "width": "15%" },
                { data: 'telefono', "width": "15%" },
                { data: 'applicationUser.email', "width": "15%" },
                { data: 'estadoPedido', "width": "15%" },
                { data: 'totalPedido', "width": "15%" },
                {
                    data: 'id',
                    "render": function (data) {
                        return `<div class="w-75 btn-group" role="group">
                                    <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2">
                                    <i class="bi bi-pencil-square"></i>Actualizar</a>
                                </div>`
                    },
                    "width": "15%"
                }
            ]
        });
}