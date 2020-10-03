<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/epath2016.Master" AutoEventWireup="true"
    CodeFile="epathhome.aspx.cs" Inherits="NewPublic_epathhome" EnableTheming="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="StyleSheet/style.css" rel="stylesheet" />
    <style>
        /* CSS blockquote */
        .blockquote-inner
        {
            width: 100%;
        }
        div.blockquotetop:before
        {
            content: open-quote;
            font-size: 24pt;
            text-align: center;
            line-height: 42px;
            color: #fff;
            background: #ddd;
            float: left;
            position: relative;
            top: 30px;
        }
        div.blockquotetop:after
        {
            content: close-quote;
            font-size: 24pt;
            text-align: center;
            line-height: 42px;
            color: #fff;
            background: #ddd;
            float: right;
            position: relative;
            bottom: 40px;
        }
       
        /*blockquote {
	position:relative;
	marign:0;
	padding:30px 120px;
	text-align:center;
	font-size:30px;
	&:before,
	&:after {
		position: absolute;
		width:60px;
		height:60px;
		font-size:120px;
		line-height:1;
	}
	&:before {
		top:0;
		left:0;
		content:"\201C";
	}
	&:after {
		top:0;
		right:0;
		content:"\201D";
	}
}*/
        div.blockquote
        {
            font-family: Georgia, "Times New Roman" , serif;
            margin: 0px;
            color: #b4b4b4;
            font-weight: 400;
            line-height: 20px;
            font-style: italic;
            text-indent: 65px;
            position: relative;
            background-color: #f2f2f2;
            border-left: 3px solid #0da472;
            padding: 20px;
        }
        div.blockquote p
        {
            color: #686868 !important;
            font-family: "Raleway" ,sans-serif !important;
        }
        div.blockquote2
        {
            border-left: 3px solid #f8f8f8;
            padding: 20px;
            background-color: #f2f2f2;
            border-left: 3px solid #0da472;
        }
        div.blockquote1
        {
            font-family: Georgia, "Times New Roman" , serif;
            margin: 0px;
            color: #b4b4b4;
            font-weight: 400;
            line-height: 20px;
            font-style: italic;
            text-align: center;
            position: relative;
            background-color: #f2f2f2;
            border-left: 3px solid #0da472;
            padding: 20px 0 1px;
        }
        
        
        div.blockquote:before
        {
            content: '\201C';
            position: absolute;
            font-size: 40px;
            top: 25px;
            left: -45px;
            color: #0da472;
        }
        
        div.blockquote:after
        {
            content: '\201D';
            position: absolute;
            font-size: 40px;
            bottom: 5px;
            right: 25px;
            color: #0da472;
        }
        
        /*div.blockquote p {
                display: inline;
            }*/
        div.blockquote2 cite
        {
            color: #686868 !important;
            font-family: "Raleway" ,sans-serif !important;
            font-size: 13px !important;
            font-size: 14px;
            display: block;
            margin-top: 5px;
        }
    </style>
    <div>
        <img alt="homepage" class="img-responsive" src="Slider/img/homepageimg2.jpg" />
    </div>
    <section class="epath-sectionhead epath-section-align-center" style="background-color: #fff;
        border: 1px solid #ccc;">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h2>
                        Few Digital <strong>Content Samples...</strong></h2>
                </div>
            </div>
        </div>
    </section>
    <section class="epath-section epath-section-align-center">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="epath-relative" id="latest-projects">
                        <article class="epath-project epath-padding-left-40">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video1.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/0zcL00e3Oz8" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video2.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/h3NzF_CCsTk" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video3.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/7ShY83k-_SQ" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video4.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/l6N4aOkdeiU" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video5.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/QVXXHerjRRM" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video6.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/Rj9UUp16G80" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video7.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/Ab0AkGv2QoU" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video8.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/3gF34Go1CWw" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video9.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/fynHfPtJ064" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video10.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/CKZ1jsCHOPI" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <article class="epath-project epath-padding-left-30">
                            <div class="epath-project-inner">
                                <figure>
                                    <img src="img/video11.jpg" alt="" />
                                    <figcaption>
                                        <a href="https://www.youtube.com/embed/oSdqC3se-aQ" target="_blank"><i class="fa fa-plus">
                                        </i></a>
                                    </figcaption>
                                </figure>
                            </div>
                        </article>
                        <div class="epath-navigation rivaslider-navigation">
                            <a href="#" class="back"><i class="glyphicon glyphicon-chevron-left"></i></a><a href="#"
                                class="forward"><i class="glyphicon glyphicon-chevron-right"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <article style="margin-top: 10px;">
                        <p>
                            <img alt="didyouknow" src="Slider/img/did-you-know.jpg" />
                        </p>
                    </article>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <article style="margin-top: 10px;">
                        <p>
                            <img alt="learningstyle" src="Slider/img/learning-style.jpg" />
                        </p>
                    </article>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <article style="margin-top: 10px;">
                        <p>
                            <img alt="secstudent" src="Slider/img/secondary-student.jpg" />
                        </p>
                    </article>
                </div>
            </div>
        </div>
    </section>
    <section class="epath-section epath-padding-top-0">
        <div class="container">
            <div class="row">
                <div class="col-lg-8">
                    <h2 style="margin-bottom: 10px;">
                        ePathshala<strong>- Transforming Learning Through Technology</strong></h2>
                    <div class="epath-relative">
                        <div class="epath-post-preview-inner">
                            <p>
                                The revolutionary Right to Education Act (2009) marks a historic moment for the
                                children of India. It is a major challenge to provide lakhs of Indian children free
                                and compulsory education. The integrated education product, ePathshala from ePath
                                is a milestone that aims to provide a ripe platform for children of all learning
                                levels thereby making provision for those put to disadvantage because of social,
                                cultural, economical, geographical, linguistic and gender anomalies. ePath is an
                                all-inclusive education initiative by Arraycom (India) Limited. The group has over
                                20 years of experience in manufacturing of electronic materials, broadcasting systems
                                and communication system integration. The group also has vast experience in the
                                field of education with well-known initiatives like Ahmedabad International School
                                (AIS) in Ahmedabad and Toddlers' Den Preschools in Ahmedabad and Vadodara. ePath
                                is the result of educational and technological expertise of the group. ePath is
                                equipped with ideal tools to take on the challenges faced by the education system.
                                ePath provides opportunity to students to be constantly involved in the education
                                process through experiential learning thereby giving them the potential to transform
                                and grow into empowered individuals.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4" style="box-shadow: 10px 10px 5px #888888;">
                    <div class="epath-relative">
                        <div class="epath-post-preview-inner">
                            <div class="blockquote1">
                                <h4>
                                    Experimental <strong>Education Works</strong></h4>
                            </div>
                            <div class="blockquote1">
                                <blockquote>
                                    Tell me and I will forget; Show me and I may remember; Involve me and I will understand.
                                </blockquote>
                            </div>
                            <div class="blockquote2">
                                <cite>-Chinese proverb</cite></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="epath-section epath-section-st2 epath-section-cta2">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <p>
                        <span style="margin-top: 10px;"><strong>eVolve </strong>| A Self Assessment Portal</span><a
                            href="http://www.evolveassessment.com/" target="_blank" class="epath-btn epath-btn-normal epath-btn-border-white"><i
                                class="glyphicon glyphicon-eye-open"> </i>&nbsp;Visit</a>
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
