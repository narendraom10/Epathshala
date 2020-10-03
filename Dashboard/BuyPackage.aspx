<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="BuyPackage.aspx.cs" Inherits="Dashboard_BuyPackage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }

        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }

        function callFunction() {
            debugger;
            alert("function called");
            var panelcotrl = document.getElementById("<%=fieldpanel.ClientID%>");
            alert(panelcotrl);


        }
        

           


        
    </script>
    <style type="text/css">
        
        .gridlablealign
        {
            text-align: right;
            padding-right: 10px;
        }
        .labeltext
        {
            height: auto;
            margin-right: 30px;
            padding-top: 4px;
            white-space: nowrap;
            font-size: 16px !important; /* text-decoration: blink; */
        }
        
        .labeltext1
        {
            height: auto;
            margin-right: 72px;
            padding-top: 4px;
            white-space: nowrap;
        }
        .activitydiv
        {
            background-color: #FFF;
            width: 95% !important;
            min-width: 475px;
            padding-bottom: 10px;
            font-size: 14px;
            color: #3E3E3E;
            margin: 5px 0px 0px;
            border-left: 1px solid #959595;
            border-bottom: 1px solid #959595;
            border-right: 1px solid #959595;
            border-radius: 2px;
        }
        
        .GridViewItemFooter
        {
            text-align: center !important;
        }
        
        .GreenBoard div a:hover
        {
            color: White !important;
        }
        
        
        .dropdown-menu > .active > a, .dropdown-menu > .active > a:hover, .dropdown-menu > .active > a:focus
        {
            background-image: linear-gradient(to bottom, #DBEDDC 0px, #DBEDDC 100%) !important;
        }
        
        .dropdown-menu > li > a:hover, .dropdown-menu > li > a:focus
        {
            background-image: none !important;
            background-repeat: repeat-x;
            background-color: #E8E8E8;
        }
        
        .imgcalender
        {
            vertical-align: middle;
        }
        
        .GridViewItemRightAlign
        {
            text-align: right !important;
            width: 100px;
            padding-right: 32px !important;
        }
        
        .GridViewItemDateStyle
        {
            text-align: center !important;
            width: 100px;
        }
        
        .GridViewItemRightAlignButton a
        {
            text-align: center !important;
            color: Blue !important;
            /*text-decoration: underline; */
        }
        
         .GridViewItemRightAlignButtonImage
        {
            text-align: center !important;
            color: Blue !important;
            /*text-decoration: underline; */
        }
        
         .empty 
{
   background-color: #aad2ae;
    border: 1px solid #2e8e6e;
    color: black;
    font-size: 1.3em;
    font-weight: bold;
    padding: 3px;
    text-align: center;
    white-space: nowrap
}
        
        .GridViewItemPadding
        {
            padding-left: 18px !important;
        }
        
        .highlight 
        {
           -webkit-background-color:  #ffd54d ;
    -webkit-animation-name: example; /* Chrome, Safari, Opera */
    -webkit-animation-duration:2s; /* Chrome, Safari, Opera */
    animation-name: example;
    animation-duration: 2s;
animation-iteration-count: infinite;
-webkit-animation-iteration-count: infinite;
}


/* Chrome, Safari, Opera */
@-webkit-keyframes example {
    20%{background-color:  #ffd54d;}
    40% {background-color:  #ffcf33;}
    60%{background-color:  #ffcf33;}
    80% {background-color:  #ffc91a;}
    100%{background-color:  #ffc300;}
    /*background-color:  #FFC300 */
}

/* Standard syntax */
@keyframes example 
{
    20%{background-color:  #ffd54d;}
    40% {background-color:  #ffcf33;}
    60%{background-color:  #ffcf33;}
    80% {background-color:  #ffc91a;}
    100%{background-color:  #ffc300;}
    }
        
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row DBHeader">
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">Package Details </span>
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
    <div class="row" style="margin: 0px; padding: 0px; overflow: auto;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 15px; overflow: auto;">
            <div>
                <%-- <ul class="nav nav-tabs GridTab">
                    <li class="active"><a data-toggle="tab" href="#AllPackages_Package">Available Packages</a></li>
                    <li><a data-toggle="tab" href="#Current_Package">Current Packages</a></li>
                    <li class="dropdown" style="display: none; visibility: hidden;"><a class="dropdown-toggle"
                        data-toggle="dropdown" href="#">Other Available Packages<span class="caret"></span></a>
                        <ul class="dropdown-menu" style="background-color: #AAD2AE">
                            <li><a href="#Combo_Package" data-toggle="tab">Combo Package</a></li>
                            <li><a href="#Single_Package" data-toggle="tab">Single Package</a></li>
                        </ul>
                    </li>
                </ul>--%>
                <div class="tab-content">
                    <div id="AllPackages_Package">
                        <h3>
                            <asp:Label ID="lblusername" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                        </h3>
                        <br />
                        <h4>
                            <b><u>All Available Package(s) </u></b>
                        </h4>
                        <asp:GridView ID="gvallpackage" runat="server" AutoGenerateColumns="False" DataKeyNames="PackageID"
                            OnSelectedIndexChanged="OnSelectedIndexChanged" EmptyDataText="Packages not available"
                            OnRowDataBound="gvallpackage_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Package Name" ItemStyle-CssClass="GridViewItemPadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpackagename" runat="server" Text='<%# Eval("PackageName") %>' meta:resourceKey="lblPackageTypeResource1" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" ItemStyle-CssClass="GridViewItemPadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>' Style="white-space: normal;" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Validity(In Month)" ItemStyle-HorizontalAlign="Right"
                                    ItemStyle-Width="100px" ItemStyle-CssClass="GridViewItemRightAlign">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnoofmonths" runat="server" Text='<%# Eval("NoOfMonth") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vacation Offer" ItemStyle-HorizontalAlign="Right"
                                    ItemStyle-Width="100px" ItemStyle-CssClass="highlight">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloffername" runat="server" Text='<%# Eval("OfferName") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expire On" ItemStyle-CssClass="GridViewItemDateStyle"
                                    Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblexpireon" runat="server" Text='<%# Eval("ValidTill","{0:dd-MMM-yyyy}") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="GridViewItemRightAlign">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComboPrice" runat="server" Text='<%# Eval("Price") %>' meta:resourceKey="lblComboPriceResource1" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PackageID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("PackageID") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:ButtonField Text="Buy Package" CommandName="Select" HeaderText="Buy" ItemStyle-ForeColor="Black" />--%>
                                <asp:TemplateField HeaderText="Currency" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcurrency" runat="server" Text='<%# Eval("Currency") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="Buy Package" CommandName="Select" HeaderText="Action" ItemStyle-ForeColor="Black"
                                    ItemStyle-Width="100px" ItemStyle-CssClass="GridViewItemRightAlignButtonImage"
                                    ButtonType="Image" ImageUrl="../App_Themes/Responsive/images/Cart.png" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="empty" />
                            <EmptyDataTemplate>
                                No package(s) available.</EmptyDataTemplate>
                        </asp:GridView>
                        <asp:GridView ID="gvOffer" runat="server" AutoGenerateColumns="False" DataKeyNames="PackageID"
                            OnSelectedIndexChanged="OnSelectedIndexChanged" EmptyDataText="Packages not available"
                            OnRowDataBound="gvallpackage_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Package Name" ItemStyle-CssClass="GridViewItemPadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpackagename" runat="server" Text='<%# Eval("PackageName") %>' meta:resourceKey="lblPackageTypeResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" ItemStyle-CssClass="GridViewItemPadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Validity(In Month)" ItemStyle-HorizontalAlign="Right"
                                    ItemStyle-Width="100px" ItemStyle-CssClass="GridViewItemRightAlign">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnoofmonths" runat="server" Text='<%# Eval("NoOfMonth") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Offer" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="GridViewItemPadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloffername" runat="server" Text='<%# Eval("OfferName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Offer Days" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="GridViewItemRightAlign">
                                    <ItemTemplate>
                                        <asp:Label ID="lblofferdays" runat="server" Text='<%# Eval("OfferDays") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Expire On" ItemStyle-CssClass="GridViewItemDateStyle">
                                    <ItemTemplate>
                                        <asp:Label ID="lblexpireon" runat="server" Text='<%# Eval("ValidTill","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price (INR)" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="GridViewItemRightAlign">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComboPrice" runat="server" Text='<%# Eval("Price") %>' meta:resourceKey="lblComboPriceResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PackageID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("PackageID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="Buy Package" CommandName="Select" HeaderText="Renew" ItemStyle-ForeColor="Black"
                                    ItemStyle-Width="100px" ItemStyle-CssClass="GridViewItemRightAlignButton" ButtonType="Link" />
                            </Columns>
                            <EmptyDataTemplate>
                                <span>No Combo package Available</span>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:Button ID="btnpurchasedpackage" Text="Submit" runat="server" OnClick="btnpurchasedpackage_Click"
                            Visible="false" />
                    </div>
                    <div id="Current_Package">
                        <br />
                        <h4>
                            <b><u>Current Package(s) </u></b>
                        </h4>
                        <div>
                            <asp:GridView ID="gvpurchasedpackages" runat="server" Visible="true" AutoGenerateColumns="False"
                                meta:resourcekey="gvSubjectExpiryNotificationResource1" DataKeyNames="PackageFD_ID"
                                SkinID="NoPaging" OnRowDataBound="gvpurchasedpackages_RowDataBound" OnSelectedIndexChanged="gvpurchasedpackages_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Package Name" ItemStyle-CssClass="GridViewItemPadding">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpackagename" runat="server" Text='<%# Eval("PackageName") %>' meta:resourceKey="lblPackageTypeResource1" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject" ItemStyle-CssClass="GridViewItemPadding">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>' Style="white-space: normal;" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Validity(In Month)" Visible="true" ItemStyle-HorizontalAlign="Right"
                                        ItemStyle-Width="100px" ItemStyle-CssClass="GridViewItemRightAlign">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnoofmonths" runat="server" Text='<%# Eval("NoOfMonth") %>' Visible="true" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Activate On" ItemStyle-CssClass="GridViewItemDateStyle">
                                        <ItemTemplate>
                                            <asp:Label ID="lblregisteredon" runat="server" Text='<%# Eval("FromDate","{0:dd-MMM-yyyy}") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Expire On" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="GridViewItemDateStyle"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblexpireon" runat="server" Text='<%# Eval("ValidTill","{0:dd-MMM-yyyy}") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblComboPrice" runat="server" Text='<%# Eval("Price") %>' Visible="false" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PackageID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("PackageFD_ID") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField Text="Renew Package" CommandName="Select" HeaderText="Action" ItemStyle-ForeColor="Black"
                                        ItemStyle-Width="100px" ItemStyle-CssClass="GridViewItemRightAlignButtonImage"
                                        ButtonType="Image" ImageUrl="../App_Themes/Responsive/images/Renew1.png" />
                                </Columns>
                                <EmptyDataRowStyle CssClass="empty" />
                                <EmptyDataTemplate>
                                    Currently you do not have any package(s) subscribed.</EmptyDataTemplate>
                            </asp:GridView>
                            <asp:Button ID="btnbuy" runat="server" Text="Renew Package" OnClick="btnbuy_Click"
                                Visible="false" />
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="lblnotavailablepackage" runat="server" CssClass="labeltext" ForeColor="Red"
                                Visible="False"></asp:Label>
                            <asp:Panel runat="server" ID="fieldpanel" Visible="false">
                                <%--<asp:Label ID="lblactivation" runat="server" CssClass="SubTitle" Text="Package Activation Details"
                                            meta:resourceKey="lblComboLegendResource1" Font-Bold="True"></asp:Label>--%>
                                <asp:Panel ID="pnlpackageactivation" runat="server">
                                    <br />
                                    <div>
                                        <br />
                                        <asp:Label ID="lblofferdetails" runat="server" Font-Size="Larger"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblconfirmation" runat="server" Text="Do you want to activate now?"
                                            CssClass="labeltext"> </asp:Label>
                                        <asp:RadioButton ID="rbyes" runat="server" Text="Yes" GroupName="confirmpackage"
                                            AutoPostBack="True" Checked="True" OnCheckedChanged="rbyes_CheckedChanged" />
                                        <asp:RadioButton ID="rbno" runat="server" Text="No" GroupName="confirmpackage" AutoPostBack="True"
                                            OnCheckedChanged="rbno_CheckedChanged" />
                                    </div>
                                    <br />
                                    <asp:Label ID="lbldate" runat="server" Text="Enter Activation Date:" CssClass="labeltext1"></asp:Label>
                                    <asp:TextBox ID="txtdate" runat="server" Width="250px" Height="25px" Enabled="False"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate"
                                        ErrorMessage="Please enter Date" ValidationGroup="packageDetails">*</asp:RequiredFieldValidator>
                                    <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.png"
                                        BackColor="#444" Width="25px" meta:resourcekey="ibtnDateResource1" Enabled="False"
                                        CssClass="imgcalender" />
                                    <cc1:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate"
                                        Enabled="True" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                    <br />
                                    <asp:Button ID="btnactivate" runat="server" Text="Submit" OnClick="btnactivate_Click" />
                                    <asp:Button ID="btnreset" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                </asp:Panel>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        //This function is to simply make current page menu item active.
        $(document).ready(function () {
            $('.puerto-menu li .active').removeClass('active');
            $('.puerto-menu li:nth-child(3) a:first').addClass('active');
        });
    </script>
</asp:Content>
