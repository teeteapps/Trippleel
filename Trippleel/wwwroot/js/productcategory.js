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