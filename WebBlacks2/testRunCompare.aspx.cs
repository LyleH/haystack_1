using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBlacks2.Objects;

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

		public List<TestCompareLine> testRows()
		{

			return new List<TestCompareLine>{
				new TestCompareLine{
					LineNumber = 1,
					Before = "You, Edwin, are a goatherd. Your task is to watch the goats. You know a  great deal about goats. A bacteriologist watches germs. That's his ",
					After = "You, Edwin, are a goatherd. Your task is to watch the goats. You know a  great deal about goats. A bacteriologist watches germs. That's his "
				},
				new TestCompareLine{
					LineNumber = 2,
					Before ="I have no quarrel with Tars Tarkas; together we rule supreme the greatest of the",
					After = "I have no quarrel with Tars Tarkas; together we rule supreme the greatest of the"
				},
				
				new TestCompareLine{
					LineNumber = 3,
					Colour = "GreenYellow",
					Before = "So they all entered the house, where there were, besides the woman, two children and a man.  The man",
					After = "So they all entered the house, where there were, besides the woman, two children and a man.  The man"
				},
				new TestCompareLine{
					LineNumber = 4,
					Colour = "GreenYellow",
					Before ="They waited until Dorothy awoke the next morning.  The little girl was quite frightened when she saw the",
					After = "They waited until Dorothy awoke the next morning.  The little girl was quite frightened when she saw the"
				},

				new TestCompareLine{
					LineNumber = 5,
					Colour = "Tomato",
					Before = "Alice caught the baby with some difficulty, as it was a queer-shaped  little creature, and held",
					After ="Alice dropped the baby on the floor."
				},

				new TestCompareLine{
					LineNumber = 6,
					Before = "Stamp Proctor and Phileas Fogg recognised each other at once. 'Ah! it's you, is it, Englishman?' cried the colonel; 'it's",
					After = "Stamp Proctor and Phileas Fogg recognised each other at once. 'Ah! it's you, is it, Englishman?' cried the colonel; 'it's"
				},

				new TestCompareLine{
					LineNumber = 7,
					Before = "'I shall do nothing of the sort,' said the Mouse, getting up and",
					After = "'I shall do nothing of the sort,' said the Mouse, getting up and"
				},
				new TestCompareLine{ 
					LineNumber = 8,
					Before = "",
					After = ""
				},
				
				new TestCompareLine{
					LineNumber = 9,
					Before = "'Do you mean that you think you can find out the answer to it?' said the ",
					After = "'Do you mean that you think you can find out the answer to it?' said the "
				},

				new TestCompareLine{
					LineNumber = 10,
					Before = "\"Because you are wise and powerful, and no one else can help me,\" answered the Scarecrow.",
					After = "\"Because you are wise and powerful, and no one else can help me,\" answered the Scarecrow."
				},

				new TestCompareLine{
					LineNumber = 11,
					Before = "'I didn't know it was YOUR table,' said Alice; 'it's laid for a great  many more than three.' 'Your hair wants cutting,' said the Hatter.",
					After = "'I didn't know it was YOUR table,' said Alice; 'it's laid for a great  many more than three.' 'Your hair wants cutting,' said the Hatter."
				},

				new TestCompareLine{ 
					LineNumber = 12,
					Before = "These three great divisions of the higher Martians had been forced into a mighty alliance as",
					After = "These three great divisions of the higher Martians had been forced into a mighty alliance as"
				},
				new TestCompareLine{
					LineNumber = 13,
					Before = "\"Oh, yes,\" said the girl, \"and he is a great coward, too.  He will be more afraid of you than you are",
					After = "\"Oh, yes,\" said the girl, \"and he is a great coward, too.  He will be more afraid of you than you are"
				},

				new TestCompareLine{
					LineNumber = 14,
					Before = "",
					After = ""
				},
				
				new TestCompareLine{
					LineNumber = 15,
					Before = "\"Twenty or thirty years ago my story was in great demand. But in these  days nobody seems interested-;\" \"There you go!\" Hare-Lip",
					After = "\"Twenty or thirty years ago my story was in great demand. But in these  days nobody seems interested-;\" \"There you go!\" Hare-Lip"
				}

			};
		}
	}
}