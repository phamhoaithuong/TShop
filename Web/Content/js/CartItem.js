/* =========================================
---- Cart controller
=========================================== */
var cart={
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btn-update').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(this).val(),
                    Product: {
                        Id: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: "Cart/Update",
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        })
        //btn delete
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id:$(this).data('id')},
                url: "Cart/Delete",
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        })
    }
}
cart.init();