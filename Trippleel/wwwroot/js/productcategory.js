$('#productcategorymodal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var url = button.attr("href");
    var modal = $(this);
    modal.find('.modal-content').load(url);
});
$('#productcategorymodal').on('hidden.bs.modal', function () {
    $(this).removeData('bs.modal');
    $('#productcategorymodal .modal-content').empty();
});


function addproductcategory() {
    if ($("#categorynameid").val() == "") {
    } else {
        $.ajax({
            url: "Addproductcategory",
            data: {
                Categoryname: $("#categorynameid").val()
            },
            type: "POST",
            dataType: 'json',
            success: function (result) {
                setTimeout(function () { location.reload(); }, 3000);
                if (result.code == 0) {
                    $("#productcategorymodal").hide();
                    toastr.success(result.msg);
                } else if (result.code == 1) {
                    toastr.danger(result.msg);
                } else {
                    toastr.danger('Database error occured. Kindly contact admin!');
                }
                $("#categorynameid").val("");
            }
        });
    }
    return false;
}

function productcategorydetails(productcategoryid) {
    $("#productsubcategorydatacard").empty();
    $.ajax({
        url: "Getcategorydetails",
        data: {
           categorycode: productcategoryid
        },
        type: "Get",
        dataType: 'html',
        success: function (result) {
            $("#productsubcategorydatacard").html(result);
        }
    });
}