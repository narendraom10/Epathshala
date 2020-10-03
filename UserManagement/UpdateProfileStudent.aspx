<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true"
	CodeFile="UpdateProfileStudent.aspx.cs" Inherits="UserManagement_UpdateProfileStudent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	
 
 <div class="card" style="width:800px !important">
  <h3 class="card-header  py-4">
		<strong>Profile</strong>
	</h3>
  <div class="card-body px-lg-5 pt-0">
		
	
     <p class="card-text" style="font-weight:bold;color:blue;">Basic Information</p> 
	   <div class="form-row">
				<div class="col">
					 
						 <asp:Label ID="lblAddFirstName" runat="server" Text="First Name"></asp:Label>
						<asp:TextBox ID="txtAddFirstName" CssClass="form-control" runat="server" onkeypress="return charecteronly(event);"></asp:TextBox>
					   
						<asp:RequiredFieldValidator ID="rqdAddFN" runat="server" ControlToValidate="txtAddFirstName"
								ErrorMessage="Enter First Name" ValidationGroup="PD"><%--*--%></asp:RequiredFieldValidator>
                </div>
              
                <div class="col">
					 
						  <asp:Label ID="lblAddLastName" runat="server" Text="Last Name"></asp:Label>
						 <asp:TextBox ID="txtAddLastName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
								CssClass="form-control"></asp:TextBox>
							&nbsp;<asp:RequiredFieldValidator ID="rqdAddLastName" runat="server" ControlToValidate="txtAddLastName"
								ErrorMessage="Enter Last Name" ValidationGroup="PD"><%--*--%></asp:RequiredFieldValidator>
					 
				</div>
				 
			</div>

				 
	  <div class="form-row">
				<div class="col">
					 
						 <asp:Label ID="lblAddDob" runat="server" Text="Date of Birth"></asp:Label>
						 <asp:ImageButton ID="ibtnAddCalender" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png" CssClass="" Width="20px" /></span>  
						  <asp:TextBox ID="txtAddDOB" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
							&nbsp;<asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtAddDOB"
								ErrorMessage="Enter Date in dd-MMM-yyyy Format." ValidationGroup="PD" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$">*</asp:RegularExpressionValidator>
							<cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtAddDOB"
								PopupButtonID="ibtnAddCalender" Enabled="True" Format="dd-MMM-yyyy">
							</cc1:CalendarExtender>
					 
				</div>
                <div class="col">
					 
						  <asp:Label ID="lblAddGender" runat="server" Text="Gender"></asp:Label>
						<asp:RadioButtonList ID="rlstAddGender" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="M" Text="Male"></asp:ListItem>
								<asp:ListItem Value="F" Text="Female"></asp:ListItem>
							</asp:RadioButtonList>

					
				</div>
			</div>

       <p class="card-text" style="font-weight:bold;color:blue;">Contact Information</p>
      <div class="form-row">
				<div class="col">
					 
						  <asp:Label ID="lblAddMobileNumber" runat="server" Text="Mobile Number"></asp:Label>
						 <asp:TextBox ID="txtAddMobileNumber" runat="server" CssClass="form-control" MaxLength="13"
								onkeypress="return phonenumber(event);"></asp:TextBox>
							 
							<asp:RegularExpressionValidator ID="regAddMobileNumber" runat="server" ControlToValidate="txtAddMobileNumber"
								ErrorMessage="Please Enter Mobile Number between 8 to 11 digit." ValidationGroup="PD"
								ValidationExpression="[\d]{8,11}">*</asp:RegularExpressionValidator>
					</div>
				 
			 
					<div class = "col">
						  <asp:Label ID="lblAddContactNumber" runat="server" Text="Alternate Number"></asp:Label>
						<asp:TextBox ID="txtAddContactNumber" runat="server" CssClass="form-control" MaxLength="13"
								onkeypress="return phonenumber(event);"></asp:TextBox>
							 
							<asp:RegularExpressionValidator ID="regcontactnumber" runat="server" ControlToValidate="txtAddContactNumber"
								ErrorMessage="Please Enter Number between 8 to 11 digit." ValidationGroup="PD"
								ValidationExpression="[\d]{8,11}">*</asp:RegularExpressionValidator>
					</div>
				 
		</div>
       <div class="form-row">
				<div class="col">
					 
							<asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
						<asp:TextBox ID="txtAddEmail" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
							 
							<asp:RegularExpressionValidator ID="revAddEMAIL" runat="server" ControlToValidate="txtAddEmail"
								ErrorMessage="Enter Valid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
								ValidationGroup="PD">*</asp:RegularExpressionValidator>
 
				</div>
		</div>
         <div class="form-row">
				<div class="col">
				 
						  <asp:Label ID="lblAddPermanentAddress" runat="server" Text="Permanent Address"></asp:Label>
						 <asp:TextBox ID="txtAddPermanentAddress" runat="server" CssClass="form-control"
								TextMode="MultiLine" Rows="3" BorderStyle="Double" BorderColor="Yellow" ></asp:TextBox>
							 
					 
					 
                     
				</div>
			</div>
      <p class="card-text" style="font-weight:bold;color:blue;">Security Information</p>
      <div class="form-row">
				<div class="col">
					 
						 <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label>
						<asp:TextBox ID="TxtOldPassword"   TextMode="Password" CssClass ="form-control" runat="server" Text=""></asp:TextBox>
					   
						 
                </div>
              
                <div class="col">
					 
						  <asp:Label ID="Label3" runat="server" Text="New Password"></asp:Label>
						 <asp:TextBox ID="TxtNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
										 
				</div>
				 
			</div>
      <br />
       <div class="form-row">
				<div class="col">
					 
                    <asp:Button ID="Txtsubmit" runat="server" Text="Submit" OnClick="btnUpdate_Click" /> 
					   
						 
                
					  <asp:Button ID="Txtreset" runat="server" Text="Reset" OnClientClick="ResetAll()" /> 
						   
										 
				</div>
				 
			</div>
  </div>

		
  
</div>


   
 
  
   


	  
	 
	<script type="text/javascript">
		function ResetAll() {
			$("#<%= txtAddFirstName.ClientID%>").val('');
			<%--$("#<%= txtAddMiddleName.ClientID%>").val('');--%>
			$("#<%= txtAddLastName.ClientID%>").val('');
			$("#<%= txtAddDOB.ClientID%>").val('');
		 <%--   $("#<%= txtAddBloodGroup.ClientID%>").val('');--%>
			$("#<%= txtAddPermanentAddress.ClientID%>").val('');
			$("#<%= txtAddMobileNumber.ClientID%>").val('');
			$("#<%= txtAddContactNumber.ClientID%>").val('');
			$("#<%= txtAddEmail.ClientID%>").val('');
			return false;
		}
		function phonenumber(evt) {
			var charCode = (evt.which) ? evt.which : event.keyCode
			if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 40 && charCode != 41)
				return false;
			return true;
		}
	</script>
</asp:Content>
