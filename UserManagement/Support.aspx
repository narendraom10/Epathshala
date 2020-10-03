<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true" CodeFile="Support.aspx.cs" Inherits="UserManagement_Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="row" style="width:100%; height:500px;background-color:white;margin-top:10px; ">

            <div class="col-md-9 mb-md-0 mb-5">


                <div class="row">

                     <div class="col-md-6">
                        <div class="md-form mb-0">
                            <asp:Label ID="lblname" runat="server" Text="UserName"></asp:Label>
                            <asp:TextBox ID ="txtUserName" runat="server"  CssClass="form-control"></asp:TextBox>
                            
                        </div>
                     </div>
                     <div class="col-md-6">
                        <div class="md-form mb-0">
                            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                            <asp:TextBox ID ="TxtEmail" runat="server"  CssClass="form-control"></asp:TextBox>
                            
                        </div>
                     </div>

                </div>
                <div class="row"> 
                    <div class="col-md-12">
                        <div class="md-form mb-0">
                            <asp:Label ID="Lblsubject" runat="server" Text="How can we help"></asp:Label>
                            <asp:DropDownList ID="DDLsubject" runat="server"  CssClass="form-control" style="min-width:100%;"  >
                                <asp:ListItem Value="">--Select--</asp:ListItem>  
                                <asp:ListItem>Issues while taking a Course</asp:ListItem>  
                                <asp:ListItem>Account/Profile Questions</asp:ListItem>  
                                <asp:ListItem>Purchases/Refund</asp:ListItem> 


                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqfld2" runat="server"   ControlToValidate="DDLsubject" ValidationGroup="vsupport" ErrorMessage="Select an option"></asp:RequiredFieldValidator>
                            
                        </div>
                     </div>

                </div>
                 <div class="row">
                    <div class="col-md-12">
                        <div class="md-form mb-0" style="border:1px solid silver;min-width:100%;">
                            <asp:Label ID="LblDesc" runat="server" Text="Description"></asp:Label>
                             <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" rows="2"  CssClass="form-control" style="min-width:100%; "></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rqfld1" runat="server"   ControlToValidate="txtDesc" ValidationGroup="vsupport" ErrorMessage="Description cannot be blank"></asp:RequiredFieldValidator>
                        </div>
                      
                     </div>
                  </div>
                 <br /><br />
                 <div class="row">
                    
                     <div class="col-md-12">
                         <asp:Button ID="btnsubmit"  CssClass="btn-blue" runat="server" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="vsupport" />
                          
                     </div>

                </div>
                <div class="row">

                      <div class="md-form mb-0" style="border:1px solid silver;min-width:100%;">
                             <asp:ValidationSummary ID ="valid1" runat="server" CssClass="form-control" DisplayMode="List" ShowMessageBox="true" ShowSummary="true" />
                        </div>
                </div>
            </div>


    </div>

     
        
       
</asp:Content>

