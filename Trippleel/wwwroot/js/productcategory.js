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
        alert("nothing to show");
        $("#overlay").style.display = "block";
    } else {
        $.ajax({
            url: "Productcategory/Addproductcategory",
            data: $("#form").serialize(),
            type: "POST",
            dataType: 'json',
            success: function (e) {
                console.log(JSON.stringify(e));
            },
            error: function (e) {
                console.log(JSON.stringify(e));
            }
        });
    }
    return false;
}