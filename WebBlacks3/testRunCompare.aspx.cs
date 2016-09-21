using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBlacks2
{
	public partial class testRunCompare : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string rawId = Request.QueryString["TestName"];
			if (!String.IsNullOrEmpty(rawId))
			{
				title.Text = rawId;
			}
			else
			{
				//redirect to default page
				Response.Redirect("Default.aspx");
			}
		}

		public List<String> testRows()
		{

			return new List<string>{
				"You, Edwin, are a goatherd. Your task is to watch the goats. You know a  great deal about goats. A bacteriologist watches germs. That's his ",
				"I have no quarrel with Tars Tarkas; together we rule supreme the greatest of the",
				"So they all entered the house, where there were, besides the woman, two children and a man.  The man",
				"They waited until Dorothy awoke the next morning.  The little girl was quite frightened when she saw the",
				"Alice caught the baby with some difficulty, as it was a queer-shaped  little creature, and held",
				"Stamp Proctor and Phileas Fogg recognised each other at once. \"Ah! it's you, is it, Englishman?\" cried the colonel; \"it's",
				"'I shall do nothing of the sort,' said the Mouse, getting up and",
				"",
				"'Do you mean that you think you can find out the answer to it?' said the ",
				"\"Because you are wise and powerful, and no one else can help me,\" answered the Scarecrow.",
				"'I didn't know it was YOUR table,' said Alice; 'it's laid for a great  many more than three.' 'Your hair wants cutting,' said the Hatter.",
				"These three great divisions of the higher Martians had been forced into a mighty alliance as",
				"\"Oh, yes,\" said the girl, \"and he is a great coward, too.  He will be more afraid of you than you are",
				"",
				"\"Twenty or thirty years ago my story was in great demand. But in these  days nobody seems interested-;\" \"There you go!\" Hare-Lip",

			};
		}
	}
}