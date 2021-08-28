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

