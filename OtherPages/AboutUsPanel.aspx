<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="AboutUsPanel.aspx.cs" Inherits="OtherPages_AboutUsPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="sub-banner">
                <img class="img-responsive margin-bottom-20" style="margin-top: 10px;" src="../App_Themes/Green/Images/about-us-banner.jpg"
                    alt="" />
            </div>
            <div class="main-content-part" style="text-align: justify; color: Black;">
                <p>
                    ePathshala is an on-line digital school from E-path (www.epathshala.co.in) with
                    a well-researched innovative and comprehensive pedagogy of learning through technology,
                    teacher and teaching-learning resources.</p>
                <p>
                    It is useful for schools as well as individual students or out of school children
                    through access to online repositories, study aids, practice tests, etc.</p>
                <p class="margin-top-20">
                    <strong>ePathshala is</strong></p>
                <p>
                    <img class="img-responsive " src="../App_Themes/Green/Images/about-us-icon-1.jpg"
                        alt="" /></p>
                <p class="margin-top-20">
                    <strong>Learning measures in ePathshala are</strong></p>
                <p>
                    <img class="img-responsive margin-bottom-20" src="../App_Themes/Green/Images/about-us-icon-2.jpg"
                        alt="" /></p>
                <p class="margin-top-20 margin-bottom-20" style="text-align: justify">
                    ePathshala covers complete curriculum as prescribed by various education boards
                    using comprehensive software.</p>
                <ul class="ul-list-style">
                    <li style="text-align: justify">It is concept and syllabus based detailed teaching method
                        using visual aids like graphics, animation, slideshows and videos.</li>
                    <li style="text-align: justify">Learning is enriched through use of technological gadgets
                        (tablets, computers, etc.), publications (study material like worksheets, MCQs,
                        etc.) and various other teaching-learning resources.</li>
                </ul>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        //This function is to simply make current page menu item active.
        $(document).ready(function () {
            $('.puerto-menu li .active').removeClass('active');
            $('.puerto-menu li:nth-child(2) a:first').addClass('active');
        });
    </script>
</asp:Content>
