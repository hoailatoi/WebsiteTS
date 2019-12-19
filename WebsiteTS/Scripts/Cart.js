var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/Home/Index";

        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/GioHang/ThanhToan";

        });
        $('#btnUpdate').off('click').on('click', function () {
            var listMonan = $('.qty');
            var cartList = [];
            $.each(listMonan, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    Monan: {
                        MaTS: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/GioHang/Update', data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/GioHang/Cart";
                    }
                }

            })

        });
        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/GioHang/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/GioHang/Cart";
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function () {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/GioHang/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/GioHang/Cart";
                    }
                }

            })
        });
    }
}
cart.init();