<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Student_Examresult.ascx.cs" Inherits="Student_WebUserControl" %>
<asp:GridView ID="GrdExamResult" runat="server"  AutoGenerateColumns="false">

    <Columns>
        <asp:TemplateField HeaderText="Question">

            <ItemTemplate>

                <%#Eval("Question") %>

            </ItemTemplate>


        </asp:TemplateField>

        <asp:TemplateField HeaderText="Given Answer">

            <ItemTemplate>

                <%#Eval("GivenAnswer") %>

            </ItemTemplate>


        </asp:TemplateField>
        <asp:TemplateField HeaderText="Correct Answer">

            <ItemTemplate>

                <%#Eval("Answer") %>

            </ItemTemplate>


        </asp:TemplateField>
        <asp:TemplateField HeaderText="Score">

            <ItemTemplate>

                <%#Eval("Score") %>

            </ItemTemplate>


        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

 