var HS_pageIndex = 0;
var HS_pageSize = 10;
var HS_pageCount = 0;
var HS_policeName = "";
var HS_policeId = "";
var SortName_Last = 0;//取大分类数据的截止与开始
var SortName_Amount = 10;//每次取大分类数据的总和
var MiddleSortName_Last = 0;//取中分类数据的截止与开始
var MiddleSortName_Amount = 10;//每次取中分类数据的总和



var page_Init = 0;//页面初始化变量,SortNameInfo与SortGoodsInfo函数异步请求结束后再显示页面
//初始化，异步加载大分类名字
function SortNameInfo() {


    $.ajax({
        type: "POST",
        url: rootUrl + "PersonSort/SortNameInfo?random=" + Math.floor(Math.random() * (100000 + 1)),
        dataType: "json",
        data: { sortname_last: SortName_Last, sortname_amount: SortName_Amount },
        async: true,
        success: function (obj) {
            if (obj.msg == "success") {
                if (SortName_Last == 0) {
                    $("#sortul").append(
                              "<li class='active' data-cat_id='" + obj.sortinfo[0].SEX + "'>" + obj.sortinfo[0].PROFESSION + "</li>"
                              );
                }
                for (var i = 1; i < obj.sortinfo.length; i++) {
                    var sortname = obj.sortinfo[i];

                    $("#sortul").append(
                             "<li  data-cat_id='" + sortname.SEX + "'>" + sortname.PROFESSION + "</li>"

                        );
                }


                SortName_Last += 10;
                if (++page_Init == 2) {
                    $('#loading').hide();
                }
            }
            else {
                $('#loading').hide();
            }

        },
        error: function () {
            alert("ajax wrong!");
            $('#loading').hide();
        }
    });


}
$(document).ready(function () {
    //   SortNameInfo();

    //因为使用ajax动态加载了dom，所以使用普通的click无法绑定click事件，用了$('id').on('click','id',function(){})委托形式
    $('#sidebar').on('click', '#sortul li', function () {
        $(this).addClass('active').siblings('li').removeClass('active');
        var index = $(this).index();
        $('.j-content').eq(index).show().siblings('.j-content').hide();
        $(window).scrollTop(0);
    })

});

function get_asynclist(url, src) {
    SortNameInfo();
    MiddleSortNameInfo();
    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            //   SortNameInfo();
            //取出所有div，并遍历
            //  $("div").each(){
            //判断每一个div，其css中display是否为block
            //     if($(this).css("display")=="block"){
            //  alert('您想要的元素');
            //    }
            //  };
        }
    });

}