<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    MasterPageFile="~/MasterPage/LoginMasterPage.master" ClientIDMode="Static" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<meta http-equiv="refresh" content="0; url=OtherPages/Login.aspx" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../App_Themes/AISSlideshow/css/slideshow.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../App_Themes/AISSlideshow/js/jquery.slideshow.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.callbackSlideShow').slideShow({
                interval: 3,
                slideClick: function (slideShow) {
                    if (slideShow.mouse.x > slideShow.options.slideSize.width / 2) {
                        slideShow.next();
                    } else {
                        slideShow.previous();
                    }
                },
                gotoSlide: function (slideShow, index) {
                    $('.callBackSlideShowLog').html('goto slide index: ' + index);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="banner" style="padding: 0; background-image: none; background-color: #eee;
        margin-bottom: 40px;">
        <div class="col-sm-12">
            <%--<asp:Image ID="imgcompanylogo" ImageUrl="~/App_Themes/AISSlideshow/images/epathshala-logo.png"
                runat="server" AlternateText="School Logo" Style="position: absolute; top:0;  width:25%; z-index: 1000;" />--%>
        </div>
        <div id="bannerwrap" runat="server">
            <div class="callbackSlideShow slideShow" id="dvslideShow" runat="server">
                <ul class="slides">
                    <li class="slide" style="position: absolute; display: none;">
                        <%--   <h2>
                            Aspire to build strong foundation for students based on the value of knowledge.</h2>--%>
                        <a href="Registration.aspx">
                            <img alt="" src="../App_Themes/Green/Images/home-carosal-1.jpg" /></a> </li>
                    <li class="slide" style="position: absolute; display: none;">
                        <%--  <h2>
                            Nurturing future leaders and global citizens.</h2>--%>
                            <a href="Registration.aspx">
                        <img border="0" alt="" src="../App_Themes/Green/images/home-carosal-2.jpg" /></a>
                    </li>
                    <li class="slide" style="position: absolute; display: none;">
                        <%-- <h2>
                            Learning is acquiring new knowledge, behaviors, skills, values or preferences.</h2>--%>
                            <a href="Registration.aspx">
                        <img border="0" alt="" src="../App_Themes/Green/images/home-carosal-3.jpg" /></a>
                    </li>
                    <li class="slide" style="position: absolute; display: none;">
                        <%--  <h2>
                            Developing the intellectual, aesthetic, moral, physical and social potential of
                            the students.</h2>--%>
                            <a href="Registration.aspx">
                        <img border="0" alt="" src="../App_Themes/Green/images/home-carosal-4.jpg" /></a>
                    </li>
                </ul>
                <span></span>
                <ul class="navigation">
                    <li><a class="page" href="javascript:void(0);">1</a></li>
                    <li><a class="page" href="javascript:void(0);">2</a></li>
                    <li><a class="page" href="javascript:void(0);">3</a></li>
                    <li><a class="page" href="javascript:void(0);">4</a></li>
                </ul>
            </div>
        </div>
    </div>
    <asp:Label ID="lblError1" runat="server"></asp:Label>
</asp:Content>
