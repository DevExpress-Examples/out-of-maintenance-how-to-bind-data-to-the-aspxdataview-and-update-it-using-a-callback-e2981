Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub tbName_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim tb As ASPxTextBox = TryCast(sender, ASPxTextBox)
		tb.ClientInstanceName = String.Format("tbName{0}", GetKeyValue(tb))
	End Sub
	Protected Sub tbDescription_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim tb As ASPxTextBox = TryCast(sender, ASPxTextBox)
		tb.ClientInstanceName = String.Format("tbDescription{0}", GetKeyValue(tb))
	End Sub
	Protected Sub btnUpdate_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim btn As ASPxButton = TryCast(sender, ASPxButton)

		btn.ClientSideEvents.Click = String.Format("function(s, e) {{ UpdateItem(""{0}"", tbName{0}, tbDescription{0}) }}", GetKeyValue(btn))
	End Sub

	Private Function GetKeyValue(ByVal sender As Control) As Integer
		Dim container As DataViewItemTemplateContainer = TryCast(sender.NamingContainer, DataViewItemTemplateContainer)

		If container.DataItem IsNot Nothing Then
			Return CInt(Fix(DataBinder.Eval(container.DataItem, "CategoryId")))
		End If
		Return -1
	End Function
	Protected Sub callback_Callback(ByVal source As Object, ByVal e As DevExpress.Web.CallbackEventArgs)
		e.Result = e.Parameter
	End Sub
End Class
