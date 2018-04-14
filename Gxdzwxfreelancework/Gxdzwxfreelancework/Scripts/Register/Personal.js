

$(function () {

    $('.js_file_chat_head').on('change', function (event) {
        var files = event.target.files;
        // 允许上传的图片类型  
        var allowTypes = ['image/jpg', 'image/jpeg', 'image/png', 'image/gif'];
        // 1024KB，也就是 1MB  
        var maxSize = 4 * 1024 * 1024;
        // 图片最大宽度  
        var maxWidth = 300;
        // 最大上传图片数量  
        var maxCount = 1;
        // 如果没有选中文件，直接返回  
        if (files.length === 0) {
            return;
        }

        for (var i = 0, len = files.length; i < len; i++) {
            var file = files[i];
            var reader = new FileReader();

            // 如果类型不在允许的类型范围内  
            if (allowTypes.indexOf(file.type) === -1) {
                $.weui.alert({
                    text: '该类型不允许上传'
                });
                continue;
            }

            if (file.size > maxSize) {
                $.weui.alert({
                    text: '图片太大，不允许上传'
                });
                continue;
            }

            if ($('.chat_head_flag').length >= maxCount) {
                $.weui.alert({
                    text: '最多只能上传' + maxCount + '张图片'
                });
                return;
            }

            reader.onload = function (e) {
                var img = new Image();
                img.onload = function () {
                    // 不要超出最大宽度  
                    var w = Math.min(maxWidth, img.width);
                    // 高度按比例计算  
                    var h = img.height * (w / img.width);
                    var canvas = document.createElement('canvas');
                    var ctx = canvas.getContext('2d');
                    // 设置 canvas 的宽度和高度  
                    canvas.width = w;
                    canvas.height = h;
                    ctx.drawImage(img, 0, 0, w, h);
                    var base64 = canvas.toDataURL('image/png');

                    // 插入到预览区  
                    var $preview = $('<li class="weui_uploader_file weui_uploader_status chat_head_flag" style="background-image:url(' + base64 + ')"><div class="weui_uploader_status_content">0%</div></li>');
                    $('.view_chat_head').append($preview);
                    var num = $('.chat_head_flag').length;
                    $('.js_counter_chat_head').text(num + '/' + maxCount);

                    // 然后假装在上传，可以post base64格式，也可以构造blob对象上传，也可以用微信JSSDK上传  

                    var progress = 0;

                    function uploading() {
                        $preview.find('.weui_uploader_status_content').text(++progress + '%');
                        if (progress < 100) {
                            setTimeout(uploading, 10);
                        } else {
                            // 如果是失败，塞一个失败图标  
                            //$preview.find('.weui_uploader_status_content').html('<i class="weui_icon_warn"></i>');  
                            $preview.removeClass('weui_uploader_status').find('.weui_uploader_status_content').remove();
                        }
                    }
                    setTimeout(uploading, 10);
                };

                img.src = e.target.result;
            };
            reader.readAsDataURL(file);
        }
    });
});

$(function () {

    $('.js_file_id_card').on('change', function (event) {
        var files = event.target.files;
        // 允许上传的图片类型  
        var allowTypes = ['image/jpg', 'image/jpeg', 'image/png', 'image/gif'];
        // 1024KB，也就是 1MB  
        var maxSize = 4 * 1024 * 1024;
        // 图片最大宽度  
        var maxWidth = 300;
        // 最大上传图片数量  
        var maxCount = 1;
        // 如果没有选中文件，直接返回  
        if (files.length === 0) {
            return;
        }

        for (var i = 0, len = files.length; i < len; i++) {
            var file = files[i];
            var reader = new FileReader();

            // 如果类型不在允许的类型范围内  
            if (allowTypes.indexOf(file.type) === -1) {
                $.weui.alert({
                    text: '该类型不允许上传'
                });
                continue;
            }

            if (file.size > maxSize) {
                $.weui.alert({
                    text: '图片太大，不允许上传'
                });
                continue;
            }

            if ($('.id_card_flag').length >= maxCount) {
                $.weui.alert({
                    text: '最多只能上传' + maxCount + '张图片'
                });
                return;
            }

            reader.onload = function (e) {
                var img = new Image();
                img.onload = function () {
                    // 不要超出最大宽度  
                    var w = Math.min(maxWidth, img.width);
                    // 高度按比例计算  
                    var h = img.height * (w / img.width);
                    var canvas = document.createElement('canvas');
                    var ctx = canvas.getContext('2d');
                    // 设置 canvas 的宽度和高度  
                    canvas.width = w;
                    canvas.height = h;
                    ctx.drawImage(img, 0, 0, w, h);
                    var base64 = canvas.toDataURL('image/png');

                    // 插入到预览区  
                    var $preview = $('<li class="weui_uploader_file weui_uploader_status id_card_flag" style="background-image:url(' + base64 + ')"><div class="weui_uploader_status_content">0%</div></li>');
                    $('.view_id_card').append($preview);
                    var num = $('.id_card_flag').length;
                    $('.js_counter_id_card').text(num + '/' + maxCount);

                    // 然后假装在上传，可以post base64格式，也可以构造blob对象上传，也可以用微信JSSDK上传  

                    var progress = 0;

                    function uploading() {
                        $preview.find('.weui_uploader_status_content').text(++progress + '%');
                        if (progress < 100) {
                            setTimeout(uploading, 10);
                        } else {
                            // 如果是失败，塞一个失败图标  
                            //$preview.find('.weui_uploader_status_content').html('<i class="weui_icon_warn"></i>');  
                            $preview.removeClass('weui_uploader_status').find('.weui_uploader_status_content').remove();
                        }
                    }
                    setTimeout(uploading, 10);
                };

                img.src = e.target.result;
            };
            reader.readAsDataURL(file);
        }
    });
});

var handler = function (e) { //禁止浏览器默认行为
    e.preventDefault();
};
$(function () {
    $("input").on("focus", function () {
        this.scrollIntoView();
    })
    clickevent();
})
function clickevent() {
    $('a').unbind("click"); //移除click
    $(".submit").click(publish);
    current();
}
var publish = function () {
    var options = {
        type: "POST",
        url: rootUrl + "Home/SetPersonalInfo?random=" + Math.floor(Math.random() * (100000 + 1)),
        data: $("#theForm").serialize(),
        dataType: "text",
        success: function (response) {
            if (response == "success") {
                alert("完善成功");
                window.location.href = rootUrl + "Home/GxFreelanceWxLogin";
            }
            //window.location.href = rootUrl + "Register/GxLoginRegisterThree";
        }
    }
    $('#theForm').ajaxSubmit(options);
}
function current() {
    $.ajax({
        type: "post",
        url: rootUrl + "OrderDown/GetOrderDown?random=" + Math.floor(Math.random() * (100000 + 1)),
        data: $("#userform").serialize(),
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data.SIZE_WIDTH != "")
                window.location.href = rootUrl + "Order/GxPcbWxOrderTwo";
        }
    });
}


var chat_head_not_null = "头像不能为空！";
var nick_name_not_null = "昵称不能为空！";
var signature_not_null = "个性签名不能为空！";
var name_not_null = "姓名不能为空！";
var id_number_not_null = "企业名称不能为空！";
var sex_not_null = "企业所属行业不能为空！";
var age_not_null = "企业介绍不能为空！";
var industry_involved_not_null = "营业执照不能为空！";
var company_not_null = "企业加工能力及产品介绍不能为空！";
var profession_not_null = "证书不能为空！";
var tel_not_null = "电话不能为空！";
var fax_not_null = "传真不能为空！";
var email_not_null = "邮箱不能为空！";
var id_card_not_null = "地址不能为空！";
var aCity = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外" }
function checkInfo(frm) {
    var msg = new Array();
    var err = false;

    if (Utils.isEmpty(frm.elements['chat_head'].value)) {
        err = true;
        msg.push(chat_head_not_null);
    }
    if (Utils.isEmpty(frm.elements['nick_name'].value)) {
        err = true;
        msg.push(nick_name_not_null);
    }
    if (Utils.isEmpty(frm.elements['signature'].value)) {
        err = true;
        msg.push(signature_not_null);
    }
    if (Utils.isEmpty(frm.elements['name'].value)) {
        err = true;
        msg.push(name_not_null);
    }
    if (Utils.isEmpty(frm.elements['id_number'].value)) {
        err = true;
        msg.push(id_number_not_null);
    }
    else {
        var sID = frm.elements['id_number'].value;
        function isCardID(sId) {
            var iSum = 0;
            var info = "";
            if (!/^\d{17}(\d|x)$/i.test(sId))
                return "身份证号不正确";
            sId = sId.replace(/x$/i, "a");
            if (aCity[parseInt(sId.substr(0, 2))] == null)
                return "身份证号不正确";
            sBirthday = sId.substr(6, 4) + "-" + Number(sId.substr(10, 2)) + "-" + Number(sId.substr(12, 2));
            var d = new Date(sBirthday.replace(/-/g, "/"));
            if (sBirthday != (d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate()))
                return "身份证号不正确";
            for (var i = 17; i >= 0; i--) iSum += (Math.pow(2, i) % 11) * parseInt(sId.charAt(17 - i), 11);
            if (iSum % 11 != 1)
                return "身份证号不正确";
            //aCity[parseInt(sId.substr(0,2))]+","+sBirthday+","+(sId.substr(16,1)%2?"男":"女") ;//此次还可以判断出输入的身份证号的人性别
            return true;
        }
        if (sID != "true") {
            err = true;
            msg.push("身份证号不正确");
        }
    }
    if (Utils.isEmpty(frm.elements['sex'].value)) {
        err = true;
        msg.push(sex_not_null);
    }
    if (Utils.isEmpty(frm.elements['age'].value)) {
        err = true;
        msg.push(age_not_null);
    }
    if (Utils.isEmpty(frm.elements['industry_involved'].value)) {
        err = true;
        msg.push(industry_involved_not_null);
    }
    if (Utils.isEmpty(frm.elements['company'].value)) {
        err = true;
        msg.push(company_not_null);
    }
    if (Utils.isEmpty(frm.elements['profession'].value)) {
        err = true;
        msg.push(profession_not_null);
    }
    if (Utils.isEmpty(frm.elements['tel'].value)) {
        err = true;
        msg.push(tel_not_null);
    }
    if (Utils.isEmpty(frm.elements['fax'].value)) {
        err = true;
        msg.push(fax_not_null);
    }
    if (Utils.isEmpty(frm.elements['email'].value)) {
        err = true;
        msg.push(email_not_null);
    }
    //if (Utils.isEmpty(frm.elements['id_card'].value)) {
    //    err = true;
    //    msg.push(id_card_not_null);
    //}
    if (err) {
        message = msg.join("\n");
        alert(message);
    }

    return !err;
}
