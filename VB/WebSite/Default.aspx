<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>
	<script language="javascript" type="text/javascript">
		function UpdateItem(key, tbName, tbDescription) {            
			callback.PerformCallback(key + "," + tbName.GetValue() + "," + tbDescription.GetValue());
		}

		function ShowCallbackResult(s, e) {
			var results = e.result.split(",");
			alert("Item with key: " + results[0] + ", name: " + results[1] + ", description: " + results[2] + " was updated");
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<br />
		<br />
		<dx:ASPxDataView ID="dataView" runat="server" DataSourceID="dataSource" 
			EnableViewState="False">
			<ItemTemplate>
				<table style="width: 300px">
					<tr>
						<td>
							Category Name
							<dx:ASPxTextBox ID="tbName" runat="server" Width="170px" 
								Text='<%#Bind("CategoryName")%>' oninit="tbName_Init">
							</dx:ASPxTextBox>
						</td>
						<td align="right" style="width: 100px" valign="bottom">
							<dx:ASPxButton ID="btnUpdate" runat="server" Text="Update" AutoPostBack="False" 
								oninit="btnUpdate_Init" >
							</dx:ASPxButton>
						</td>
					</tr>
					<tr>
						<td colspan="2">
							Category Description
							<dx:ASPxTextBox ID="tbDescription" runat="server" Width="300px" 
								Text='<%#Bind("Description")%>' oninit="tbDescription_Init">
							</dx:ASPxTextBox>
						</td>
					</tr>
				</table>
			</ItemTemplate>
			<ItemStyle Height="0px" Width="0px" />
		</dx:ASPxDataView>
	</div>
	<asp:SqlDataSource ID="dataSource" runat="server" 
		ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
		SelectCommand="SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]"></asp:SqlDataSource>
	<dx:ASPxCallback ID="callback" runat="server" oncallback="callback_Callback">
		<ClientSideEvents CallbackComplete="ShowCallbackResult" />
	</dx:ASPxCallback>
	</form>
</body>
</html>