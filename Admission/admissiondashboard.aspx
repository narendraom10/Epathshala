<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admissiondashboard.aspx.cs"
    Inherits="Admission_admissiondashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Open+Sans" />
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="form.css" type="text/css" />
    <style type="text/css">
        body
        {
            background-color: #f1f1f1;
            font-family: "Open Sans" , "Arial" !important;
            width: 886px;
            margin: 5% auto;
        }
        .button
        {
            background-color: white;
            box-shadow: 0 0 1px #d5d5d5;
            padding: 10px 0;
            width: 200px;
            display: inline-block;
            margin: 10px;
            font-family: "Open Sans";
            cursor: pointer;
        }
        .clone
        {
            border-left: 6px solid #CC4040;
            margin-top: 20px;
        }
        .cltwo
        {
            border-left: 6px solid #CC7ACC;
        }
        .clthree
        {
            border-left: 6px solid #A3CC52;
        }
        .clfour
        {
            border-bottom: 6px solid #995C00;
        }
        
        .first
        {
            border-bottom: 6px solid #5f9eee;
            background-color: white;
            box-shadow: 0 0 1px #d5d5d5;
            padding: 10px 0;
            width: 250px;
            display: inline-block;
            margin: 20px;
            font-family: "Open Sans";
            cursor: pointer;
        }
        .first h5
        {
            color: Gray;
        }
        .loader-icon-all-reg
        {
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            animation: 400ms linear 0s normal none infinite running nprogress-spinner;
            border-color: #29d transparent transparent #29d;
            border-image: none;
            border-radius: 50%;
            border-style: solid;
            border-width: 2px;
            box-sizing: border-box;
            content: " ";
            height: 25px;
            margin-top: 20px;
            margin-bottom: 20px;
            margin-left: 45%;
            width: 18px;
        }
        .val-all-reg
        {
            font-size: 16px;
            margin-bottom: 20px;
            margin-left: 45%;
            margin-top: 20px;
            width: 18px;
        }
        
        
        .second
        {
            border-bottom: 6px solid #76c187;
            background-color: white;
            box-shadow: 0 0 1px #d5d5d5;
            padding: 10px 0;
            width: 250px;
            display: inline-block;
            margin: 20px;
            font-family: "Open Sans";
            cursor: pointer;
        }
        .second h5
        {
            color: Gray;
        }
        .loader-icon-all-int
        {
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            animation: 400ms linear 0s normal none infinite running nprogress-spinner;
            border-color: #76c187 transparent transparent #76c187;
            border-image: none;
            border-radius: 50%;
            border-style: solid;
            border-width: 2px;
            box-sizing: border-box;
            content: " ";
            height: 25px;
            margin-top: 20px;
            margin-bottom: 20px;
            margin-left: 45%;
            width: 18px;
        }
        .val-all-int
        {
            font-size: 16px;
            margin-bottom: 20px;
            margin-left: 45%;
            margin-top: 20px;
            width: 18px;
        }
        
        
        .third
        {
            border-bottom: 6px solid #9e7da6;
            background-color: white;
            box-shadow: 0 0 1px #d5d5d5;
            padding: 10px 0;
            width: 250px;
            display: inline-block;
            margin: 20px;
            font-family: "Open Sans";
            cursor: pointer;
        }
        .third h5
        {
            color: Gray;
        }
        .loader-icon-all-app
        {
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            animation: 400ms linear 0s normal none infinite running nprogress-spinner;
            border-color: #9e7da6 transparent transparent #9e7da6;
            border-image: none;
            border-radius: 50%;
            border-style: solid;
            border-width: 2px;
            box-sizing: border-box;
            content: " ";
            height: 25px;
            margin-top: 20px;
            margin-bottom: 20px;
            margin-left: 45%;
            width: 18px;
        }
        .val-all-app
        {
            font-size: 16px;
            margin-bottom: 20px;
            margin-left: 45%;
            margin-top: 20px;
            width: 18px;
        }
        
        .fourth
        {
            border-bottom: 6px solid #deb63b;
            background-color: white;
            box-shadow: 0 0 1px #d5d5d5;
            padding: 10px 0;
            width: 250px;
            display: inline-block;
            margin: 20px;
            font-family: "Open Sans";
            cursor: pointer;
        }
        .fourth h5
        {
            color: Gray;
        }
        .loader-icon-all-fiad
        {
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            animation: 400ms linear 0s normal none infinite running nprogress-spinner;
            border-color: #deb63b transparent transparent #deb63b;
            border-image: none;
            border-radius: 50%;
            border-style: solid;
            border-width: 2px;
            box-sizing: border-box;
            content: " ";
            height: 25px;
            margin-top: 20px;
            margin-bottom: 20px;
            margin-left: 45%;
            width: 18px;
        }
        .val-all-fiad
        {
            font-size: 16px;
            margin-bottom: 20px;
            margin-left: 45%;
            margin-top: 20px;
            width: 18px;
        }
        
        .fifth
        {
            border-bottom: 6px solid #A3A300;
            background-color: white;
            box-shadow: 0 0 1px #d5d5d5;
            padding: 10px 0;
            width: 250px;
            display: inline-block;
            margin: 20px;
            font-family: "Open Sans";
            cursor: pointer;
        }
        .fifth h5
        {
            color: Gray;
        }
        .loader-icon-all-noapp
        {
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            animation: 400ms linear 0s normal none infinite running nprogress-spinner;
            border-color: #A3A300 transparent transparent #A3A300;
            border-image: none;
            border-radius: 50%;
            border-style: solid;
            border-width: 2px;
            box-sizing: border-box;
            content: " ";
            height: 25px;
            margin-top: 20px;
            margin-bottom: 20px;
            margin-left: 45%;
            width: 18px;
        }
        .val-all-noapp
        {
            font-size: 16px;
            margin-bottom: 20px;
            margin-left: 45%;
            margin-top: 20px;
            width: 18px;
        }
        
        .six
        {
            border-bottom: 6px solid #CC6699;
            background-color: white;
            box-shadow: 0 0 1px #d5d5d5;
            padding: 10px 0;
            width: 250px;
            display: inline-block;
            margin: 20px;
            font-family: "Open Sans";
            cursor: pointer;
        }
        .six h5
        {
            color: Gray;
        }
        .loader-icon-all-fdnot
        {
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            animation: 400ms linear 0s normal none infinite running nprogress-spinner;
            border-color: #CC6699 transparent transparent #CC6699;
            border-image: none;
            border-radius: 50%;
            border-style: solid;
            border-width: 2px;
            box-sizing: border-box;
            content: " ";
            height: 25px;
            margin-top: 20px;
            margin-bottom: 20px;
            margin-left: 45%;
            width: 18px;
        }
        .val-all-fdnot
        {
            font-size: 16px;
            margin-bottom: 20px;
            margin-left: 45%;
            margin-top: 20px;
            width: 18px;
        }
         @keyframes nprogress-spinner 
        {
            0% {
                transform: rotate(0deg);
            }
            100% {
                transform: rotate(360deg);
            }
        }
    </style>
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

</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; width: 250px; float: left;">
        <div class="button clone" onclick="javascript:redirectpage('InteractionList.aspx');">
            <p style="font-size: 13px; font-weight: bold; text-align: center; color: Gray;">
                SEND INTERACTION</p>
        </div>
        <div class="button cltwo" onclick="javascript:redirectpage('admissionapprovallist.aspx');">
            <p style="font-size: 13px; font-weight: bold; text-align: center; color: Gray;">
                APPROVE ADMISSION</p>
        </div>
        <div class="button clthree" onclick="javascript:redirectpage('AdmissionFeesAndDocument.aspx');">
            <p style="font-size: 13px; font-weight: bold; text-align: center; color: Gray;">
                SUBMIT FEES & DOCUMENT</p>
        </div>
    </div>
    <div style="text-align: center; width: 600px; margin: auto; float: left;">
        <div class="first" onclick="javascript:redirectpage('FinalAdmissionList.aspx?frm=ta');">
            <h5 id="val-all-reg" class="val-all-reg" style="display: none;">
            </h5>
            <h5 class="loader-icon-all-reg" style="display: block;">
            </h5>
            <p style="font-size: 13px; font-weight: bold; text-align: center; color: Gray;">
                TOTAL ADMISSION REGISTRATION</p>
        </div>
        <div class="second" onclick="javascript:redirectpage('FinalAdmissionList.aspx?frm=ti');">
            <h5 id="val-all-int" class="val-all-int" style="display: none;">
            </h5>
            <h5 class="loader-icon-all-int" style="display: block;">
            </h5>
            <p style="font-size: 13px; font-weight: bold; text-align: center; color: Gray;">
                TOTAL INTERACTION SEND</p>
        </div>
        <div class="third" onclick="javascript:redirectpage('FinalAdmissionList.aspx?frm=taa');">
            <h5 id="val-all-app" class="val-all-app" style="display: none;">
            </h5>
            <h5 class="loader-icon-all-app" style="display: block;">
            </h5>
            <p style="font-size: 13px; font-weight: bold; text-align: center; color: Gray;">
                TOTAL ADMISSION APPROVE</p>
        </div>
        <div class="fifth" onclick="javascript:redirectpage('FinalAdmissionList.aspx?frm=tnaa');">
            <h5 id="val-all-noapp" class="val-all-noapp" style="display: none;">
            </h5>
            <h5 class="loader-icon-all-noapp" style="display: block;">
            </h5>
            <p style="font-size: 13px; font-weight: bold; text-align: center; color: Gray;">
                TOTAL ADMISSION NOT APPROVE</p>
        </div>
        <div class="six" onclick="javascript:redirectpage('FinalAdmissionList.aspx?frm=fdnc');">
            <h5 id="val-all-fdnot" class="val-all-fdnot" style="display: none;">
            </h5>
            <h5 class="loader-icon-all-fdnot" style="display: block;">
            </h5>
            <p style="font-size: 13px; font-weight: bold; text-align: center; color: Gray;">
                FEES OR DOCUMENT NOT-COMPLATE</p>
        </div>
        <div class="fourth" onclick="javascript:redirectpage('FinalAdmissionList.aspx?frm=fdc');">
            <h5 id="val-all-fiad" class="val-all-fiad" style="display: none;">
            </h5>
            <h5 class="loader-icon-all-fiad" style="display: block;">
            </h5>
            <p style="font-size: 13px; font-weight: bold; text-align: center; color: Gray;">
                CONFIRMED ADMISSION</p>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            var url; var data; var callbackFunction;
            $('.loader-icon-all-reg').css('display', 'block'); $('.val-all-reg').css('display', 'none');
            url = "admissiondashboard.aspx/AddAdmissionRegistration"; data = "{}"; callbackFunction = "fun_All";
            AjaxPostRequest(url, data, callbackFunction);

            $('.loader-icon-all-int').css('display', 'block'); $('.val-all-int').css('display', 'none');
            url = "admissiondashboard.aspx/TotalInteraction"; data = "{}"; callbackFunction = "fun_Int";
            AjaxPostRequest(url, data, callbackFunction);


            $('.loader-icon-all-app').css('display', 'block'); $('.val-all-app').css('display', 'none');
            url = "admissiondashboard.aspx/TotalApprove"; data = "{}"; callbackFunction = "fun_Apr";
            AjaxPostRequest(url, data, callbackFunction);

            $('.loader-icon-all-noapp').css('display', 'block'); $('.val-all-noapp').css('display', 'none');
            url = "admissiondashboard.aspx/TotalNotApprove"; data = "{}"; callbackFunction = "fun_NoApr";
            AjaxPostRequest(url, data, callbackFunction);

            $('.loader-icon-all-fdnot').css('display', 'block'); $('.val-all-fdnot').css('display', 'none');
            url = "admissiondashboard.aspx/TotalFeesDocumentNotSubmitted"; data = "{}"; callbackFunction = "fun_fdnot";
            AjaxPostRequest(url, data, callbackFunction);

            $('.loader-icon-all-fiad').css('display', 'block'); $('.val-all-fiad').css('display', 'none');
            url = "admissiondashboard.aspx/TotalFinal"; data = "{}"; callbackFunction = "fun_final";
            AjaxPostRequest(url, data, callbackFunction);
        });
        function fun_All(Result) { $('.loader-icon-all-reg').css('display', 'none'); $('.val-all-reg').css('display', 'block'); $('#val-all-reg').html(Result.d); }
        function fun_Int(Result) { $('.loader-icon-all-int').css('display', 'none'); $('.val-all-int').css('display', 'block'); $('#val-all-int').html(Result.d); }
        function fun_Apr(Result) { $('.loader-icon-all-app').css('display', 'none'); $('.val-all-app').css('display', 'block'); $('#val-all-app').html(Result.d); }
        function fun_NoApr(Result) { $('.loader-icon-all-noapp').css('display', 'none'); $('.val-all-noapp').css('display', 'block'); $('#val-all-noapp').html(Result.d); }
        function fun_fdnot(Result) { $('.loader-icon-all-fdnot').css('display', 'none'); $('.val-all-fdnot').css('display', 'block'); $('#val-all-fdnot').html(Result.d); }
        function fun_final(Result) { $('.loader-icon-all-fiad').css('display', 'none'); $('.val-all-fiad').css('display', 'block'); $('#val-all-fiad').html(Result.d); }
        function redirectpage(page) {
            var win = window.open(page, '_self');
        }
        function AjaxPostRequest(requesturl, parameter, functionname) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: requesturl,
                data: parameter,
                dataType: "json",
                success: function (Result) {
                    eval(functionname + "(Result)");
                },
                error: function (Result) {
                }
            });
        }
    </script>
</body>
</html>
