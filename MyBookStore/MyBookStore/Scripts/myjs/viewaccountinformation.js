$(document).ready(function () {

    //edit username
    $('#edit-username').on("click", function (e) {
        e.preventDefault();
        $('#new-username-div').removeClass('d-none');
        $('#new-username-btn').removeClass('d-none');

    });
    //cancel edit username
    $('#cancel-new-username').on("click", function (e) {
        e.preventDefault();
        $('#new-username').val("");
        $('#new-username-div').addClass('d-none');
        $('#new-username-btn').addClass('d-none');
    });
    //save new username
    $('#save-new-username').on("click", function (e) {
        e.preventDefault();
        let newUsername = $('#new-username').val();
        if (newUsername.trim().length > 5) {
            $('#username').text(newUsername.trim());
            $('#cancel-new-username').click();
        }
        else {
            alert("Tên đăng nhập phải có ít nhất 5 ký tự!");
        }
    });

    //edit address click
    $('#edit-address').on('click', function (e) {
        e.preventDefault();
        $('#new-address-div').removeClass('d-none');
    });
    //cancel edit address click event
    $('#cancel-new-address').on("click", function (e) {
        e.preventDefault();
        $('#new-address').val("");
        $('#new-address-div').addClass('d-none');
    });
    //save new address click event
    $('#save-new-address').on("click", function (e) {
        e.preventDefault();
        let newAddress = $('#new-address').val();
        let minChars = 15;
        if (newAddress.trim().length >= minChars) {
            $('#address').text(newAddress.trim());
            $('#cancel-new-address').click();
        }
        else {
            alert(`Địa chỉ phải có ít nhất ${minChars} ký tự!`);
        }
    });

    //edit phone number click event
    $('#edit-phonenumber').on('click', function (e) {
        e.preventDefault();
        $('#new-phonenumber-div').removeClass('d-none');
        $('#new-phonenumber-btn').removeClass('d-none');
    });

    //cancel edit new phonenumber click
    $('#cancel-new-phonenumber').on('click', function (e) {
        e.preventDefault();
        $('#new-phonenumber').val("");
        $('#new-phonenumber-div').addClass('d-none');
        $('#new-phonenumber-btn').addClass('d-none');
    });
    //save new phonenumber click
    $('#save-new-phonenumber').on('click', function (e) {
        e.preventDefault();
        let newPhonenumber = $('#new-phonenumber').val();
        let minChars = 10;
        if (newPhonenumber.trim().length >= minChars) {
            if (phonenumberValidation(newPhonenumber.trim())) {
                $('#phonenumber').text(newPhonenumber.trim());
                $('#cancel-new-phonenumber').click();
            }
        }
        else {
            alert(`Số điện thoại phải có ít nhất ${minChars} ký tự!`);
        }
    });
    function phonenumberValidation(inputtxt) {
        var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
        if (inputtxt.match(phoneno)) {
            return true;
        }
        else {
            alert("Số điện thoại không chính xác");
            return false;
        }
    };

    //save all click event 
    $('#save-all').on('click', function (e) {
        e.preventDefault();
        let username = $('#username').text();
        let address = $('#address').text();
        let phonenumber = $('#phonenumber').text();
        let customer = {
            Name: username,
            Address: address,
            PhoneNumber: phonenumber,
            Email: $('#email').text()
        };
        $.ajax({
            url: '/account/customer/update-infor',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            },
            data: JSON.stringify(customer)
        }).done(function (data) {
            console.log(data);
            if (data != "") {
                window.location.href = '/books';
            }
        });
    });

    //view detail order click event
    $('.view-detail-order').on('click', function (e) {
        e.preventDefault();
        let orderId = $(this).closest('tr').attr('id');
        $('#table-order-detail>tbody').empty();
        $.ajax({
            url: 'view-order-detail/' + orderId,
            method: 'GET',
            dataType:'json'

        }).done(function (data) {
            let html = "";
            $(data.orderDetails).each(function (index, value) {
                html += '<tr class="small"><td>';
                html += '<img src="/' + value.Image + '" class="img-thumbnail" style="max-width:98px;max-height:98px;" /> </td>';
                html += '<td>' + value.Title + '</td>';
                html += '<td>' + value.Price + '<span>đ</span></td>';
                html += '<td>' + value.OrderQuantity + '</td>';
                html += '<td>' + value.TotalPrice +'<span>đ</span></td></tr>';
            });
            $('#table-order-detail>tbody').append(html);
            $('#receiver').text(data.receiver);
            $('#delivery-address').text(data.deliveryAddress);
            $('#order-detail-modal').modal('show');
        });
    });
});