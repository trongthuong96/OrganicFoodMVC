var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#page_home').ajaxComplete({

        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            {
                "render": function (data, type, full, meta) {
                    return meta.row + 1;
                },
            },
            { "data": "name", "width": "12%" },
            { "data": "discription", "width": "30%" },
            { "data": "category.name", "width": "12%" },
            { "data": "brand.name", "width": "12%" },
            { "data": "quantity", "width": "10%" },
            { "data": "price", "width": "10%", render: $.fn.dataTable.render.number(',', ' đ', ',', 0) },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Product/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a onclick=Delete("/Admin/Product/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i>
                                </a>
                            </div>
                            `;
                }, "width": "10%"
            },
        ],
        fixedColumns: true,
        columnDefs: [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0,
            },
            { targets: 1, render: $.fn.dataTable.render.ellipsis() },
            { targets: 2, render: $.fn.dataTable.render.ellipsis() },
        ],

        dom: 'Plfrtip',
        language: {
            "emptyTable": "Không có dữ liệu",
            "search": "Tìm kiếm:",
            "paginate": {
                "first": "Trang đầu",
                "last": "Trang cuối",
                "next": "Trang sau",
                "previous": "Trang trước"
            },
            "info": "Hiển thị _START_ đến _END_ sản phẩm / Tổng _TOTAL_ sản phẩm",
            "infoEmpty": "",
            "lengthMenu": "Hiện _MENU_ sản phẩm",
        },

    });
}