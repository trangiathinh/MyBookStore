$(document).ready(function () {
    //remove item from cart
    $(".remove-item").on("click", function (e) {
        let bookId = $(this).closest('tr').attr('id');
        $.ajax({
            url: '/customer/shopping-cart/remove-from-cart/' + bookId,
            method: 'GET'
        }).done(function () {
            window.location.href = "/customer/shopping-cart";
        });
    });

    //update quantity from cart item
    $('.quantity').on("change", function (e) {
        e.preventDefault();
        let quantity = $(this).val();
        let bookId = $(this).closest('tr').attr('id');
        $.ajax({
            url: '/customer/shopping-cart/update-from-cart/' + bookId + '/' + quantity,
            method: 'GET'
        }).done(function () {
            window.location.href = "/customer/shopping-cart";
        });
    });
});