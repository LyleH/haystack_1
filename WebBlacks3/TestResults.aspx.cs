using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestResults : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
    }

	public List<String> testsPassed()
	{
		return new List<String>{
			"Test1",
			"Test3",
			"Test4"
		};
	}

	public List<String> testsFailed()
	{
		return new List<String>{
			"Test2",
			"Test5",
			"Test6",
		};
	}
}