﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Landing.aspx.cs" Inherits="Landing"
    MasterPageFile="~/MasterPage/CommonHeaderFooter.master" %>

<%--<%@ Register Src="~/UserControl/LoginControl.ascx" TagName="ReportControl" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-69363607-1', 'auto');
        ga('send', 'pageview');

    </script>
    <style type="text/css">
        body, html
        {
            font-family: Open Sans,sans-serif;
        }
        .Columns
        {
            padding: 15px;
            border-radius: 2px;
            min-height: 150px;
            margin-bottom: 20px;
        }
        .yellow-content-area
        {
            padding: 15px;
            background-color: #F5CB21;
            border-radius: 2px;
            font-size: 14px;
        }
        .yellow-content-area h4
        {
            font-size: 16px;
            margin: 0px;
            line-height: 18px;
            font-weight: bold;
            color: #000;
            text-transform: capitalize;
        }
        .yellow-content-area p
        {
            font-size: 16px;
            margin: 0px;
            line-height: 18px;
            color: #000;
            font-style: italic;
            text-transform: capitalize;
            padding-top: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--  <div id="navbar" class="kw_header container-fluid" role="banner" style="padding: 0px;">
        <div class="navbar navbar-default" style="background: none; border: none; box-shadow: none;
            padding-top: 15px;">
            <div class="container">
                <div class="navbar-header">
                    <div class="col-sm-2">
                        <div class="logo">
                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                                <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                                    class="icon-bar"></span><span class="icon-bar"></span>
                            </button>
                        </div>
                    </div>
                </div>
                <div id="myNavbar" class="collapse navbar-collapse">
                    <nav role="navigation" style="margin-top: 5px;">
            <center>
              <ul class="nav navbar-nav" style="height:auto;" >
                    <li ><a href="Landing.htm"><!--<span class="glyphicon glyphicon-home"></span>--><img src="App_Themes/Green/Images/home.png" /></a></li>
                    <li><a href="OtherPages/AboutUs.aspx"><!--<span class="glyphicon glyphicon-info-sign"></span>-->
                    <img src="App_Themes/Green/Images/aboutus.png" alt="About Us" />
                    
                        </a></li>
                    <li><a href="OtherPages/ContactUs.aspx"><!--<span class="glyphicon glyphicon-phone-alt"></span>--><img src="App_Themes/Green/Images/Contact-us.png"  />
                        </a></li>
                </ul>
              <ul class="nav navbar-nav navbar-right">
              <li><a href="OtherPages/Registration.aspx"><!--<span class="glyphicon glyphicon-log-in"></span>--><img src="App_Themes/Green/Images/signup.png" alt="Registration" /></a>
                    </li>

                    <li><a id="btnmplogin" runat="server" href="OtherPages/Login.aspx"><!--<span class="glyphicon glyphicon-log-in"></span>--><img src="App_Themes/Green/Images/login.png" alt="Login" /></a>
                    </li>
                </ul>
                </center>
            </nav>
                </div>
            </div>
        </div>
    </div>--%>
    <div class="container">
        <br />
        <div class="row">
            <div class="col-sm-12">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <div class="item active">
                            <a href="Registration.aspx">
                                <img class="img-responsive" src="../App_Themes/Green/Images/home-carosal-1.png" alt="Item1" /></a>
                        </div>
                        <div class="item">
                            <a href="Registration.aspx">
                                <img class="img-responsive" src="../App_Themes/Green/Images/home-carosal-2.png" alt="Item2" />
                            </a>
                        </div>
                        <div class="item">
                            <a href="Registration.aspx">
                                <img class="img-responsive" src="../App_Themes/Green/Images/home-carosal-3.png" alt="Item3" /></a>
                        </div>
                        <div class="item">
                            <a href="Registration.aspx">
                                <img class="img-responsive" src="../App_Themes/Green/Images/home-carosal-4.png" alt="Item4" />
                            </a>
                        </div>
                    </div>
                    <!-- Left and right controls -->
                    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev"
                        style="width: 4%;"><span class="glyphicon glyphicon-chevron-left" aria-hidden="true">
                        </span><span class="sr-only">Previous</span> </a><a class="right carousel-control"
                            href="#myCarousel" style="width: 4%;" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right"
                                aria-hidden="true"></span><span class="sr-only">Next</span> </a>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
        <div class="col-sm-12">
            <a href="http://www.evolveassessment.com/" target="_blank">
            <img class="img-responsive" src="../App_Themes/Home/img/evolvebanner.png" alt="evolvebanner"  />
            </a>
        </div>
           
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <div class="Columns" style="background: #71AF32;">
                    <div class="media">
                        <div class="media-body">
                            <div class="media-heading">
                                <h4>
                                    ePathshala</h4>
                            </div>
                            ePathshala is a technology enabled educational product which changes the way students
                            learn anywhere and anytime.
                        </div>
                        <div class="media-right">
                            <a href="#Epara">
                                <img src="../App_Themes/Green/Images/icon1.png" alt="ePathshala" class="img-responsive" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="Columns" style="background: #3F88C5;">
                    <div class="media">
                        <div class="media-body">
                            <div class="media-heading">
                                <h4>
                                    Educational Initiatives</h4>
                            </div>
                            ePathshala has digitized various educational school board curriculum and converted
                            using easy to learn experiential learning models.
                        </div>
                        <div class="media-right">
                            <a href="#">
                                <img src="../App_Themes/Green/Images/icon2.png" alt="Educational Initiatives" class="img-responsive" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="Columns" style="background: #F5CB21;">
                    <div class="media">
                        <div class="media-body">
                            <div class="media-heading">
                                <h4>
                                    ePathashala Demo</h4>
                            </div>
                            ePathshala demo videos will let you experience and explain how our digital content
                            increases efficiency and effectiveness of students.
                        </div>
                        <div class="media-right">
                            <a href="#Demovideo">
                                <img src="../App_Themes/Green/Images/icon3.png" alt="ePathshala Demo" class="img-responsive" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <a href="#" style="float: none; display: block; text-align: center;">
                    <img src="../App_Themes/Green/Images/did-you-know.png" alt="did you know" class="img-responsive"
                        style="display: inline; padding-top: 20px;" />
                </a>
            </div>
            <div class="col-sm-4">
                <a href="#" style="float: none; display: block; text-align: center;">
                    <img src="../App_Themes/Green/Images/learning-style.png" alt="Learning Style" class="img-responsive"
                        style="display: inline; padding-top: 20px;" />
                </a>
            </div>
            <div class="col-sm-4">
                <a href="#" style="float: none; display: block; text-align: center;">
                    <img src="../App_Themes/Green/Images/secondary-student.png" alt="Secondary Student"
                        class="img-responsive" style="display: inline; padding-top: 20px;" />
                </a>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-8">
                <div class="panel panel-primary" style="border: none;">
                    <div class="panel-heading" style="background-color: #5A42B4; color: White; font-size: 20px;
                        background-image: none;">
                        <div id="Epara">
                            ePathshala - Transforming Learning Through Technology
                        </div>
                    </div>
                    <div class="panel-body" style="font-size: 14px; padding: 15px; text-align: justify;">
                        <p>
                            The revolutionary Right to Education Act (2009) marks a historic moment for the
                            children of India. It is a major challenge to provide lakhs of Indian children free
                            and compulsory education. The integrated education product, ePathshala from ePath
                            is a milestone that aims to provide a ripe platform for children of all learning
                            levels thereby making provision for those put to disadvantage because of social,
                            cultural, economical, geographical, linguistic and gender anomalies.
                            <br />
                            <br />
                            ePath is an all-inclusive education initiative by Arraycom (India) Limited. The
                            group has over 20 years of experience in manufacturing of electronic materials,
                            broadcasting systems and communication system integration. The group also has vast
                            experience in the field of education with well-known initiatives like Ahmedabad
                            International School (AIS) in Ahmedabad and Toddlers' Den Preschools in Ahmedabad
                            and Vadodara. ePath is the result of educational and technological expertise of
                            the group. ePath is equipped with ideal tools to take on the challenges faced by
                            the education system.
                            <br />
                            <br />
                            ePath provides opportunity to students to be constantly involved in the education
                            process through experiential learning thereby giving them the potential to transform
                            and grow into empowered individuals.
                        </p>
                        <div class="yellow-content-area">
                            <h4>
                                Experiential Education Works</h4>
                            <p>
                                <i>Tell me and I will forget; Show me and I may remember; Involve me and I will understand.</i></p>
                            <p>
                                <i>- Chinese proverb</i></p>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="panel panel-primary" style="border: none;">
                    <div id="Demovideo">
                        <div class="panel-heading" style="background-color: #5A42B4; color: White; font-size: 20px;
                            background-image: none;">
                            ePathshala Demo
                        </div>
                    </div>
                    <div class="panel-body">
                        <div style="overflow-y: scroll; height: 418px;">
                            <iframe allowfullscreen="" src="https://www.youtube.com/embed/l6N4aOkdeiU" class="embed-responsive-item"
                                style="margin-bottom: 20px; width: 100%; border: 1px Solid Black;"></iframe>
                            <iframe allowfullscreen="" src="https://www.youtube.com/embed/Ygx49PO73nk" class="embed-responsive-item"
                                style="margin-bottom: 20px; width: 100%; border: 1px Solid Black;"></iframe>
                            <iframe allowfullscreen="" class="embed-responsive-item" style="margin-bottom: 20px;
                                width: 100%; border: 1px Solid Black;" src="https://www.youtube.com/embed/2D25FTWTZ3g">
                            </iframe>
                            <iframe allowfullscreen="" class="embed-responsive-item" style="margin-bottom: 20px;
                                width: 100%; border: 1px Solid Black;" src="https://www.youtube.com/embed/PVi1y_dNwWw">
                            </iframe>
                            <iframe allowfullscreen="" class="embed-responsive-item" style="margin-bottom: 20px;
                                width: 100%; border: 1px Solid Black;" src="https://www.youtube.com/embed/3HTrdXDDbdE">
                            </iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<cc1:modalpopupextender id="mplogin" runat="server" cancelcontrolid="mpbtnCancel"
        okcontrolid="btnOkay" targetcontrolid="btnmplogin" popupcontrolid="Panel1" drag="true"
        backgroundcssclass="modalBackground">
    </cc1:modalpopupextender>
    <asp:Panel ID="Panel1" Style="display: none" runat="server">
        <uc2:reportcontrol id="uclogin" runat="server" />
        <input id="btnOkay" type="button" value="Done" style="display:none;visibility:hidden;" />
        <input id="mpbtnCancel" type="button" value="Cancel" style="display:none;visibility:hidden;"/>
    </asp:Panel>--%>
    <script type="text/javascript">
        //This function is to simply make current page menu item active.
        $(document).ready(function () {
            $('.puerto-menu li .active').removeClass('active');
            $('.puerto-menu li:nth-child(1) a').addClass('active');
        });
    </script>
</asp:Content>
