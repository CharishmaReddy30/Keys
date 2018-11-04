$(document).ready(function () {
    $("#btnSubmit").click(function () {
        var data = $("#myForm").serialize();
        if (!$("#myForm").valid()) {
            return false;
        }
        $.ajax({
            type: "POST",
            url: "/ProductSolds/Index",
            data: data,
            success: function (response) {
                var message = $("#date");
                if (response) {
                    $("#myModal").modal("hide");
                    window.location.href = "/ProductSolds/Index";
                }
                else {
                    message.html("Date should be less than Today's Date!");
                }
            }
        })
    })
})
var ConfirmDelete = function (saleId) {
    $("#hiddenSaleId").val(saleId);
    $("#myModalDelete").modal('show');
}
var DeleteSale = function () {
    var sId = $("#hiddenSaleId").val();
    $.ajax({
        type: "POST",
        url: "/ProductSolds/DeleteSale",
        data: { saleId: sId },
        success: function (result) {
            $("#myModalDelete").modal("hide");
            $("#row_" + sId).remove();
        }
    })
}
var EditSale = function (saleId) {
    var url = "/ProductSolds/EditSale?saleId=" + saleId;
    $("#myModalBodyDiv1").load(url, function () {
        $("#myModal1").modal("show");
    })

}