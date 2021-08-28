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
    $.ajax({
        type: "POST", url: "Index.aspx/GetCountriesName", dataType: "json", contentType: "application/json", success: function (res) {
            $.each(res.d, function (data, value) {

                $("#ddlNationality").append($("<option></option>").val(value.CountryId).html(value.CountryName));
            })
        }

    });
}

function loadproductattribute() {
    alert("we are here too");
}
