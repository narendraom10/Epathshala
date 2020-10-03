<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectPackage.aspx.cs" Inherits="Dashboard_SelectPackage"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" MasterPageFile="~/MasterPage/Epathshala.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,500,700' rel='stylesheet'
        type='text/css'>
    <script type="text/javascript">
        $(document).ready(function () {


            $(".combo-btn").click(function () {
                $("#ComboCollapsible").collapse('show');
                $("#SingleCollapsible").collapse('hide');
                $("#ComboCollapsible").collapse('toggle');
            });
            $(".single-btn").click(function () {
                $("#ComboCollapsible").collapse('hide');
                $("#SingleCollapsible").collapse('show');
                $("#SingleCollapsible").collapse('toggle');
            });

        });
    </script>
    <script language="javascript" type="text/javascript">
        function SelectSingleRadiobutton(rdbtnid) {
            var rdBtn = document.getElementById(rdbtnid);
            var rdBtnList = document.getElementsByTagName("input");
            for (i = 0; i < rdBtnList.length; i++) {
                if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) {
                    rdBtnList[i].checked = false;
                }
            }
        }
    </script>
    <script type="text/javascript">
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
    
    </script>
    <style type="text/css">
        .GridViewItemCheckbox
        {
            margin: 5px;
            padding: 3px;
            font-size: 1em;
            color: White;
            text-align: center !important;
            white-space: nowrap;
            min-width: 51px;
            border: 1px solid #2E8E6E;
            background-color: rgb(158, 177, 170);
            color: Black;
        }
        .GridViewItemRightAlign
        {
            text-align: right !important;
            width: 100px;
            padding-right: 32px !important;
        }
        
        .GridViewItemRightAlignButton a
        {
            text-align: center !important;
            color: Blue !important;
            text-decoration: underline;
        }
        
        .GridViewItemCenterAlignButtonImage
        {
            text-align: center !important;
            color: Blue !important;
            /*text-decoration: underline; */
        }
          .GridViewItemDateStyle
        {
            text-align: center !important;
            width: 100px;
        }
        
        .GridViewItemPadding
        {
            padding-left: 18px !important;
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
    <div class="row">
        <div class="col-sm-12">
            <div style="margin: 20px; font-size: 17px;">
                <asp:Label ID="lblYourInfo" runat="server" Text="You are in:" meta:resourcekey="lblYourInfoResource1"></asp:Label>
                <asp:Label ID="lblStandard" runat="server" meta:resourcekey="lblStandardResource1"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblMsg" runat="server" Text="" Visible="False" meta:resourcekey="lblMsgResource1"></asp:Label>
                <br />
                <br />
                ePathshala provides various package option to subscribe. Kindly choose convenient
                package to access our excellent educational resources.
            </div>
            <div class="bs-example" style="margin: 20px; display: none; visibility: hidden;">
                <!-- Trigger Button HTML -->
                <input type="button" class="btn btn-primary combo-btn" value="What is combo packge ?" />
                <input type="button" class="btn btn-primary single-btn" value="What is single packge ?" />
                <br />
                <!-- Collapsible Element HTML -->
                <div id="ComboCollapsible" class="collapse" style="color: Black; font-weight: bold;
                    margin-top: 10px; color: White;">
                    <p>
                        In Combo package user do not have restriction to access limited subject. User can
                        use all relevant subject of his/her standard offerd by epath</p>
                </div>
                <div id="SingleCollapsible" class="collapse" style="color: Black; font-weight: bold;
                    margin-top: 10px; color: White;">
                    <p>
                        In Single Package user have a rights to choose subjest.</p>
                </div>
            </div>
            <div class="row">
                <div class="Content">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display: none; visibility: hidden">
                        <div style="margin: 20px;">
                            <asp:Button ID="btnCombo" runat="server" Text="Combo Package" OnClick="btnCombo_Click"
                                meta:resourcekey="btnComboResource1" Visible="False" />
                            <asp:Button ID="btnSingle" runat="server" Text="Single Package" OnClick="btnSingle_Click"
                                meta:resourcekey="btnSingleResource1" />
                            <asp:Button ID="btnLoginBack" Text="Back to login" Visible="False" runat="server"
                                OnClick="btnLoginBack_Click" meta:resourcekey="btnLoginBackResource1" />
                            <asp:Button ID="btnHomeBack" Visible="False" runat="server" OnClick="btnHomeBack_Click"
                                Text="Back to home" meta:resourcekey="btnHomeBackResource1" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 27px; overflow: auto;">
                    <%--<asp:Panel ID="pnlCombo" runat="server" Visible="False" meta:resourcekey="pnlComboResource1">--%>
                    <asp:Panel ID="pnlCombo" runat="server" meta:resourcekey="pnlComboResource1">
                        <asp:Label ID="lblComboLegend" runat="server" CssClass="SubTitle" Text="Combo Package"
                            meta:resourceKey="lblComboLegendResource1" Visible="False"></asp:Label>
                        <asp:GridView ID="dlCombo" runat="server" AutoGenerateColumns="False" DataKeyNames="PackageID"
                            EmptyDataText="Combo package not available" meta:resourceKey="dlComboResource1"
                            OnSelectedIndexChanged="OnSelectedIndexChanged" OnRowDataBound="dlCombo_RowDataBound">
                            <Columns>
                                <%--<asp:TemplateField meta:resourceKey="TemplateFieldResource1" ItemStyle-CssClass="GridViewItemCheckbox">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkComboPackage" runat="server" onclick="Check_Click(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Package Name" ItemStyle-CssClass="GridViewItemPadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpackagename" runat="server" Text='<%# Eval("PackageName") %>' meta:resourceKey="lblPackageTypeResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" ItemStyle-CssClass="GridViewItemPadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject").ToString().Replace(",", ", " ) %>' style="white-space:normal;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Validity(In Month)" ItemStyle-HorizontalAlign="Right"
                                    ItemStyle-CssClass="GridViewItemRightAlign">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnoofmonths" runat="server" Text='<%# Eval("NoOfMonth") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vacation Offer" ItemStyle-HorizontalAlign="Right"
                                    ItemStyle-Width="100px" ItemStyle-CssClass="highlight">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloffername" runat="server" Text='<%# Eval("OfferName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expire On" ItemStyle-CssClass="GridViewItemDateStyle"
                                    Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblexpireon" runat="server" Text='<%# Eval("ValidTill","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price (INR)" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="GridViewItemRightAlign">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComboPrice" runat="server" Text='<%# Eval("Price") %>' meta:resourceKey="lblComboPriceResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PackageID" Visible="False" ItemStyle-ForeColor="Black"
                                    ControlStyle-ForeColor="Black">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("PackageID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="Buy Package" CommandName="Select" HeaderText="Action" ItemStyle-ForeColor="Black"
                                    ItemStyle-Width="100px" ItemStyle-CssClass="GridViewItemCenterAlignButtonImage"
                                    ButtonType="Image" ImageUrl="../App_Themes/Responsive/images/Cart.png" />
                            </Columns>
                            <EmptyDataRowStyle CssClass="empty" />
                            <EmptyDataTemplate>
                                No package(s) available.</EmptyDataTemplate>
                        </asp:GridView>
                        <asp:Button ID="btnComboSubmit" Text="Buy Package" runat="server" OnClick="btnComboSubmit_Click"
                            Visible="false" />
                    </asp:Panel>
                    <asp:Panel ID="pnlSingle" runat="server" Visible="False" meta:resourcekey="pnlSingleResource1">
                        <asp:Label ID="lblLegendSubject" runat="server" CssClass="SubTitle" Text="Single Package"
                            meta:resourceKey="lblLegendSubjectResource1"></asp:Label>
                        <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" EmptyDataText="Single Package not available."
                            meta:resourceKey="gvSubjectsResource1" DataKeyNames="PackageID">
                            <Columns>
                                <asp:TemplateField meta:resourceKey="TemplateFieldResource1" ItemStyle-CssClass="GridViewItemCheckbox">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAllSingel" runat="server" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chksinglepackage" runat="server" onclick="Check_Click(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Package Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpackagename" runat="server" Text='<%# Eval("PackageName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" Text='<%# Eval("Subject") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No Of Days">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnoofmonths" Text='<%# Eval("NoOfMonth") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprice" Text='<%# Eval("Price") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click"
                            meta:resourceKey="btnSubmitResource1" />
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
