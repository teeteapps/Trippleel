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
    $("#loaderbody").addClass('hide');
    if ($("#categorynameid").val() == "") {
        $("#loaderbody").removeClass('hide');
        alert("nothing to show");
        $("#overlay").style.display = "block";
    } else {
        $.ajax({
            url: "Addproductcategory",
            data: {
                Categoryname : $("#categorynameid").val()
            },
            type: "POST",
            dataType: 'json',
            success: function (e) {
                $("#loaderbody").addClass('hide');
                console.log(JSON.stringify(e));
            },
            error: function (e) {
                console.log(JSON.stringify(e));
            }
        });
    }
    return false;
}