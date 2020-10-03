<%@ Page Title="" Language="C#" MasterPageFile="~/Epathshala.master" AutoEventWireup="true"
    CodeFile="TestJQuery.aspx.cs" Inherits="Admin_TestJQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 
    <script src="../App_Themes/Responsive/js/jquery-ui.js" type="text/javascript"></script>
    <script src="../App_Themes/Responsive/js/jquery-2.1.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
      
        $("#<%= tLoginId.ClientID%>").val('');
      

    });


    $("#<%= tLoginId.ClientID%>").blur(function () {
        debugger
        alert("in blur event");
        var Username = $("#<%= tLoginId.ClientID%>").val();
        if (Username.length > 0) {
            $("#<%= lblAvailibility.ClientID%>").text("Check Availibility...");
            $.ajax({
            
           
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "../Admin/TestJQuery.aspx/CheckUserID",
                data: "{'UserID':'" + Username + "'}",
                success: function (data)
                 {
                debugger
                alert("in blur event");
                    try
                     {
                        if (data.d.toString() == 'True') {
                            $("#<%= lblAvailibility.ClientID%>").text('Already Exists');
                            $("#<%= tLoginId.ClientID%>").val('');
                            $("#<%= lblAvailibility.ClientID%>").css("color", "red");
                        }
                        else if (data.d.toString() == 'False') {
                            $("#<%= lblAvailibility.ClientID%>").text('Login Id Available');
                            $("#<%= lblAvailibility.ClientID%>").css("color", "green");
                        }
                        else {
                            $("#<%= lblAvailibility.ClientID%>").text('Error.');
                            $("#<%= lblAvailibility.ClientID%>").css("color", "red");
                        }

                    }
                     catch (e)
                      {
                        return;
                    },
        
                error: function (result) {
                    alert("Error");
                }
            });
        }
    });
  

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
      <tr>
                <td style="text-align: right; height: 30px; padding-right: 5px;">
                    <asp:Label ID="lblLoginId" runat="server" Text="Login ID:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tLoginId" runat="server" MaxLength="30" CssClass="controllabel"
                        AutoCompleteType="None"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tLoginId"
                        ErrorMessage="Login ID Must Be Required " ValidationGroup="PD">*</asp:RequiredFieldValidator>
                    <asp:Label ID="lblAvailibility" runat="server" Text=""></asp:Label>
                </td>
            </tr>
    </table>
</asp:Content>
