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

    //place order click
    $('#place-order').on("click",function (e) {
        e.preventDefault();
        var deliveryAddress = $('#delivery').text();
        console.log(deliveryAddress);
        $.ajax({
            url: '/customer/shopping-cart/place-order/' + deliveryAddress,
            method: 'GET'
        }).done(function (data) {
            console.log(data);
            if (data != "") {
                window.location.href = data;
            }
            else {
                alert("Failure");
            }
        });
    });


});