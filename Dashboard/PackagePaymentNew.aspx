<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="PackagePaymentNew.aspx.cs" Inherits="PackagePaymentNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .btnEnable
        {
            background-color: red;
        }
        
        .btnDisable
        {
            background-color: blue;
        }
        
        #tblPackageData tr td
        {
            padding: 3px;
            background-color: #C8E4CB;
            color: Black;
        }
    </style>
    <style type="text/css">
        .textboxwidth
        {
            max-width: 320px !important;
            min-width: 320px !important;
        }
        /*!
* bootstrap-vertical-tabs - v1.2.1
*/
        .tabs-left, .tabs-right
        {
            border-bottom: none;
            padding-top: 2px;
        }
        
        .tabs-left
        {
            border-right: 1px solid #ddd;
        }
        
        .tabs-right
        {
            border-left: 1px solid #ddd;
        }
        
        .tabs-left > li, .tabs-right > li
        {
            float: none;
            margin-bottom: 2px;
        }
        
        .tabs-left > li
        {
            margin-right: -1px;
        }
        
        .tabs-right > li
        {
            margin-left: -1px;
        }
        
        .tabs-left > li.active > a, .tabs-left > li.active > a:hover, .tabs-left > li.active > a:focus
        {
            border-bottom-color: #ddd;
            border-right-color: transparent;
        }
        
        .tabs-right > li.active > a, .tabs-right > li.active > a:hover, .tabs-right > li.active > a:focus
        {
            border-bottom: 1px solid #ddd;
            border-left-color: transparent;
        }
        
        .tabs-left > li > a
        {
            border-radius: 4px 0 0 4px;
            margin-right: 0;
            display: block;
        }
        
        .tabs-right > li > a
        {
            border-radius: 0 4px 4px 0;
            margin-right: 0;
        }
        
        .sideways
        {
            margin-top: 50px;
            border: none;
            position: relative;
        }
        
        .sideways > li
        {
            height: 20px;
            width: 120px;
            margin-bottom: 100px;
        }
        
        .sideways > li > a
        {
            border-bottom: 1px solid #ddd;
            border-right-color: transparent;
            text-align: center;
            border-radius: 4px 4px 0px 0px;
        }
        
        .sideways > li.active > a, .sideways > li.active > a:hover, .sideways > li.active > a:focus
        {
            border-bottom-color: transparent;
            border-right-color: #ddd;
            border-left-color: #ddd;
        }
        
        .sideways.tabs-left
        {
            left: -50px;
        }
        
        .sideways.tabs-right
        {
            right: -50px;
        }
        
        .sideways.tabs-right > li
        {
            -webkit-transform: rotate(90deg);
            -moz-transform: rotate(90deg);
            -ms-transform: rotate(90deg);
            -o-transform: rotate(90deg);
            transform: rotate(90deg);
        }
        
        .sideways.tabs-left > li
        {
            -webkit-transform: rotate(-90deg);
            -moz-transform: rotate(-90deg);
            -ms-transform: rotate(-90deg);
            -o-transform: rotate(-90deg);
            transform: rotate(-90deg);
        }
        
        *
        {
            margin: 0;
            padding: 0;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }
        
        body
        {
            background: #f4f4f4;
            font-family: 'open sans' , sans-serif;
        }
        
        #ppn .form-box
        {
            background: #c8e4cb;
            margin: 20px auto;
            box-shadow: 0 3px 6px 0px rgba(0,0,0,0.16), 0 3px 6px 0px rgba(0,0,0,0.23);
            border-radius: 4px;
        }
        #ppnpp .form-box
        {
            background: #c8e4cb;
            margin: 20px auto;
            box-shadow: 0 3px 6px 0px rgba(0,0,0,0.16), 0 3px 6px 0px rgba(0,0,0,0.23);
            border-radius: 4px;
        }
        
        #ppnpp ul
        {
            padding: 0 0 0 15px;
            margin: 0;
        }
        #ppnpp ul li
        {
            padding-right: 25px;
        }
        /* th:nth-of-type(2)
 {
    background: #ff0000;
}*/
        #ppn .head
        {
            background: #263434 none repeat scroll 0 0;
            border-top-left-radius: 4px;
            border-top-right-radius: 4px;
            color: #c8e4cb;
            font-size: 18px;
            font-weight: normal;
            padding: 13px 0;
            text-align: center;
            text-transform: uppercase;
        }
        
        #ppnpp .head
        {
            background: #263434 none repeat scroll 0 0;
            border-top-left-radius: 4px;
            border-top-right-radius: 4px;
            color: #c8e4cb;
            font-size: 18px;
            font-weight: normal;
            padding: 0 0 10px 0;
            text-align: center; /*text-transform: uppercase;*/
            display: inline-block;
            width: 100%;
        }
        
        
        #ppnpp ul li
        {
            float: left;
        }
        #ppn .form-group
        {
            margin-bottom: 20px;
            margin-top: 0px;
            position: relative;
            width: 100%;
            overflow: hidden;
        }
        
        #ppn .form-group .label-control
        {
            color: #263434;
            display: block;
            font-size: 14px;
            position: absolute;
            top: 0;
            left: 0;
            padding: 0;
            width: 100%;
            pointer-events: none;
            height: 100%;
        }
        
        #ppn .form-group .label-control::before, #ppn .form-group .label-control::after
        {
            content: "";
            left: 0;
            position: absolute;
            bottom: 0;
            width: 100%;
        }
        
        #ppn .form-group .label-control::before
        {
            border-bottom: 1px solid #B9C1CA;
            transition: transform 0.3s;
            -webkit-transition: -webkit-transform 0.3s;
        }
        
        #ppn .form-group .label-control::after
        {
            border-bottom: 2px solid #2e8e6e;
            -webkit-transform: translate3d(-100%, 0, 0);
            transform: translate3d(-100%, 0, 0);
            -webkit-transition: -webkit-transform 0.3s;
            transition: transform 0.3s;
        }
        
        
        
        #ppn .form-control:focus
        {
            outline: none;
            box-shadow: none;
        }
        
        #ppn .form-group .label-control .label-text
        {
            -webkit-transform: translate3d(0, 30px, 0) scale(1);
            -moz-transform: translate3d(0, 30px, 0) scale(1);
            transform: translate3d(0, 30px, 0) scale(1);
            -webkit-transform-origin: left top;
            -moz-transform-origin: left top;
            transform-origin: left top;
            -webkit-transition: 0.3s;
            -moz-transition: 0.3s;
            transition: 0.3s;
            position: absolute;
        }
        
        #ppn .active .label-control::after
        {
            -webkit-transform: translate3d(0%, 0, 0);
            transform: translate3d(0%, 0, 0);
        }
        
        #ppn .active .label-control .label-text
        {
            opacity: 1;
            -webkit-transform: scale(0.9);
            -moz-transform: scale(0.9);
            transform: scale(0.9);
            color: #2e8e6e !important;
        }
        
        #ppn .input-field label:before
        {
            content: '';
            position: absolute;
            bottom: 0;
            left: 0;
            width: 100%;
            border-bottom: 1px solid #B9C1CA;
            transition: transform 0.3s;
            -webkit-transition: -webkit-transform 0.3s;
        }
        
        
        #ppn input.btn[type="submit"]
        {
            background: #263434;
            border: none;
            border-radius: 2px;
            color: #c8e4cb;
            cursor: pointer;
            font-size: 16px;
            font-weight: bold;
            letter-spacing: 3px;
            margin: 30px 0 0;
            outline: medium none;
            overflow: hidden;
            padding: 10px;
            text-transform: uppercase;
            transition: all 0.15s ease-in-out 0s;
            width: 100%;
            box-shadow: 0 1px 2px 0px rgba(0,0,0,0.16), 0 1px 2px 0px rgba(0,0,0,0.23);
        }
        #ppnpp input.btn[type="submit"]
        {
            background: #263434;
            border: none;
            border-radius: 2px;
            color: #71af32;
            cursor: pointer;
            font-size: 16px;
            font-weight: bold;
            letter-spacing: 3px;
            margin: 10px 10px 0;
            outline: medium none;
            overflow: hidden;
            padding: 10px;
            text-transform: uppercase;
            transition: all 0.15s ease-in-out 0s; /*width: 50%;*/
            box-shadow: 0 1px 2px 0px rgba(0,0,0,0.16), 0 1px 2px 0px rgba(0,0,0,0.23);
            float: left;
        }
        
        #ppn input.btn[type="submit"]:hover
        {
            background: #71af32;
            box-shadow: 0 2px 4px 0px rgba(0,0,0,0.16), 0 2px 4px 0px rgba(0,0,0,0.23);
        }
        #ppnpp input.btn[type="submit"]:hover
        {
            background: #71af32;
            color: #fff;
            box-shadow: 0 2px 4px 0px rgba(0,0,0,0.16), 0 2px 4px 0px rgba(0,0,0,0.23);
        }
        
        #ppn .text-p
        {
            font-size: 14px;
            text-align: center;
            margin: 10px 0;
        }
        
        #ppn .text-p a
        {
            color: #175690;
        }
        
        
        #ppnpp .text-p
        {
            font-size: 14px;
            text-align: left;
            margin: 0;
            color: #263434;
        }
        #ppnpp .text-hp
        {
            font-size: 14px;
            text-align: left;
            margin: 0px 0;
        }
        
        #ppnpp .text-hp a
        {
            color: #c8e4cb !important;
        }
        #ppnpp .text-hp a:hover
        {
            color: #71af32 !important;
            text-decoration: none;
        }
        
        #ppnpp .text-p a
        {
            color: #263434;
        }
        
        #ppnpp label
        {
            margin-top: 10px;
            margin-right: 10px;
        }
        form input, form textarea
        {
            position: initial !important;
            max-width: 100% !important;
        }
        
        #ppn input[type="submit"]
        {
            height: auto !important;
        }
        #ppnpp input[type="submit"]
        {
            height: auto !important;
        }
        
        form #login-form
        {
            overflow: hidden !important;
            padding: 40px !important;
            position: relative !important;
        }
        
        #ppn .form-control
        {
            background-color: #c8e4cb !important;
            background-image: none !important;
            box-shadow: none !important;
            color: #263434 !important;
            display: block !important;
            height: 40px !important;
            line-height: 1.42857 !important;
            max-width: 100% !important;
            min-width: 100% !important;
            transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s !important;
            vertical-align: middle !important;
            border: none;
            border-radius: 0;
            margin-top: 20px;
            padding: 12px 0;
            width: 100%;
            font-size: 14px;
        }
        
        
        #ppn input[type="text"], .GreenBoard input[type="password"]
        {
            background-color: transparent;
            box-shadow: 0px;
            color: black;
            height: Auto;
        }
        @media screen and (min-width: 360px) and (min-width: 640px) and (-webkit-device-pixel-ratio: 3) and (orientation: portrait)
        {
            #ppntab .head
            {
                font-size: 18px !important;
            }
        
        }
        /* ============================================== */
        /* HDTV                                           */
        /*                                      1920x1080 */
        /* ============================================== */
        @media screen and (min-width: 1080px) and (max-width: 1920px)
        {
            /* ADD YOUR CSS ADJUSTMENTS BELOW HERE */
            #ppntab .head
            {
                font-size: 18px;
            }
        
            #ppn .head
            {
                font-size: 18px;
            }
            th
            {
                font-size: 18px;
            }
        }
        /* ============================================== */
        /* Widescreen                                     */
        /*                                       1280x800 */
        /* ============================================== */
        @media screen and (min-width: 800px) and (max-width: 1280px)
        {
            /* ADD YOUR CSS ADJUSTMENTS BELOW HERE */
            #ppntab .head
            {
                font-size: 18px;
            }
            th
            {
                font-size: 18px;
            }
            #ppn .head
            {
                font-size: 18px;
            }
        }
        /* ============================================== */
        /* iPhone4/Android landscape (& narrow browser)   */
        /*                                        480x320 */
        /* ============================================== */
        @media screen and (min-width: 320px) and (max-width:480px)
        {
            /* ADD YOUR CSS ADJUSTMENTS BELOW HERE */
            #ppntab .head
            {
                font-size: 15px;
                font-weight: bold !important;
            }
        
            #ppn .head
            {
                font-size: 15px;
                font-weight: bold !important;
            }
            th
            {
                font-size: 15px;
                font-weight: bold !important;
            }
        }
        
        @media (max-width: 480px)
        {
            #ppn form#login-form
            {
                width: 90%;
                margin: 30px auto;
            }
        }
        
        
        
        /*  bhoechie tab */
        #ppntab img
        {
            padding: 5px;
        }
        
        #ppntab h4
        {
            /*margin: 12px 5px 5px 0;
            padding-bottom: 7px;*/
            padding-left: 10px; /*padding-top: 7px;*/
        }
        
        #ppntab .head
        {
            background: #263434 none repeat scroll 0 0;
            border-top-left-radius: 4px;
            border-top-right-radius: 4px;
            color: #c8e4cb;
            font-size: 18px;
            font-weight: normal;
            padding: 10px 0;
            text-align: center;
            text-transform: uppercase;
        }
        #ppntab div.bhoechie-tab-container
        {
            z-index: 10;
            background-color: #c8e4cb;
            padding: 0 !important;
            border-top-right-radius: 0px;
            border-top-left-radius: 0px;
            border-bottom-right-radius: 4px;
            border-bottom-left-radius: 4px;
            -moz-border-top-right-radius: 0px;
            -moz-border-top-left-radius: 0px; /*border-radius: 4px;*/ /* -moz-border-radius: 4px;*/ /*border:1px solid #ddd;*/
            margin-top: 0px;
            margin-left: 0px;
            -webkit-box-shadow: 0 6px 12px rgba(0,0,0,.175);
            box-shadow: 0 6px 12px rgba(0,0,0,.175);
            -moz-box-shadow: 0 6px 12px rgba(0,0,0,.175);
            background-clip: padding-box;
            opacity: 0.97;
            filter: alpha(opacity=97);
            width: 100%;
        }
        
        #ppntab div.bhoechie-tab-menu
        {
            padding-right: 0;
            padding-left: 0;
            padding-bottom: 0;
        }
        
        #ppntab div.bhoechie-tab-menu div.list-group
        {
            margin-bottom: 0;
        }
        
        #ppntab div.bhoechie-tab-menu div.list-group > a
        {
            margin-bottom: 0;
            padding: 0px;
        }
        
        #ppntab div.bhoechie-tab-menu div.list-group > a .glyphicon, #ppntab div.bhoechie-tab-menu div.list-group > a .fa
        {
            color: #263434;
        }
        
        #ppntab div.bhoechie-tab-menu div.list-group > a:first-child
        {
            border-top-right-radius: 0;
            -moz-border-top-right-radius: 0;
        }
        
        #ppntab div.bhoechie-tab-menu div.list-group > a:last-child
        {
            border-bottom-right-radius: 0;
            -moz-border-bottom-right-radius: 0;
        }
        
        #ppntab div.bhoechie-tab-menu div.list-group > a.active, #ppntab div.bhoechie-tab-menu div.list-group > a.active .glyphicon, #ppntab div.bhoechie-tab-menu div.list-group > a.active .fa
        {
            background-color: #263434;
            background-image: #263434;
            color: #ffffff;
        }
        
        #ppntab div.bhoechie-tab-menu div.list-group > a.active:after
        {
            content: '';
            position: absolute;
            left: 100%;
            top: 50%;
            margin-top: -13px;
            border-left: 0;
            border-bottom: 13px solid transparent;
            border-top: 13px solid transparent;
            border-left: 10px solid #263434;
        }
        
        #ppntab div.bhoechie-tab-content
        {
            background-color: #c8e4cb; /* border: 1px solid #eeeeee; */
            padding-left: 20px;
            padding-top: 10px;
        }
        
        #ppntab div.bhoechie-tab div.bhoechie-tab-content:not(.active)
        {
            display: none;
        }
        
        #ppntab .text-center
        {
            text-align: center;
        }
        
        #ppntab h1, .h1, h2, .h2, h3, .h3
        {
            margin-bottom: 10px;
            margin-top: 20px;
        }
        /*#ppntab input[type=radio]{ margin:10px;} */
        #ppntab
        {
            display: block;
            margin-top: 20px;
        }
        
        #ppntab .list-group-item.active, .list-group-item.active:hover, .list-group-item.active:focus
        {
            background-image: linear-gradient(to bottom, #263434 0px, #263434 100%);
            background-repeat: repeat-x;
            border-color: #2e8e6e;
            text-shadow: 0 -1px 0 #2e8e6e;
        }
        
        #ppntab .list-group-item
        {
            background: rgba(38, 52, 52, .8);
            border: 1px solid #263434;
            display: block;
            position: relative;
            text-align: left;
        }
        
        #ppntab div a:hover
        {
            color: #c8e4cb;
            font-size: 1em;
            padding: 3px;
        }
        
        
        
        
        
        
        div.table-title
        {
            display: block;
            margin: auto;
            max-width: 600px;
            padding: 5px;
            width: 100%;
        }
        
        .table-title h3
        {
            color: #fafafa;
            font-size: 30px;
            font-weight: 400;
            font-style: normal;
            font-family: "Roboto" , helvetica, arial, sans-serif;
            text-shadow: -1px -1px 1px rgba(0, 0, 0, 0.1);
            text-transform: uppercase;
        }
        
        
        /*** Table Styles **/
        td, th
        {
            padding: 5px 5px 5px 15px !important;
        }
        .table-fill
        {
            background: white;
            border-radius: 3px;
            border-collapse: collapse;
            height: auto;
            margin-top: 20px;
            max-width: 100%;
            padding: 5px;
            width: 100%;
            box-shadow: 0 5px 10px rgba(0, 0, 0, 0.1);
            animation: float 5s infinite;
        }
        
        th
        {
            color: #c8e4cb;
            background: #263434;
            border-bottom: 0px solid #2e8e6e;
            border-right: 1px solid #2e8e6e;
            font-size: 18px;
            font-weight: 100;
            padding: 15px !important;
            text-align: left;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
            vertical-align: middle;
        }
        
        th:first-child
        {
            border-top-left-radius: 3px;
        }
        
        th:last-child
        {
            border-top-right-radius: 3px;
            border-right: none;
        }
        
        tr
        {
            border-top: 1px solid #2e8e6e;
            border-bottom-: 1px solid #2e8e6e;
            color: #263434;
            font-size: 16px;
            font-weight: normal;
            text-shadow: 0 1px 1px rgba(256, 256, 256, 0.1);
        }
        
        tr:hover td
        {
            background: #263434;
            color: #FFFFFF;
            border-top: 1px solid #2e8e6e;
            border-bottom: 1px solid #2e8e6e;
        }
        
        tr:first-child
        {
            border-top: none;
        }
        
        tr:last-child
        {
            border-bottom: none;
        }
        
        tr:nth-child(odd) td
        {
            background: #EBEBEB;
        }
        
        tr:nth-child(odd):hover td
        {
            background: #71af32;
        }
        
        tr:last-child td:first-child
        {
            border-bottom-left-radius: 3px;
        }
        
        tr:last-child td:last-child
        {
            border-bottom-right-radius: 3px;
        }
        
        td
        {
            background: #c8e4cb;
            padding: 20px;
            text-align: left;
            vertical-align: middle;
            font-weight: 300;
            font-size: 15px;
            text-shadow: -1px -1px 1px rgba(0, 0, 0, 0.1);
            border-right: 1px solid #C1C3D1;
        }
        
        td:last-child
        {
            border-right: 0px;
        }
        
        th.text-left
        {
            text-align: left;
        }
        
        th.text-center
        {
            text-align: center;
        }
        
        th.text-right
        {
            text-align: right;
        }
        
        td.text-left
        {
            text-align: left;
        }
        
        td.text-center
        {
            text-align: center;
        }
        
        td.text-right
        {
            text-align: right;
        }
    </style>
    <link href="../ppnstyle.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        $(document).ready(function () {
            $('input[type="checkbox"]').click(function () {
                var btncontinue = $('#<%= btncontinue.ClientID %>');
                if ($(this).prop("checked") == true) {
                    $('#btncontinue').css({ backgroundColor: 'yellow' });
                    btncontinue.removeAttr('disabled');
                }

                else if ($(this).prop("checked") == false) {
                    $('#btncontinue').css({ backgroundColor: 'yellow' });
                    btncontinue.attr('disabled', true);
                }

            });

        });

        function SetTransationType(atag) {
            document.getElementById('<%=hftransactiontype.ClientID %>').value = atag.id;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row DBHeader">
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">Package payment details</span>
            </div>
        </div>
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                <img src="../App_Themes/Green/Images/icon-calendar.png" alt="Calender" />
                &nbsp;&nbsp;<i>Today:
                    <%=DateTime.Now.ToString("dd MMM yyyy / hh:mm tt")%>
                </i>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <div id="ppn">
                <div class="form-box">
                    <div class="head">
                        Package payment details</div>
                    <form action="#" id="login-form">
                    <div style="padding: 20px 40px;">
                        <div class="form-group">
                            <label class="label-control">
                                <span class="label-text">FirstName:</span>
                            </label>
                            <asp:TextBox runat="server" ID="txtfirstname" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqfirstname" runat="server" ErrorMessage="Enter First Name"
                                Display="None" ControlToValidate="txtfirstname" ValidationGroup="Payment" ForeColor="#F5CB21"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="label-control">
                                <span class="label-text">Email Address:</span>
                            </label>
                            <asp:TextBox runat="server" ID="txtemail" Width="50%" class="form-control textboxwidth"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqtxtemail" runat="server" ErrorMessage="Enter Email Address"
                                Display="None" ControlToValidate="txtemail" ValidationGroup="Payment" ForeColor="#F5CB21"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="label-control">
                                <span class="label-text">Address:</span>
                            </label>
                            <asp:TextBox runat="server" ID="txtaddress" Width="50%" class="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqtxtaddress" runat="server" ErrorMessage="Enter Address"
                                Display="None" ControlToValidate="txtaddress" ValidationGroup="Payment" ForeColor="#F5CB21"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="label-control">
                                <span class="label-text">Mobile Number:</span>
                            </label>
                            <asp:TextBox runat="server" ID="txtmobile" Width="100%" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqtxtmobile" runat="server" ErrorMessage="Enter Mobile Numer"
                                Display="None" ControlToValidate="txtmobile" ValidationGroup="Payment" ForeColor="#F5CB21"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="regExpMobile" runat="server" ErrorMessage="Invalid Mobile."
                                Display="None" ControlToValidate="txtmobile" ValidationGroup="Payment" ForeColor="#F5CB21"
                                SetFocusOnError="True" ValidationExpression="(D-)?\d{10}"></asp:RegularExpressionValidator>--%>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtmobile"
                                ValidChars="0123456789+()-">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                        <div class="form-group">
                            <label class="label-control">
                                <span class="label-text">Amount:</span>
                            </label>
                            <asp:TextBox runat="server" ID="txtamt" ReadOnly="True" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    </form>
                </div>
            </div>
            <div class="row" style="padding-top: 5px; display: none;">
                <div class="col-sm-3">
                    <b>Transaction Type: </b>
                </div>
                <div class="col-sm-9">
                    <asp:RadioButtonList ID="rblfieldvalue" runat="server" RepeatDirection="Vertical"
                        CssClass="inline-rb">
                        <asp:ListItem Text="Net Banking" Value="NB" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Credit Card" Value="CC"></asp:ListItem>
                        <asp:ListItem Text="Debit Card" Value="DC"></asp:ListItem>
                        <asp:ListItem Text="IMPS" Value="IMPS"></asp:ListItem>
                        <asp:ListItem Text="Atom Prepaid Wallet" Value="WALLET"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div id="ppntbl">
                <table class="table-fill">
                    <thead>
                        <tr>
                            <th colspan="2" style="text-align: center;">
                                SELECTED PACKAGE
                            </th>
                        </tr>
                    </thead>
                    <tbody class="table-hover">
                        <tr>
                            <td class="text-left">
                                Package Name
                            </td>
                            <td class="text-left">
                                <asp:Label Text="" ID="lblpackagename" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left">
                                Subject
                            </td>
                            <td class="text-left">
                                <asp:Label Text="" ID="lblsubject" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left">
                                Validity(In Month)
                            </td>
                            <td class="text-left">
                                <asp:Label Text="" ID="lblmonth" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left">
                                Expiry Date
                            </td>
                            <td class="text-left">
                                <asp:Label Text="" ID="lblexpirydate" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left">
                                Amount
                            </td>
                            <td class="text-left">
                                <asp:Label Text="" ID="lblamount" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div id="ppntab">
                <div id="paymentmode" runat="server">
                    <div class="head">
                        Select Payment Mode
                    </div>
                    <div class="col-lg-12 col-md-5 col-sm-8 col-xs-9 bhoechie-tab-container">
                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 bhoechie-tab-menu">
                            <div class="list-group">
                                <asp:HiddenField ID="hftransactiontype" runat="server" />
                                <a href="#" class="list-group-item active text-center" onclick="SetTransationType(this);"
                                    id="NB">
                                    <h4>
                                        Net Banking</h4>
                                </a><a href="#" class="list-group-item text-center" onclick="SetTransationType(this);"
                                    id="CC">
                                    <h4>
                                        Credit Card</h4>
                                </a><a href="#" class="list-group-item text-center" onclick="SetTransationType(this);"
                                    id="DC">
                                    <h4>
                                        Debit Card</h4>
                                </a><a href="#" class="list-group-item text-center" onclick="SetTransationType(this);"
                                    id="IMPS">
                                    <h4>
                                        IMPS
                                    </h4>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 bhoechie-tab">
                            <!-- flight section -->
                            <div class="bhoechie-tab-content active">
                                <%--<img src="../Images/keys.jpg" />--%><img src="../Images/netbanking.png" />
                                <%-- <img src="../Images/hdfc.png" style="float: left;" />
                                    <img src="../Images/axis.png" style="float: left;"  />
                                    <img src="../Images/yes.png" style="float: left;" />
                                    <img src="../Images/sbi.png" style="float: left;" />--%>
                                <%--<span style="color:#000; float:right;"> Many More...</span>--%>
                            </div>
                            <!-- train section -->
                            <div class="bhoechie-tab-content">
                                <img src="../Images/cc.png" alt="Credit Card" />
                                <br />
                                <br />
                            </div>
                            <!-- hotel search -->
                            <div class="bhoechie-tab-content">
                                <img src="../Images/dc.png" alt="Debit Card" />
                                <br />
                                <br />
                            </div>
                            <div class="bhoechie-tab-content">
                                <img src="../Images/imps.png" alt="IMPS" />
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div id="ppnpp">
                <div class="form-box">
                    <div class="head">
                        <div style="padding: 15px;" class="text-hp">
                            <ul>
                                <li><a target="_blank" href="../Policy/PrivacyPolicy.htm">Privacy Policy</a> </li>
                                <li><a target="_blank" href="../Policy/TermsAndConditions.htm">Terms &amp; Condition</a>
                                </li>
                                <li><a target="_blank" href="../Policy/CancellationPolicy.htm">Cancellation Policy</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div style="padding: 0 0 15px 15px; display: inline-block;" class="text-p">
                        <div style="float: left;">
                            <label>
                                <input type="checkbox" value="">
                                <span style="margin-left: 2px;">I have read and understand this agreement, and I accept
                                    and agree to all of its terms and conditions. I enter into this agreement voluntarily,
                                    with full knowledge of its effect. </span>
                            </label>
                        </div>
                        <div style="clear: both;">
                            <asp:Button ID="btncontinue" runat="server" Text="Continue" OnClick="btncontinue_Click"
                                class="btn" ValidationGroup="Payment" Enabled="False" />
                            <asp:Button ID="btngoback" runat="server" Text="Go Back" OnClick="btngoback_Click"
                                class="btn" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="padding-top: 5px; padding-left: 10px;">
        <div class="col-sm-12">
            <%--<asp:Button ID="btncontinue" runat="server" Text="Continue" OnClick="btncontinue_Click"
                ValidationGroup="Payment" Enabled="False" />
            <asp:Button ID="btngoback" runat="server" Text="Go Back" OnClick="btngoback_Click" />--%>
        </div>
    </div>
    <div class="row" style="padding-top: 5px; padding-left: 10px;">
        <div class="col-sm-12">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Payment"
                ForeColor="#F5CB21" />
        </div>
    </div>
    <script type="text/javascript">
        $(window).load(function () {
            $('.form-group input').on('focus blur', function (e) {
                $(this).parents('.form-group').toggleClass('active', (e.type === 'focus' || this.value.length > 0));
            }).trigger('blur');
        });
    </script>
    <script type="text/javascript">
        //This function is to simply make current page menu item active.
        $(document).ready(function () {
            $('.puerto-menu li .active').removeClass('active');
            $('.puerto-menu li:nth-child(3) a:first()').addClass('active');
        });
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("div.bhoechie-tab-menu>div.list-group>a").click(function (e) {
                debugger;
                e.preventDefault();
                $(this).siblings('a.active').removeClass("active");
                $(this).addClass("active");
                var index = $(this).index() - 1;
                $("div.bhoechie-tab>div.bhoechie-tab-content").removeClass("active");
                $("div.bhoechie-tab>div.bhoechie-tab-content").eq(index).addClass("active");
            });
        });</script>
</asp:Content>
