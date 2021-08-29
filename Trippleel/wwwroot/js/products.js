$('#producdatamodal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var url = button.attr("href");
    var modal = $(this);
    modal.find('.modal-content').load(url);
});
$('#producdatamodal').on('hidden.bs.modal', function () {
    $(this).removeData('bs.modal');
    $('#producdatamodal .modal-content').empty();
});
function loadproductsubcategory() {
    $("#prodsubcategoryId").empty();

    $.ajax({
        type: "GET",
        url: "GetListModelbycode",
        data: { Valcode: $("#prodcategory").val(), Name: "subcategory" },
        dataType: "json",
        contentType: "application/json",
        success: function (subcategories) {
            $("#productsubcategoryrowid").show();
            $.each(subcategories, function (i, subcategory) {
                $("#prodsubcategoryId").append('<option value="' + subcategory.value + '">' + subcategory.text + '</option>');
            });
        }
    });
}

function loadifhasattribute() {
    if ($("#hasattributeid").val() == 1) {
        $("#Attributesrowid").show();
    } else {
        $("#Attributesrowid").hide();
    }
}

function loadproductattribute() {
    $("#prodattributevaluesid").empty();
    if ($("#prodattribute option:selected").text() == "Size") {
        alert($("#prodattribute option:selected").text());
        $.ajax({
            type: 'GET',
            url: 'GetListModelbycode',
            dataType: 'json',
            data: { Valcode: 0, Name: "colors" },
            success: function (attributecolors) {
                $("#productcolorrowid").show();
                $.each(attributecolors, function (i, attributecolor) {
                    $("#prodcolorId").append('<option value="' + attributecolor.value + '">' + attributecolor.text + '</option>');
                });
            }
        });

        $.ajax({
            type: 'GET',
            url: 'GetListModelbycode',
            dataType: 'json',
            data: { Valcode: $("#prodattribute").val(), Name: "attributevalue" },
            success: function (attributevalues) {
                $("#prodattributevaluesrowid").show();
                $.each(attributevalues, function (i, attributevalue) {
                    $("#prodattributevaluesid").append('<option value="' + attributevalue.value + '">' + attributevalue.text + '</option>');
                });
            }
        });
    } else {
        $.ajax({
            type: 'GET',
            url: 'GetListModelbycode',
            dataType: 'json',
            data: { Valcode: $("#prodattribute").val(), Name: "attributevalue" },
            success: function (attributevalues) {
                $("#prodattributevaluesrowid").show();
                $.each(attributevalues, function (i, attributevalue) {
                    $("#prodattributevaluesid").append('<option value="' + attributevalue.value + '">' + attributevalue.text + '</option>');
                });
            }
        });
    }
}