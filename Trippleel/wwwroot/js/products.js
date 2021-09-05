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
    $("#prodcolorId").empty();
    if ($("#prodattribute option:selected").text() == "Size") {
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
        $("#productcolorrowid").hide();
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

function addproductsdata() {
    $.ajax({
        url: "Addproducts",
        data: {
            Productname: $("#productnameid").val(),
            Productbrand: $("#Productbrandid").val(),
            Categorycode: $("#prodcategory").val(),
            Subcategorycode: $("#prodsubcategoryId").val(),
            Hasattributes: $("#hasattributeid").val(),
            Productattributecode: $("#prodattribute").val(),
            Productattributevaluecode: $("#prodattributevaluesid").val(),
            Productcolorcode: $("#prodcolorId").val()},
        type: "POST",
        dataType: 'json',
        success: function (result) {
            setTimeout(function () { location.reload(); }, 1000);
            if (result.code == 0) {
                $("#producdatamodal").hide();
                toastr.success(result.msg);
            } else if (result.code == 1) {
                toastr.danger(result.msg);
            } else {
                toastr.danger('Database error occured. Kindly contact admin!');
            }
            $("#productnameid").val("");
            $("#Productbrandid").val("");
            $("#prodcategory").empty();
            $("#prodsubcategoryId").empty();
            $("#hasattributeid").empty();
            $("#prodattribute").empty();
            $("#prodattributevaluesid").empty();
            $("#prodcolorId").empty();
        }
    });
    return false;
}

function updateproductvariation() {
    alert("we are here");
    var data = new FormData();
    var Productimagefiles = $("#Productimagefilesid").get(0);
    var files = Productimagefiles.files;
    data.append(files[0].name, files[0]);
    alert(JSON.stringify(data));
    return false;
}
