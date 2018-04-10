$(function () {
    clickevent();
})

var clickevent = function () {
    $(".submit").click(function () {
        //var options = {
        //    type: "POST",
        //    url: rootUrl + "Home/Register?random=" + Math.floor(Math.random() * (100000 + 1)),
        //    data: $("#theForm").serialize(),
        //    dataType: "text",
        //    success: function (response) {
        //        if (response == 'success') {
        //            window.location.href = rootUrl + "Register/GxLoginRegisterThree";
        //        }
        //    }, error: function (xhr) { alert(xhr.responseText) }
        //};
        //// 将options传给ajaxForm
        //$('#theForm').ajaxSubmit(options);
        //$('#theForm').ajaxSubmit(options);
        $.ajax({
            type: 'post',
            url: rootUrl + "Home/Register?random=" + Math.floor(Math.random() * (100000 + 1)),
            data: $("#theForm").serialize(),
            dataType: 'json',
            async: true,
            success: function (data) {
                if (data.NAME != null) {
                    window.location.href = rootUrl + "Register/GxLoginRegisterThree";
                }
            }
        })
    })
}

