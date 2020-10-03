<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PartySignUpOnlineOffline.aspx.cs"
    Inherits="Dashboard_PartySignUpOnlineOffline" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td align="center">
                    <asp:Label ID="lblOfflineReg1" runat="server" Text="If you do not wan&#39;t
                For online fees payment then you have to download registration form by Click&nbsp;"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblorlebl" runat="server" Text="OR" Width="300px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblonlineReg1" runat="server" Text="If you are going with online payment option then you have to follow below steps for registration,<br/> After completion of online registration and payment done you will get comfirmation <br/> message on your given E-mail id and mobile."></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblonlineReg2" runat="server" Text="For online registration follow below steps."></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <ol type="1" style="padding: 20px">
                        <li>
                            <asp:LinkButton ID="lnkSBIICollect" Text="First click
                        here" runat="server" OnClick="lnkSBIICollect_Click" ValidationGroup="ABC"></asp:LinkButton>
                            <br />
                            <br />
                        </li>
                        <li>It will open following page, select state of corporate/Institution as ` Gujarat’
                            and Type of corporate/Institution as` Industry ’ and press Go button.<br />
                            <br />
                            <br />
                            <asp:Image ID="ImgFirst1" runat="server" ImageUrl="~/Images/Help1.png" /><br />
                            <br />
                        </li>
                        <li>Select Industry Name as `ARRAYCOM(INDIA)LIMITED’ then press submit button.<br />
                            <br />
                            <br />
                            <asp:Image ID="Img2" runat="server" ImageUrl="~/Images/Help2.png" /><br />
                            <br />
                        </li>
                        <li>After it open as per following page, here you have to select Payment Category as
                            `Student fees’.<br />
                            <br />
                            <br />
                            <asp:Image ID="Img3" runat="server" ImageUrl="~/Images/Help3.png" /><br />
                            <br />
                        </li>
                        <li>It will open student information page fill it and submit it.<br />
                            <br />
                            <br />
                            <asp:Image ID="Img4" runat="server" ImageUrl="~/Images/Help4.png" /><br />
                            <br />
                        </li>
                        <li>Verify details and confirm this transaction to do.<br />
                            <br />
                            <br />
                            <asp:Image ID="Img5" runat="server" ImageUrl="~/Images/Help5.png" /><br />
                            <br />
                        </li>
                        <li>On confirm transaction sbionline will give payment option, select proper option
                            and do transaction complete.<br />
                            <br />
                            <br />
                            <asp:Image ID="Img6" runat="server" ImageUrl="~/Images/Help6.png" Height="644px"
                                Width="1058px" /><br />
                            <br />
                        </li>
                    </ol>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
