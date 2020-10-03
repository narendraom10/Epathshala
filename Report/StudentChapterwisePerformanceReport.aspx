<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true" CodeFile="StudentChapterwisePerformanceReport.aspx.cs" Inherits="Report_StudentChapterwisePerformanceReport" %>

<%@ Register Src="../Student/Student_Examresult.ascx" TagName="Student_Examresult" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <link href="../App_Themes/bootstrap-3.3.7-dist/css/bootstrap.css" rel="stylesheet" />--%>
    <script src="../Scripts/Jquery1.9.1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"/>--%>
    <div class="row">
        <style>
            .mydropdownlist1 {
                color: black;
                font-size: 20px;
                padding: 5px 10px;
                background-color: white;
                font-weight: bold;
            }

            #Examresult button {
                padding: 0px !important;
                text-transform: none !important;
                color: blue !important;
                margin: 0px !important;
            }
        </style>

        <div class="col-12 col-sm-4 col-md-4 col-lg-3">
            <div class="input-group form-group">

                <%--<asp:Label ID="lblsubject" runat="server" Text="Subject"></asp:Label>
                    <br /><br />--%>
                <asp:DropDownList ID="ddlsubject" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="btnreport_Click">
                </asp:DropDownList>
                <i class="fa fa-caret-down" aria-hidden="true" style="margin-left: -15px; margin-right: 15px; margin-top: 15px;"></i>

            </div>
        </div>
        <div class="col-12 col-sm-8 col-md-8 col-lg-9">
            <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="pills-home-tab" data-toggle="pill" href="#pills-home" role="tab" aria-controls="pills-home" aria-selected="true">Report</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-profile-tab" data-toggle="pill" href="#pills-profile" role="tab" aria-controls="pills-profile" aria-selected="false">Chart</a>
                </li>
            </ul>
        </div>

    </div>
    <uc1:Student_Examresult ID="Student_Examresult1" runat="server" Visible="false" />



    <div class="row">

        <div class="col-12">

            <div class="tab-content" id="nav-tabContent">
                <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                    <div class="col-12 col-md-8">
                        <%--<div class="row">--%>
                        <div class="table-responsive">
                            <style>
                                #Examresult th {
                                    font-weight: bold;
                                    text-align: center;
                                    background-color: ##CFCFCF;
                                }

                                #Examresult td {
                                    text-align: center;
                                    background-color: white;
                                }
                            </style>
                            <table class="table table-bordered table-condensed" id="Examresult">
                                <%-- id="studentTable" width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >   --%>

                                <% if (tableData.Length > 63)
                                    { %>
                                <thead class="grey lighten-2" style="font-weight: bold; font-size: medium">
                                    <tr>
                                        <th scope="col">Exam Date</th>
                                        <th scope="col">Chapter No </th>
                                        <th scope="col">Chapter</th>
                                        <th scope="col">Percentage score</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <%} %>
                                <%=tableData%>


                                <%-- <tr>
                    <td>29/08/2018</td>
                    <td>2</td>
                    <td>Comparing Quantities</td>
                    <td>40</td>
                    <td><button type='button' class='btn-info' data-toggle='modal' data-target='#myModal' onclick='GetExamdetails(29)'>Details</button></td>
                    </tr>--%>
                            </table>


                        </div>
                        <%-- <div id="Resultdata" class="container-fluid">
            <div class="row">
                <div class="col-md-8 col-md-offset-2"

            </div>

        </div>--%>

                        <style>
                            .modal {
                                text-align: center;
                                padding: 0 !important;
                            }

                                .modal:before {
                                    content: '';
                                    display: inline-block;
                                    height: 100%;
                                    vertical-align: middle;
                                    margin-right: -4px; /* Adjusts for spacing */
                                }

                            .modal-dialog {
                                width: 80% !important;
                                min-width: 80% !important;
                                overflow-y: initial !important;
                                margin: 0;
                                padding: 0;
                                display: inline-block;
                                text-align: left;
                                vertical-align: middle;
                            }

                            .modal-content {
                                height: auto;
                                min-height: 100%;
                                border-radius: 0;
                            }

                            .modal-body {
                                height: 400px !important;
                                overflow-y: auto;
                            }
                        </style>
                        <div class="modal" id="myModal">
                            <div class="modal-dialog">
                                <div class="modal-content">

                                    <!-- Modal Header -->
                                    <div class="modal-header">
                                        <h4 class="modal-title" id="modal-title">Assessment Report</h4>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>

                                    <!-- Modal body -->
                                    <div id="modal-body" class="modal-body">
                                        <div id="dvcontent">
                                        </div>
                                    </div>

                                    <!-- Modal footer -->
                                    <%--<div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>--%>
                                </div>
                            </div>
                        </div>


                        <%-- </div>--%>
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                    <div class="col-12 col-md-8 ">
                        <script type="text/javascript">
                        <% subjectID = Convert.ToInt32(ddlsubject.SelectedValue); %>
                            var subjectID = <%: subjectID %>;
                            $.ajax({
                                type: "POST",
                                url: "StudentChapterwisePerformanceReport.aspx/GetPerformanceChartdata",
                                data: JSON.stringify({'subjectid': subjectID}),
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: OnSuccess_,
                                error: OnErrorCall_
                            });

                            function OnSuccess_(reponse) {
                                var aData = reponse.d;
                                var aLabels = aData[0];
                                var aDatasets1 = aData[1];
                        
                                var chartOptions = {
                                    responsive: true,
                                    title: {
                                        display: true,
                                        position: "top",
                                        text: "Performance Graph",
                                        fontSize: 18,
                                        fontColor: "#111"
                                    },
                                    scales: {
                                        yAxes: [{
                                            ticks: {
                                                max: 100,
                                                min: 0,
                                                stepSize: 20
                                            }
                                        }]
                                    },
                                };


                                var data = {
                                    labels: aLabels,
                                    datasets: [{
                                        label: "Chapter test performance",
                                        fill: false,
                                        borderColor: "lightblue",
                                        backgroundColor: "blue",
                                        fill: false,
                                        lineTension: 0,
                                        radius: 5,
                                        data: aDatasets1
                                    }]
                                };

                                //alert(aDatasets1.toString().replace(new RegExp(',', 'g'), '').length);

                                if (aDatasets1.toString().replace(new RegExp(',', 'g'), '').length > 0){
                                    var ctx = $("#myChart-<%: subjectID %>").get(0).getContext('2d');
                                    //alert(ctx);
                                    ctx.canvas.height = 350;  // setting height of canvas
                                    ctx.canvas.width = 500; // setting width of canvas
                                    //var lineChart = new Chart(ctx).Line(data, { bezierCurve: false });
                                    var myNewChart = new Chart(ctx, { type: "line", data: data, options: chartOptions });
                                }

                                

                        <%--var ctx1 = $("#myExpandedChart-<%: subjectID %>").get(0).getContext('2d');
                        //alert(ctx);
                        ctx1.canvas.height = 250;  // setting height of canvas
                        ctx1.canvas.width = 500; // setting width of canvas
                        //var lineChart = new Chart(ctx).Line(data, { bezierCurve: false });
                        var myNewExpChart = new Chart(ctx1, { type: "line", data: data, options: chartOptions });--%>

                            }
                            function OnErrorCall_(repo) {
                                alert("Woops something went wrong, pls try later !");
                            }

                        </script>
                        <canvas id="myChart-<%: subjectID %>" data-toggle="modal" data-target="#expandedChart-<%: subjectID %>"></canvas>
                    </div>
                </div>
            </div>
        </div>

    </div>



    <script>
        function GetExamdetails(examid) {


            PageMethods.GetResultsByExamid(examid, CallSuccess, CallFailed);

        }

        function CallSuccess(result) {

            var dest = document.getElementById("dvcontent");
            dest.innerHTML = result;


        }
        function CallFailed(result) {
            alert("No data Found");
        }
    </script>
    <script src="../App_Themes/bootstrap-3.3.7-dist/js/bootstrap.js"></script>





</asp:Content>

