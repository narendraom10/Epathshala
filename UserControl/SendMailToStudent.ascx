<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendMailToStudent.ascx.cs"
    Inherits="UserControl_SendMailToStudent" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html>
<head>
    <title></title>
    <script src="../App_Themes/Responsive/js/jquery-2.1.1.js" type="text/javascript"></script>
</head>
<body>
    <div style="width: 100%;">
        <div class="activitydivside1" style="margin-bottom: 5px; padding-bottom: 0px">
            <div class="ActivityHeader">
                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
            </div>
            <div class="ActivityContent" style="margin-top: -10px; margin-bottom: 0px;">
                <div id="mainpanel" class="dvcollapse" runat="server">
                    <asp:UpdatePanel ID="upMain" runat="server">
                        <ContentTemplate>
                            <div class="dvstudentlst">
                                <div style="margin-top: 15px;">
                                    <asp:DropDownList ID="ddlBoard" Width="325px" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged">
                                        <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div style="margin-top: 3px;">
                                    <asp:DropDownList ID="ddlDivision" runat="server">
                                        <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div style="margin-bottom: 20px;">
                                    <asp:Button ID="btngo" Text="Go" runat="server" OnClick="btngo_Click" />
                                </div>
                                <div class="overflw">
                                    <asp:GridView ID="gvstudent" runat="server" SkinID="WithoutPageSizeWithSort" AutoGenerateColumns="False"
                                        OnSorting="gvstudent_Sorting" OnRowDataBound="gvstudent_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <input type="checkbox" id="chkAll" runat="server" onclick="javascript:checkAll(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:checkOne(this);"
                                                        ToolTip='<%# Eval("EmailID") %>' />
                                                    <asp:HiddenField ID="hdnstudentID" runat="server" Value='<%# Eval("StudentID") %>' />
                                                    <asp:HiddenField ID="hdnEmailID" runat="server" Value='<%# Eval("EmailID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Roll No" SortExpression="RollNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="GV_LblSRNO" runat="server" Text='<%# Eval("RollNo") %>' ToolTip='<%# Eval("EmailID") %>' /></ItemTemplate>
                                                <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                                                <ItemTemplate>
                                                    <asp:Label ID="GV_LblStudentName" runat="server" Text='<%#Eval("FirstName") %>' ToolTip='<%# Eval("EmailID") %>' /></ItemTemplate>
                                                <ItemStyle CssClass="GridViewRows" Width="25%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="GV_LblEmail" runat="server" Text='<%#Eval("EmailID") %>'></asp:Label></ItemTemplate>
                                                <ItemStyle CssClass="GridViewRows" Width="25%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="text-align: center; color: black">
                                                No student Found</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnAttachment" runat="server" Value="" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="dvslider" onclick="javascript:return SetCollapse();">
                        <div id="fm-frame-switcher" class="frame-switcher">
                            <div class="frame-switcher-wrap">
                                <span></span>
                            </div>
                        </div>
                    </div>
                    <div class="dvmaildetail">
                        <div class="dvsmallheader">
                            <span>Subject</span>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txtsubject" Style="width: 98.5%; height: 25px; border: 2px solid #e5e5e5;
                                padding: 4px" />
                        </div>
                        <div class="dvsmallheader" style="margin-top: 20px;">
                            <span>Mail Body</span>
                        </div>
                        <div>
                            <HTMLEditor:Editor ID="txtmail" runat="server" Height="460px" Width="100%" AutoFocus="false"
                                ClientIDMode="AutoID" />
                        </div>
                        <div style="margin-top: 10px; width: 100%;">
                            <div style="display: inline-block; float: left; margin-top: 15px;" class="dvsmallheader">
                                <span>Attachment</span>
                            </div>
                            <div style="display: inline-block; text-align: right; float: right; margin-right: -4px;
                                margin-bottom: 0px;">
                                <input type="file" name="fileToUpload" id="fileToUpload" onchange="fileSelected();"
                                    class="dvuploadfile" />
                                <span class="dvuploadbtn" style="cursor: pointer;" onclick="javascript:uploadFile();">
                                    Add Attachment</span>
                            </div>
                        </div>
                        <div id="dvltrAttachment" style="margin-top: 3px; border: 2px solid #e5e5e5; padding: 10px;
                            min-height: 40px; max-height: 40px; overflow-y: auto; width: 97%;">
                            <asp:Literal Text="" ID="ltrAttachment" runat="server" />
                        </div>
                        <div style="margin-left: -4px; padding-top: 13px; padding-bottom: 10px;">
                            <asp:Button ID="btnsendmail" Text="Send Mail" runat="server" OnClick="btnsendmail_Click"
                                OnClientClick="javascript:return CheckAtleastOneTick();" />
                            <asp:Button ID="btnclose" Text="Cancel" runat="server" OnClick="btnclose_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--mail result start-->
    <asp:Button ID="btnresultopen" runat="server" Style="display: none" />
    <asp:Button ID="btnresultclose" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="mdlresult" runat="server" PopupControlID="tblresult"
        CancelControlID="btnresultclose" TargetControlID="btnresultopen" BackgroundCssClass="modalBackground"
        Enabled="True">
    </cc1:ModalPopupExtender>
    <div class="activitydivside1" id="tblresult" runat="server" style="margin-bottom: 5px;
        padding-bottom: 0px; width: 550px; margin: auto;">
        <div class="ActivityHeader">
            <span>Sent mail report</span>
        </div>
        <div class="ActivityContent" style="margin-top: -10px; margin-bottom: 0px;">
            <div class="dvresult" style="max-height: 300px; overflow: auto;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:GridView ID="gvresult" runat="server" SkinID="GridforReport" Style="margin-top: 15px;
                            margin-bottom: 15px;">
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="text-align: center; margin-bottom: 10px;">
                <asp:Button ID="Button1" runat="server" Text="Close" OnClientClick="javascript:return closeresultpopup();" />
            </div>
        </div>
    </div>
    <!--mail result end-->
    <!-- LoaderPart start-->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc1:ModalPopupExtender>
    <table id="dvPopup" runat="server" class="loadingtable" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img src="../App_Themes/Responsive/web/Loader.gif" alt="Loading Please wait.." />
            </td>
        </tr>
        <tr>
            <td class="loadingtabletd">
                <span>Loading Please Wait..</span>
            </td>
        </tr>
    </table>
    <!-- LoaderPart end-->
</body>
</html>
<script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_beginRequest(BeginRequestHandler);
    prm.add_endRequest(EndRequestHandler);
    function BeginRequestHandler(sender, args) {
        ShowLoader();
    }
    function EndRequestHandler(sender, args) {
        HideLoader();
    }
    function checkAll(CheckBox) {
        try {
            if (CheckBox.checked == true) {
                var TargetBaseControl = document.getElementById('<%= gvstudent.ClientID %>');
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var n = 0; n < Inputs.length; ++n) {
                    var headerCheckBox = Inputs[0];
                    if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox && Inputs[n].disabled == false) {
                        Inputs[n].checked = true;
                    }
                }
            }
            else {
                var TargetBaseControl = document.getElementById('<%= gvstudent.ClientID %>');
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var n = 0; n < Inputs.length; ++n) {
                    var headerCheckBox = Inputs[0];
                    if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox && Inputs[n].disabled == false) {
                        Inputs[n].checked = false;
                    }
                }
            }
        }
        catch (e) {
            alert("Error");
        }
    }
    function checkOne(CheckBox) {
        var checked = true;
        var TargetBaseControl = document.getElementById('<%= gvstudent.ClientID %>');
        var Inputs = TargetBaseControl.getElementsByTagName("input");
        for (var n = 0; n < Inputs.length; ++n) {
            var headerCheckBox = Inputs[0];
            if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox && Inputs[n].disabled == false) {
                if (Inputs[n].checked == false) {
                    checked = false;
                    break;
                }
            }
        }
        headerCheckBox.checked = checked;
    }
    function CheckAtleastOneTick() {
        var TargetBaseControl = document.getElementById('<%= gvstudent.ClientID %>');
        var AllTick = false;
        var Inputs = TargetBaseControl.getElementsByTagName("input");
        for (var n = 0; n < Inputs.length; ++n) {
            var headerCheckBox = Inputs[0];
            if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox)
                if (Inputs[n].checked == true) {
                    AllTick = true;
                    break;
                }
        }
        if (AllTick == false) {
            alert("Please select atleast one record for send mail.");
            return false;
        }
        else {
            SetAttachmentInHiddenField();
            if ($("#<%= mainpanel.ClientID%>").hasClass('dvcollapse')) {
                $("#<%= mainpanel.ClientID%>").removeClass('dvcollapse');
                $("#<%= mainpanel.ClientID%>").addClass('dvcollapsed');
            }
            ShowLoader();
            return true;
        }
    }
    function SetCollapse() {
        if ($("#<%= mainpanel.ClientID%>").hasClass('dvcollapse')) {
            $("#<%= mainpanel.ClientID%>").removeClass('dvcollapse');
            $("#<%= mainpanel.ClientID%>").addClass('dvcollapsed');
        }
        else if ($("#<%= mainpanel.ClientID%>").hasClass('dvcollapsed')) {
            $("#<%= mainpanel.ClientID%>").removeClass('dvcollapsed');
            $("#<%= mainpanel.ClientID%>").addClass('dvcollapse');
        }
    }
    function closeresultpopup() {
        if ($("#<%= btnresultclose.ClientID%>") != null) {
            $("#<%= btnresultclose.ClientID%>").click();
        }
        return false;
    }
    function deletedvupload(id) {
        document.getElementById(id).outerHTML = '';
    }
    function SetAttachmentInHiddenField() {
        try {
            var attchment = '';
            var div = document.getElementById("dvltrAttachment");
            var spans = div.getElementsByTagName("span");
            for (i = 0; i < spans.length; i++) {
                if (spans[i].className == "attchfilenamepath") {
                    attchment += spans[i].innerHTML + '|';
                }
            }
            document.getElementById("<%= hdnAttachment.ClientID %>").value = attchment;
        } catch (e) {
        }
    }
    function fileSelected() {
        var file = document.getElementById('fileToUpload').files[0];
        if (file) {
            var fileSize = 0;
            fileSize = (Math.round(file.size * 100 / 1024) / 100).toString() + 'KB';
        }
    }
    function uploadFile() {
        var file = document.getElementById('fileToUpload').files[0];
        if (file) {
            if (checkAlreadyExists(file.name)) {
                alert('File already exists in attachment list.');
                $("#fileToUpload").val('');
            }
            else {
                ShowLoader();
                var fd = new FormData();
                fd.append("fileToUpload", document.getElementById('fileToUpload').files[0]);

                var xhr = new XMLHttpRequest();

                xhr.addEventListener("load", uploadComplete, false);
                xhr.addEventListener("error", uploadFailed, false);
                xhr.addEventListener("abort", uploadCanceled, false);

                xhr.open("POST", "../UserControl/UploadFile.ashx");
                xhr.send(fd);
            }
        }
        else {
            alert('Browse file for add attachment.');
        }
    }
    function uploadComplete(evt) {
        var fileinfo = JSON.parse(evt.target.responseText);
        createfilediv(fileinfo.filename, fileinfo.filepath);
        HideLoader();
    }
    function uploadFailed(evt) {
        alert("There was an error attempting to upload the file.");
    }

    function uploadCanceled(evt) {
        alert("The upload has been canceled by the user or the browser dropped the connection.");
    }
    function createfilediv(filename, filepath) {
        var lastnumber = 0;
        var dvup = $(".dvupload");
        if (dvup.length > 0) {
            lastnumber = dvup[dvup.length - 1].id.replace("dvupload", "");
            lastnumber = +lastnumber + 1;
        }

        var maindiv = document.createElement('div');
        maindiv.id = 'dvupload' + lastnumber;
        maindiv.className = 'dvupload';

        $("#dvltrAttachment").append(maindiv);

        var divA = document.createElement('div');
        divA.className = 'fileName';

        var spanA = document.createElement('span');
        spanA.className = 'attchfilename';
        spanA.innerHTML = filename;

        var spanB = document.createElement('span');
        spanB.className = 'attchfilenamepath';
        spanB.setAttribute("style", "display:none;");
        spanB.innerHTML = filepath;

        divA.appendChild(spanA);
        divA.appendChild(spanB);

        maindiv.appendChild(divA);

        var divB = document.createElement('div');
        divB.className = 'closebtn';

        var ALink = document.createElement('a');
        ALink.setAttribute("onclick", "javascript:deletedvupload('dvupload" + lastnumber + "');");

        var Img = document.createElement('img');
        Img.setAttribute("src", "../App_Themes/Responsive/web/cancel.png");
        Img.setAttribute("style", "cursor:pointer;");

        ALink.appendChild(Img);

        divB.appendChild(ALink);

        maindiv.appendChild(divB);

        $("#fileToUpload").val('');
    }
    function ShowLoader() {
        if ($("#<%= btnLoader.ClientID%>") != null) {
            $("#<%= btnLoader.ClientID%>").click();
        }
    }
    function HideLoader() {
        if ($("#<%= btnCancel.ClientID%>") != null) {
            $("#<%= btnCancel.ClientID%>").click();
        }
    }
    function checkAlreadyExists(name) {
        var div = document.getElementById("dvltrAttachment");
        var spans = div.getElementsByTagName("span");
        for (i = 0; i < spans.length; i++) {
            if (spans[i].className == "attchfilename") {
                if (spans[i].innerHTML == name) {
                    return true;
                }
            }
        }
        return false;
    }
</script>
