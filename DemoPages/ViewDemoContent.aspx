<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDemoContent.aspx.cs"
    Inherits="DemoPages_ViewDemoContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ePathshala</title>
    <style type="text/css">
        *
        {
            padding: 0px;
            margin: 0px;
            font-family: Arial;
            font-size: 1em;
            line-height: 1.25em;
        }
        html, body
        {
            min-width: 320px;
            min-height: 320px;
        }
        #bgContainer
        {
            position: fixed;
            left: 0px;
            width: 100%;
            height: 100%;
            text-align: center;
            z-index: -25;
            vertical-align: middle;
            padding-top: 11%;
        }
        #bgImage
        {
            opacity: 0.6;
            width: 75%;
            margin: auto;
            -ms-transform: rotate(-20deg); /* IE 9 */
            -webkit-transform: rotate(-20deg); /*Chrome, Safari, Opera */
            transform: rotate(-20deg);
            vertical-align: middle;
            display: inline;
        }
        
        #Header
        {
            min-height: 10%;
            position: relative;
            display: inline-block;
            width: 100%;
            vertical-align: middle;
            border-bottom: 3px double gray;
        }
        
        #Header #Logo
        {
            float: left;
            width: 20%;
            margin: 5px;
        }
        
        #Header #Title
        {
            vertical-align: middle;
            margin-top: 5%;
            margin-left: 5%;
            float: left;
            text-align: center;
            font-size: 1.25em;
            font-weight: bold;
        }
        #Content
        {
            text-align: center;
        }
        
        #Content .Icon
        {
            min-width: 120px;
            max-width: 120px;
            min-height: 85px;
            max-height: 150px;
            border: 3px solid #00a4e0;
            margin: 13px; /*float:left;*/
            display: inline-block;
            background-color: #00a4e0;
            border-radius: 15px;
            box-shadow: 0px 0px 0px 3px white, 0px 0px 0px 6px #01a9eb, 0 2px 3px 7px rgba(0,0,0,0.5);
            color: White;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            font-size: 1.2em;
            cursor: pointer;
        }
        
        #Content .Icon:hover
        {
            /* background-color: #01a9eb;
            box-shadow: 0px 0px 10px blue;
            box-shadow: 0px 0px 0px 3px #33FF00, 0px 0px 0px 6px #01a9eb, 0 2px 6px 9px rgba(0,0,0,0.5);
            */
            background-color: white;
            color: #01a9eb;
            box-shadow: 0px 0px 10px blue;
            box-shadow: 0px 0px 0px 3px #01a9eb, 0px 0px 0px 6px white, 0 2px 3px 7px rgba(0,0,0,0.5);
        }
        
        #Content .Icon[tooltip]
        {
            padding: 101px;
        }
        
        #VideoPlayer
        {
            position: absolute;
            top: 0px;
            left: 0px;
            height: 90%;
            width: 100%;
            background-color: Gray;
            visibility: hidden;
            display: none;
            margin-top: 55px;
        }
        
        
        #NavigationBar
        {
            position: relative;
            background-color: #EFEFEF;
            display: inline-block;
            width: 100%;
            min-height: 25px;
            margin-bottom: 5px;
            vertical-align: middle;
        }
        #NavigationBar #Home
        {
            padding-top: 2px;
            margin-left: 15px;
            cursor: pointer;
        }
        
        
        #NavigationLink
        {
            vertical-align: top;
            display: inline-block;
            padding: 3px;
            font-weight: normal;
            font-size: 0.9em;
        }
        
        #btnBack
        {
            border: 1px solid #00a4e0;
            background-color: #00a4e0;
            padding: 3px;
            border-radius: 5px;
            box-shadow: 0px 0px 0px 2px white, 0px 0px 0px 3px #01a9eb, 0 1px 2px 3px rgba(0,0,0,0.5);
            color: White;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            font-size: 1.2em;
            cursor: pointer;
        }
        
        #btnexit
        {
            border: 1px solid #00a4e0;
            background-color: #00a4e0;
            padding: 3px;
            border-radius: 5px;
            box-shadow: 0px 0px 0px 2px white, 0px 0px 0px 3px #01a9eb, 0 1px 2px 3px rgba(0,0,0,0.5);
            color: White;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            font-size: 1.2em;
            cursor: pointer;
        }
        
        #btnregisternow
        {
            border: 1px solid #00A4E0;
            background-color: #00A4E0;
            padding: 3px;
            border-radius: 5px;
            box-shadow: 0px 0px 0px 2px #FFF, 0px 0px 0px 3px #01A9EB, 0px 1px 2px 3px rgba(0, 0, 0, 0.5);
            color: #FFF;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            font-size: 1.2em;
            cursor: pointer;
            height: 32px;
            margin-top: 8px;
        }
    </style>
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function GetContentList(content, id) {
            debugger
            //var myPath = "E:\AllDevelopment\All_Source_Vss\Epathshala\Epathshala\Epathshala\Epathshala\EduResource\1";
            //alert("in content data");
            $("#Content").html('');
            $.ajax({

                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //url: "ContentData.aspx/GetContent",
                url: "ViewDemoContent.aspx/GetContent",
                data: "{'content':'" + content + "' , 'id' : '" + id + "' }",
                success: function (data) {


                    //alert("in function");
                    debugger

                    if (data.d.length > 0) {

                        for (var i = 0; i < data.d.length; i++) {

                            var pos = data.d[i].Name.toString().indexOf("\\");
                            if (pos >= 0) {
                                //var pos = data.d[i].Name.toString().indexOf(".mp4");
                                //var path = data.d[i].Name.toString().substring(data.d[i].Name.toString().lastIndexOf("\\"));
                                var Name = data.d[i].Name.toString().substring(data.d[i].Name.toString().lastIndexOf("\\") + 1);
                                var ID = i.toString();

                                $("#Content").append('<button id=' + ID + '   class="Icon" >' + Name + '</button>');


                            }
                            else {
                                var pos = data.d[i].Name.toString().indexOf(".mp4");
                                if (pos >= 0) {
                                    var path = data.d[i].ID.toString() + data.d[i].Name.toString();

                                    //var path = "http://192.168.2.28/Epathshala/EduResource/55/03 Video Presentation/small.mp4";
                                    var tag;
                                    //tag = '<video width="100%" height="90%" autoplay controls><source id="MP4File" src="' + data.d[i].Name.toString() + '" type="video/mp4"></video>';
                                    tag = '<video width="100%" height="90%" autoplay controls><source id="MP4File" src="' + path.toString() + '" type="video/mp4"></video>';
                                    $("#VideoPlayer").append(tag);
                                    $("#VideoPlayer").attr("style", "visibility:visible; display:block;");
                                    return;
                                }
                                pos = 0;
                                pos = data.d[i].Name.toString().indexOf(".swf");
                                if (pos >= 0) {
                                    var path = data.d[i].ID.toString() + data.d[i].Name.toString();
                                    tag = '';
                                    tag += '<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="100%" height="90%" id="movie_name" align="middle">'
                                    //tag += '<param name="movie" value="' + data.d[i].Name.toString() + '" />'
                                    tag += '<param name="movie" value="' + path.toString() + '" />'
                                    //tag += '<object type="application/x-shockwave-flash" data="' + data.d[i].Name.toString() + '" width="100%" height="90%">'
                                    tag += '<object type="application/x-shockwave-flash" data="' + path.toString() + '" width="100%" height="90%">'
                                    //tag += '<param name="movie" value="' + data.d[i].Name.toString() + '" />'
                                    tag += '<param name="movie" value="' + path.toString() + '" />'
                                    tag += '<a href="http://www.adobe.com/go/getflash">'
                                    tag += '<img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" />'
                                    tag += '</a>'
                                    tag += '</object></object>'
                                    $("#VideoPlayer").append(tag);
                                    $("#VideoPlayer").attr("style", "visibility:visible; display:block;");
                                    return;
                                }

                                pos = data.d[i].Name.toString().indexOf(".pdf");
                                if (pos >= 0) {
                                    var path = data.d[i].ID.toString() + data.d[i].Name.toString();
                                    tag = '';
                                    // tag = '<a href="' + data.d[i].Name.toString() + '" class="embed" id="embedURL" style="width:100%; height:100%">Download file</a>';
                                    tag = '<a href="' + path.toString() + '" class="embed" id="embedURL" style="width:100%; height:100%">Download file</a>';
                                    $("#VideoPlayer").append(tag);
                                    $("#VideoPlayer").attr("style", "visibility:visible; display:block;");
                                    //$('#embedURL').gdocsViewer({ width: 400%, height: 500% });
                                    $('#embedURL').gdocsViewer();
                                    return;
                                }

                                if (data.d[i].ID.toString() == "false") {
                                    //var Name = data.d[i].Name.toString();
                                    //var ID = data.d[i].ID.toString();

                                    $("#Content").append('<div style="padding-top: 50px;">  You have to register first to view content Click here for registration <a href="Student/StudentRegistration.aspx" target="_blank" style="color:red;">click here</a></div>');
                                    return;
                                    //$("#Content").append('<button id=' + ID + '   class="Icon" title=" + data.d[i] + ">' + Name + '</button>');
                                    // window.location.replace("~/Login.aspx");

                                }

                                var Name = data.d[i].Name.toString();
                                var ID = data.d[i].ID.toString();

                                $("#Content").append('<button id=' + ID + '   class="Icon" >' + Name + '</button>');

                                //$("#Content").append('<button class="Icon" title=" + data.d[i] + ">' + data.d[i].toString() + '</button>');


                            }





                        }
                    }
                    else {
                        $("#Content").append('<button id=0 class="Icon" > No Content </button>');

                    }




                },
                error: function (result) {
                    alert(result.toString());
                }
            });
            return;
        }

        $(document).ready(function () {
            debugger



            var topictype = GetParameterValues('type');
            var BMSSCTID = GetParameterValues('BMSSCTID');



            if (name != undefined) {


                document.getElementById("contenttype1").value = topictype.toString();
                GetContentList(document.getElementById("contenttype1").value, BMSSCTID.toString());

            }


            function GetParameterValues(param) {
                debugger
                var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < url.length; i++) {
                    var urlparam = url[i].split('=');
                    if (urlparam[0] == param) {
                        return urlparam[1];
                    }
                }
            }

            $("#btnBack").click(function () {
                debugger




                $("#VideoPlayer").html('');
                $("#VideoPlayer").attr("style", "visibility:hidden; display:none;");
                //   location.reload();




            });




            $("#Content").on('click', 'button.Icon', function () {
                debugger

                var fileneame = this.innerHTML;




                if (document.getElementById("contenttype1").value == 'topic') {
                    debugger

                    document.getElementById("contenttype1").value = 'viewcontent';
                    document.getElementById("contentvalue").value = this.id;

                    GetContentList("Files", fileneame.toString());
                    return;

                }

                else if (document.getElementById("contenttype1").value == 'Files') {
                    debugger

                    document.getElementById("contenttype1").value = 'viewcontent';
                    document.getElementById("contentvalue").value = this.id;

                    GetContentList("Files", fileneame.toString());
                    return;

                }



                if ($("#NavigationLink").html() == '') {
                    $("#NavigationLink").append(this.innerHTML);
                } else {
                    $("#NavigationLink").append(' | ' + this.innerHTML);
                }


                GetContentList(document.getElementById("contenttype1").value, this.id);
                document.getElementById("contentvalue").value = this.id;

            });








        });
    </script>
    
<script>
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
    <div id="bgContainer">
        <%--<img id="bgImage" src="App_Themes/Responsive/images/Epathshala.png" />--%>
        <img id="Img1" src="../App_Themes/Images/Education8.jpeg " style="margin-top: -110px;"
            alt="Epathshala" />
    </div>
    <!--Navigation Bar-->
    <div id="NavigationBar">
        <img id="Home" src="../App_Themes/Responsive/images/Epathshala.png" alt="Epathshala Logo"
            height="45px" style="float: left;" />
        <div id="Logo" style="float: left; display: inline-block; vertical-align: top; padding: 5px;
            padding-left: 15px; font-weight: bold;">
            Epathshala Demo Content<br />
            <div id="NavigationLink" style="padding: 0px;">
            </div>
        </div>
        <button id="btnBack" style="position: fixed; top: 8px; right: 5px;">
            Back</button>
        <div style="padding-left: 1100px;">
            <asp:Button ID="btnregisternow" runat="server" Text="Register Now" CssClass="btnregisternow" />
        </div>
    </div>
    <!--Content Area-->
    <div id="Content">
    </div>
    <!--Video Player-->
    <div id="VideoPlayer">
    </div>
    <div id="contenttype" class="testtype">
    </div>
    <input type="hidden" id="contenttype1" />
    <input type="hidden" id="contentvalue" />
    <asp:Button ID="Button1" runat="server" Text="Button" Visible="false" />
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
    </form>
</body>
</html>
