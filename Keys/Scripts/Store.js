/// <reference path="../scripts/jquery-3.3.1.min.js" />
/// <reference path="../scripts/knockout-3.4.2.debug.js" />


$(document).ready(function () {
    (function ($) {

        var contactInfo = {
            Name: ko.observable("").extend({ required: true, minLength: 2, maxLength: 7 }),
            Address: ko.observable("").extend({ required: true, minLength: 2, maxLength: 200 })
        };


        ko.applyBindings(contactInfo);
    }($))
    $("#btnSubmit").click(function () {
        var data = $("#myForm").serialize();
        if (!$("#myForm").valid()) {
            return false;
        }
        debugger
        $.ajax({
            type: "POST",
            url: "/Stores/Index",
            data: data,
            success: function (response) {
                $("#myModal").modal("hide");
                window.location.href = "/Stores/Index";
            }
        })
    })
})
var ConfirmDelete = function (storeId) {
    $("#hiddenStoreId").val(storeId);
    $("#myModalDelete").modal('show');
}
var DeleteStore = function () {
    var sId = $("#hiddenStoreId").val();
    $.ajax({
        type: "POST",
        url: "/Stores/DeleteStore",
        data: { storeId: sId },
        success: function (result) {
            $("#myModalDelete").modal("hide");
            $("#row_" + sId).remove();
        }
    })
}
var EditStore = function (storeId) {
    var url = "/Stores/EditStore?storeId=" + storeId;
    $("#myModalBodyDiv1").load(url, function () {
        $("#myModal1").modal("show");
    })
}