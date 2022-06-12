﻿$(document).ready(function () {
    //Initially load pagenumber=1
    GetPageData(1);
});
function GetPageData(pageNum, pageSize) {
    //After every trigger remove previous data and paging
    $("#tblData").empty();
    $("#paged").empty();
    $.getJSON("Customer/Home/GetPage", { pageNumber: pageNum, pageSize: pageSize }, function (response) {
        var rowData = "";
        response.length
        for (var item of response.data) {

            rowData = rowData + `<div class="col-xl-2 col-lg-3 col-md-4 col-6">
                    <div class="card card-sm card-product-grid">
                        <a href="Customer/Home/Details/` + item.id + `"class="img-wrap"> <img src="` + item.imageUrl + `"> </a>
                        <figcaption class="info-wrap">
                            <a asp-action="Details" asp-route-id="`+ item.id + `" class="title">` + item.name + `</a>
                            <div class="price mt-1">`+
                new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(item.price) + `/` + item.unit.name + `</div> <!-- price-wrap.// -->
                        </figcaption>
                     </div>
                    </div> <!-- col.// -->`

        };

        $("#tblData").append(rowData);
        PaggingTemplate(response.totalPages, response.currentPage);
    });
}
//This is paging temlpate
function PaggingTemplate(totalPage, currentPage) {
    var template = "";
    var TotalPages = totalPage;
    var CurrentPage = currentPage;
    var PageNumberArray = Array();


    var countIncr = 1;
    for (var i = currentPage; i <= totalPage; i++) {
        PageNumberArray[0] = currentPage;
        if (totalPage != currentPage && PageNumberArray[countIncr - 1] != totalPage) {
            PageNumberArray[countIncr] = i + 1;
        }
        countIncr++;
    };
    PageNumberArray = PageNumberArray.slice(0, 5);
    var FirstPage = 1;
    var LastPage = totalPage;
    if (totalPage != currentPage) {
        var ForwardOne = currentPage + 1;
    }
    var BackwardOne = 1;
    if (currentPage > 1) {
        BackwardOne = currentPage - 1;
    }

    template = template + '<ul class="pagination">' +
        '<li class="page-item"><a class="page-link" onclick="GetPageData(' + FirstPage + ')">Trang đầu</a></li>' +
        '<a onclick="GetPageData(' + BackwardOne + ')"></a>';

    var numberingLoop = "";
    for (var i = 0; i < PageNumberArray.length; i++) {
        numberingLoop = numberingLoop + '<li class="page-item "><a class="page-link" onclick="GetPageData(' + PageNumberArray[i] + ')" >' + PageNumberArray[i] + '</a></li>'
    }
    template = template + numberingLoop + '<a onclick="GetPageData(' + ForwardOne + ')" ></a>' +

        '<li class="page-item"><a class="page-link" onclick="GetPageData(' + LastPage + ')">Trang cuối</a></li></ul>';
    $("#paged").append(template);
    $('#selectedId').change(function () {
        GetPageData(1, $(this).val());
    });
}