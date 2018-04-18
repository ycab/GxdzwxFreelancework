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
            dataType: 'text',
            async: true,
            success: function (data) {
                if (data == "none") {
                    alert("请先注册会员用户");
                    window.location.href = rootUrl + "Home/RedirectToRegisterUser";
                }
                else if(data=="nousername")
                {
                    alert("请先完善用户信息");
                    window.location.href = rootUrl + "Home/RedirectToFinishRegisterUser";

                }
                else if(data=="registered")
                {
                    alert("您已注册，无需重复注册");
                }
                else if(data=="factorymember")
                {
                    alert("企业会员不能注册");
                }
                else if (data == "fail")
                {
                    alert("注册失败，当前职业已经注册");
                }
                else
                {
                    alert("注册成功");
                    window.location.href = rootUrl + "Home/GxFreelanceWxClassification";
                }
            }
        })
        return false;
    })
}

