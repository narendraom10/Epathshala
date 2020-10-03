<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SchoolExamReportsClassRpt.ascx.cs" Inherits="UserControl_SchoolExamReportsClassRpt" %>


<table cellpadding="2" cellspacing="2" width="100%" style="margin: 5px 5px 5px 5px">
        <tr>
            <td align="right">
                <asp:Label ID="lblSchool" runat="server" Text="School:" ToolTip="School Name:" 
                    meta:resourcekey="lblSchoolResource1"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblSchoolValue" runat="server" 
                    meta:resourcekey="lblSchoolValueResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblBoard" runat="server" Text="Board:" ToolTip="Board" 
                    meta:resourcekey="lblBoardResource1"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBoardValue" runat="server" ToolTip="Board" 
                    meta:resourcekey="lblBoardValueResource1"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblMedium" runat="server" Text="Medium:" 
                    meta:resourcekey="lblMediumResource1"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMediumValue" runat="server" 
                    meta:resourcekey="lblMediumValueResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblStandard" runat="server" Text="Standard:" 
                    meta:resourcekey="lblStandardResource1"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblStandardValue" runat="server" 
                    meta:resourcekey="lblStandardValueResource1"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblsubject" runat="server" Text="Subject:" 
                    meta:resourcekey="lblsubjectResource1"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblsubjectValue" runat="server" 
                    meta:resourcekey="lblsubjectValueResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblChapter" runat="server" Text="Chapter:" 
                    meta:resourcekey="lblChapterResource1"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblChapterValue" runat="server" 
                    meta:resourcekey="lblChapterValueResource1"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lbltopic" runat="server" Text="Topic:" 
                    meta:resourcekey="lbltopicResource1"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbltopicValue" runat="server" 
                    meta:resourcekey="lbltopicValueResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblDate" runat="server" Text="Date:" 
                    meta:resourcekey="lblDateResource1"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDateValue" runat="server" 
                    meta:resourcekey="lblDateValueResource1"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblteacher" runat="server" Text="Teacher:" 
                    meta:resourcekey="lblteacherResource1"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblteacherValue" runat="server" 
                    meta:resourcekey="lblteacherValueResource1"></asp:Label>
            </td>
        </tr>
    </table>
    <table cellpadding="2" cellspacing="2" width="100%" style="margin: 5px 5px 5px 5px">
        <tr>
            <td>
                <asp:GridView ID="GrvResultDetails1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="StudentID,EmployeeID,BMSSCTID,DivisionID,StandardID,SubjectID,ChapterID,TopicID"
                    OnPageIndexChanging="GrvResultDetails1_PageIndexChanging" OnSorting="GrvResultDetails1_Sorting"
                    OnRowCreated="GrvResultDetails1_RowCreated" Width="100%" 
                    OnRowDataBound="GrvResultDetails1_RowDataBound" 
                    onselectedindexchanged="GrvResultDetails1_SelectedIndexChanged" 
                    meta:resourcekey="GrvResultDetails1Resource1">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No" 
                            meta:resourcekey="TemplateFieldResource1">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %></ItemTemplate>
                            <ItemStyle Width="10px" />
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="FirstName" SortExpression="FirstName" 
                            HeaderText="FirstName" meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="True" SortExpression="True" HeaderText="True" 
                            meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="False" SortExpression="False" HeaderText="False" 
                            meta:resourcekey="BoundFieldResource3" />
                        <asp:BoundField DataField="Perc" SortExpression="Perc" HeaderText="Result" 
                            meta:resourcekey="BoundFieldResource4" />
                    </Columns>
                    <PagerTemplate>
                        <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                            ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" 
                            ToolTip="Move First Page" meta:resourcekey="ibtnFirstResource1" />
                        <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                            ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" 
                            ToolTip="Move Previous Page" meta:resourcekey="ibtnPreviousResource1" />
                        <asp:Label ID="lblPage" runat="server" Text="Page" 
                            meta:resourcekey="lblPageResource1"></asp:Label>
                        <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                            runat="server" AutoPostBack="True" SkinID="DdlWidth50" 
                            meta:resourcekey="ddlPageSelectorResource1">
                        </asp:DropDownList>
                        <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                            ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" 
                            ToolTip="Move Next Page" meta:resourcekey="ibtnNextResource1" />
                        <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                            ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" 
                            ToolTip="Move Last Page" meta:resourcekey="ibtnLastResource1" />
                    </PagerTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
   
    
  