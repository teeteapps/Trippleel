var Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000
});

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
            success: function (result) {
                setTimeout(function () { location.reload(); }, 2000);
                if (result.code === 0) {
                    Toast.fire({ icon: 'danger', title: result.msg });
                } else {
                    Toast.fire({ icon: 'success', title: result.msg });
                }
                $("#productcategorymodal").hide();
                $("#categorynameid").val("");
            }
        });
    }
    return false;
}