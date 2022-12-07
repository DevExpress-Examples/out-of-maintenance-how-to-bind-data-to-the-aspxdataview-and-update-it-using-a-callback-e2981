using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page
{
	protected void tbName_Init(object sender, EventArgs e) {
		ASPxTextBox tb = sender as ASPxTextBox;
		tb.ClientInstanceName = String.Format("tbName{0}", GetKeyValue(tb));
	}
	protected void tbDescription_Init(object sender, EventArgs e) {
		ASPxTextBox tb = sender as ASPxTextBox;
		tb.ClientInstanceName = String.Format("tbDescription{0}", GetKeyValue(tb));
	}
	protected void btnUpdate_Init(object sender, EventArgs e) {
		ASPxButton btn = sender as ASPxButton;

		btn.ClientSideEvents.Click = String.Format("function(s, e) {{ UpdateItem(\"{0}\", tbName{0}, tbDescription{0}) }}", GetKeyValue(btn));
	}

	private int GetKeyValue(Control sender) {
		DataViewItemTemplateContainer container = sender.NamingContainer as DataViewItemTemplateContainer;

		if (container.DataItem != null)
			return (int)DataBinder.Eval(container.DataItem, "CategoryId");
		return -1;
	}
	protected void callback_Callback(object source, DevExpress.Web.CallbackEventArgs e) {
		e.Result = e.Parameter;
	}
}
