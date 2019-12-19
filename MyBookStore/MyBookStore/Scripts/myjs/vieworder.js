$(document).ready(function () {
    //show div for new delivery address
    $('#edit-delivery-address').on("click", function (e) {
        e.preventDefault();
        $('#new-delivery-div').removeClass('d-none');
    });

    //cancel 
    $('#cancel').on("click", function () {
        $('#new-delivery-div').addClass('d-none');
    });

    //save new delivery address
    $('#save').on("click", function (e) {
        e.preventDefault();
        let newDelivery = $('#new-delivery').val();
        $('#delivery').text(newDelivery);
        $('#new-delivery').val("");
        $('#new-delivery-div').addClass('d-none');
    });
});