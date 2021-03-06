#pragma checksum "D:\公司\八维\SVN\1603NetM\大一\document\框架\前端\WebSizeDemo\WebSizeDemo\WebSizeDemo.WebSize\Areas\PersonalUser\Views\YouHuiQuan\UsedYouHuiQuanIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e28b470052138e5ede060ccd46237c32473bf237"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_PersonalUser_Views_YouHuiQuan_UsedYouHuiQuanIndex), @"mvc.1.0.view", @"/Areas/PersonalUser/Views/YouHuiQuan/UsedYouHuiQuanIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/PersonalUser/Views/YouHuiQuan/UsedYouHuiQuanIndex.cshtml", typeof(AspNetCore.Areas_PersonalUser_Views_YouHuiQuan_UsedYouHuiQuanIndex))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e28b470052138e5ede060ccd46237c32473bf237", @"/Areas/PersonalUser/Views/YouHuiQuan/UsedYouHuiQuanIndex.cshtml")]
    public class Areas_PersonalUser_Views_YouHuiQuan_UsedYouHuiQuanIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 3 "D:\公司\八维\SVN\1603NetM\大一\document\框架\前端\WebSizeDemo\WebSizeDemo\WebSizeDemo.WebSize\Areas\PersonalUser\Views\YouHuiQuan\UsedYouHuiQuanIndex.cshtml"
  
    ViewData["Title"] = "我的优惠券";

#line default
#line hidden
            BeginContext(45, 3967, true);
            WriteLiteral(@"
<div id=""orders"" class=""tab-pane fade show active"">
    <h3>Orders</h3>
    <div class=""table-responsive"">
        <table class=""table"" id=""orders"" v-cloak>
            <thead>
                <tr>
                    <th>优惠券编号</th>
                    <th>优惠券标题</th>
                    <th>优惠券类型</th>
                    <th>优惠券平台</th>
                    <th>优惠券品类</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for=""(item,index) in orderList"">
                    <td>{{item.youhuiquan_code}}</td>
                    <td>{{item.youhuiquan_title}}</td>
                    <td>{{item.youhuiquan_type}}</td>
                    <td>{{item.youhuiquan_pingtai}} </td>
                    <td>{{item.youhuiquan_pinlei}}</td>
                </tr>

            </tbody>
        </table>
        <div id=""page"" class=""page""></div>
    </div>
</div>
<script>
    var vm = new Vue({
        el: ""#orders"",
        data: {
           orderList: []
    ");
            WriteLiteral(@"    },
        mounted() {
            this.getOrders(1);
        },
        methods: {
            getOrders: function (curPage) {
                //ajax方式一样能实现效果,vue推荐用axios代替
                //$.ajax({
                //    url: ""http://127.0.0.1/Users/GetUsers"",
                //    type: ""get"",
                //    data: {
                //        KeyWord: $(""#txt_UserName"").val()
                //    },
                //    success: function (data) {
                //        $(data).each(function (index, data) {
                //            userList.push(data);
                //            $(""#tData"").append(""<tr><td><input class='cks' value='"" + data.PersonID + ""' type='checkbox' /></td><td>"" + data.PersonName + ""</td><td>"" + data.PersonGender + ""</td><td>"" + data.PersonHobby + ""</td><td><img src='"" + data.PersonImg + ""' /></td><td>"" + data.AreaSpaceName + ""</td><td>"" + data.CityName + ""</td><td>"" + data.State + ""</td><td><a href='#' onclick='DeletePerson("" + data.PersonID + "")'");
            WriteLiteral(@">删除</a><a href='/Person/UpdatePerson?pId="" + data.PersonID + ""'>修改</a></td><td><input id='Button1' type='button' onclick='UpdateState("" + data.PersonID + "")' value='"" + (data.State == ""开启"" ? ""关闭"" : ""开启"") + ""' /></td></tr>"")
                //        })

                //    }
                //})
                axios.get(webSizeConfig.apiHost + ""/api/UserManager/YouHuiQuan/UsableYouHuiQuanGetPageList?pageIndex="" + curPage + ""&pageSize="" + webSizeConfig.pageSize +""&youhuiquan_state=1""
                    , {
                    headers: {


                        'token': webSizeConfig.token

                    }
                }).then(
                    (response) => {
                        if (response.data.result_code == webSizeConfig.resultOk) {
                          //  this.orderList = [];
                            //for (var i = 0; i < response.data.result_data.orderList.length; i++) {
                            //    this.orderList.push(response.data.result_data.orderL");
            WriteLiteral(@"ist[i]);
                            //}
                            this.orderList = response.data.result_data.orderList;
                            showPage(curPage, response.data.result_data.rowCount);
                        }

                    }
                ).catch(function (response) {
                    layer.msg('error!<br/>' + response, { icon: 1 });
                });
            }

        }
    });

    function showPage(curPage, dataTotal) {
        var pageObj = new Page({
            id: 'page',         //和页面分页DIV的ID对应，不传默认是'page'
            curPage: curPage,   //当前页码
            pageAmount: webSizeConfig.pageSize,      //每页多少条
            dataTotal: dataTotal,      //总条数，通过后台返回传入，总页数自动计算
            getPage: function (page) {
                //回调方法
                vm.getOrders(page);
            }
        })
    }

</script>

");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
