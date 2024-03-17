//Mesaj Gönderimi
$(document).ready(function () {
    $("#btnMsjGonder").click(function () {


        $.ajax({
            type: "POST",
            url: "/Contact/SendMessage",
            data: $("#contactForm").serialize(),
            dataType: "json",
            encode: true,
        })
            .done(function (data) {

                Swal.fire(
                    'Mesajınız Başarıyla Gönderildi',
                    '',
                    'success'
                ),
                    document.getElementById("contactForm").reset();
                $("#btnMsjGonder").hide();
                console.log(data);
            })
            .fail(function (data) {
                Swal.fire(
                    'Mesaj Gönderilemedi',
                    data,
                    'error'
                ),
                    console.log(data);
            });
    });
});
//Rezervasyon Kayıt
$(document).ready(function () {
    $("#btnReservationNow").click(function () {


        $.ajax({
            type: "POST",
            url: "/Reservation/CreateReservation",
            data: $("#reservationForm").serialize(),
            dataType: "json",
            encode: true,
        })
            .done(function (data) {

                Swal.fire(
                    'Rezervasyon İşleminiz Tamamlandı',
                    '',
                    'success'
                ),
                    document.getElementById("reservationForm").reset();
                $("#btnReservationNow").hide();
                console.log(data);
            })
            .fail(function (data) {
                Swal.fire(
                    'Rezervasyon Başarısız, Tekrar Deneyin',
                    data,
                    'error'
                ),
                    console.log(data);
            });
    });
});