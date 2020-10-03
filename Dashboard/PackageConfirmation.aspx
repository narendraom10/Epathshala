<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="PackageConfirmation.aspx.cs" Inherits="Dashboard_PackageConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .GridViewItemFooter
        {
            margin: 5px;
            padding: 3px;
            font-size: 1em;
            color: White;
            text-align: right !important;
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
        
        .GridViewItemDateStyle
        {
            text-align: center !important; /* width: 100px; */
        }
        
        .GridViewItemPadding
        {
            padding-left: 18px !important;
        }
    </style>
    <%--  <style type="text/css">
       
        
        table
        {
            border-collapse: collapse;
        }
        
        table
        {
            width: 60%;
           
        }
        
        th
        {
            height: 50px;
            text-align: left;
        }
      
        td
        {
            height: 50px;
            vertical-align: bottom;
            padding: 15px;
            background-color:Gray;
        }
      
      
        
    
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row DBHeader">
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">Package Confirmation</span>
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
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 15px; overflow: auto;">
            <%--<div style="width: 70%; margin-left: 250px;">--%>
            <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" EmptyDataText="Package not available."
                ShowFooter="true" SkinID="NoPaging" OnRowDataBound="gvSubjects_RowDataBound"
                OnRowCreated="gvSubjects_RowCreated">
                <Columns>
                    <asp:TemplateField HeaderText="Package Name" ItemStyle-CssClass="GridViewItemPadding">
                        <ItemTemplate>
                            <asp:Label ID="lblpackagename" runat="server" Text='<%# Eval("PackageName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject" ItemStyle-CssClass="GridViewItemPadding">
                        <ItemTemplate>
                            <asp:Label ID="lblsubject" Text='<%# Eval("Subject") %>' Style="white-space: normal;"
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Validity(In Month)" ItemStyle-CssClass="GridViewItemRightAlign">
                        <ItemTemplate>
                            <asp:Label ID="lblnoofmonths" Text='<%# Eval("NoOfMonth") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Expiry Date" ItemStyle-CssClass="GridViewItemDateStyle">
                        <ItemTemplate>
                            <asp:Label ID="lblexpirydate" Text='<%# Convert.ToDateTime(Eval("ExpiryDate")).ToString("dd MMM,yyyy") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price (INR)" ItemStyle-CssClass="GridViewItemRightAlign">
                        <ItemTemplate>
                            <asp:Label ID="lblprice" Text='<%# Eval("Price") %>' runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalpackageprice" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle Font-Bold="True" HorizontalAlign="Right" CssClass="GridViewItemFooter" />
            </asp:GridView>
            <div>
                <asp:Label ID="lblprice" runat="server" Visible="False" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
            <%--</div>--%>
        </div>
    </div>
    <div>
    </div>
    <%--<div align="right" style="margin-right: 250px; margin-top: 20px;">--%>
    <%--</div>--%>
    <div align="center">
        <asp:Button ID="btnconfirm" runat="server" Text="Confirm" OnClick="btnconfirm_Click" />
        <asp:Button ID="btngoback" runat="server" Text="Go Back" OnClick="btngoback_Click" />
    </div>
    <script type="text/javascript">
        //This function is to simply make current page menu item active.
        $(document).ready(function () {
            $('.puerto-menu li .active').removeClass('active');
            $('.puerto-menu li:nth-child(3) a:first()').addClass('active');
        });
    </script>
</asp:Content>
