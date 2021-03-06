$('#productattributesmodal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var url = button.attr("href");
    var modal = $(this);
    modal.find('.modal-content').load(url);
});
$('#productattributesmodal').on('hidden.bs.modal', function () {
    $(this).removeData('bs.modal');
    $('#productattributesmodal .modal-content').empty();
});


function addproductattribute() {
    if ($("#attributenameid").val() == "") {
        return false;
    } else {
        $.ajax({
            url: "Addproductattributes",
            data: {
                Attributename: $("#attributenameid").val()
            },
            type: "POST",
            dataType: 'json',
            success: function (result) {
                setTimeout(function () { location.reload(); }, 1000);
                if (result.code == 0) {
                    $("#productattributesmodal").hide();
                    toastr.success(result.msg);
                } else if (result.code == 1) {
                    toastr.danger(result.msg);
                } else {
                    toastr.danger('Database error occured. Kindly contact admin!');
                }
                $("#attributenameid").val("");
            }
        });
    }
    return false;
}

function productattributedetails(productattributeid, productattributename) {
    $("#productattributevaluesdatacard").empty();
    $.ajax({
        url: "Getattributedetails",
        data: {
            Attributecode: productattributeid, Attributename: productattributename
        },
        type: "Get",
        dataType: 'html',
        success: function (result) {
            $("#productattributevaluesdatacard").html(result);
        }
    });
}

function addattributevalues() {
    if ($("#attributevalnameid").val() == "") {
        return false;
    } else {
        $.ajax({
            url: "Addproductattributevalues",
            data: {
                Attributecode: $("#attributecodeid").val(), Attributevalname: $("#attributevalnameid").val()
            },
            type: "POST",
            dataType: 'json',
            success: function (result) {
                setTimeout(function () { location.reload(); }, 1000);
                if (result.code == 0) {
                    $("#productattributesmodal").hide();
                    toastr.success(result.msg);
                } else if (result.code == 1) {
                    toastr.danger(result.msg);
                } else {
                    toastr.danger('Database error occured. Kindly contact admin!');
                }
                $("#attributecodeid").val("");
                $("#attributevalnameid").val("");
            }
        });
    }
    return false;
}