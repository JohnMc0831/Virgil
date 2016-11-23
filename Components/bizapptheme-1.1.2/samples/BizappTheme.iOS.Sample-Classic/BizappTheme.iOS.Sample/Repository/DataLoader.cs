using System;
#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace ThemeSample.Models {
	public class DataLoader {
		public static Model[] LoadSampleData ()
		{
			String content1 = "<p>Finding a <a href='#'>suitable conveyancing solicitor</a> for your conveyancing needs is harder than you think. Some estate agents and mortgage advisors only promote property solicitors that they think we reap them the biggest referral fee and are no way concerned whether your receive a poor or good service. </p><p>Some agents don’t like recommending anyone as a poor service from a conveyancing firm may reflect badly on themselves or their company. With this in mind, where do you search next and does price reflect quality of service received?  </p><p>Yes everyone would like a proactive solicitor that is experienced and efficient for their transaction but are the clients willing to pay the increased fees? Unfortunately no one anticipate poor communication and neglectful service from any professional regardless of the occupation, and the same applies to conveyancing solicitors. </p><p>Usually solicitors these days don’t talk in plain English and don’t feel the need to explain anything to their clients so they understand what is actually going on in the conveyancing process</p> <ul><li>Mergers and Acquisitions</li><li>Conveyancing</li><li>Litigation</li></ul>";
			String content2 = "<p>A lawsuit or (less commonly) is a civil action brought in a court of law in which a plaintiff, a party who claims to have incurred loss as a result of a defendant's actions, demands a legal or equitable remedy. The defendant is required to respond to the plaintiff's complaint. </p><p>The conduct of a lawsuit is called litigation. One who has a tendency to litigate rather than seek non-judicial remedies is called litigious.[1] The plaintiffs and defendants are called litigants and the attorneys representing them are called litigators</p>";
			String content3 = "<p>Corporate law is the study of how shareholders, directors, employees, creditors, and other stakeholders such as consumers, the community and the environment interact with one another. </p><p>The four defining characteristics of the modern corporation are:</p> <ul><li>Separate Legal Personality of the corporation (access to tort and contract law in a manner similar to a person)</li><li>Limited Liability of the shareholders</li><li>Shares (if the corporation is a public company, the shares are traded on a stock exchange)</li><li>Delegated Management; the board of directors delegates day-to-day management</li><ul>";
			
			Model model1 = new Model ("Litigation", UIImage.FromFile ("service-1.png"), "Litigation: Peace of mind with the experts", AddCSSTo (content1), UIImage.FromFile ("service-main-1.jpg"));
			Model model2 = new Model ("Employment Law", UIImage.FromFile ("service-2.png"), "Employment Law: Know your rights", AddCSSTo (content2), UIImage.FromFile ("service-main-2.jpg"));
			Model model3 = new Model ("Corporate Law", UIImage.FromFile ("service-3.png"), "Corporate Law: Organise your books", AddCSSTo (content3), UIImage.FromFile ("service-main-3.jpg"));
			Model model4 = new Model ("Family Law", UIImage.FromFile ("service-4.png"), "Family Law: Make the right choice", AddCSSTo (content1), UIImage.FromFile ("service-main-1.jpg"));
			Model model5 = new Model ("Mergers", UIImage.FromFile ("service-5.png"), "Mergers: Hamony between companies", AddCSSTo (content2), UIImage.FromFile ("service-main-2.jpg"));
			Model model6 = new Model ("Conveyancing", UIImage.FromFile ("service-6.png"), "Conveyancing: Make the right choice", AddCSSTo (content3), UIImage.FromFile ("service-main-3.jpg"));
			
			var models = new Model[] { model1, model2, model3, model4, model5, model6 };
			
			return models;
		}

		public static Update[] LoadSampleUpdates ()
		{
			Update update1 = new Update ("0.5m Attorneys in the US", "bbc.com / John English", UIImage.FromFile ("avatar.png"), UpdateType.FacebookUpdate, "The BBC has reported that there are now over 0.5 million attorneys in the US.");
			Update update2 = new Update ("Is the power of attorney working?", "wsj.com / John Staten", UIImage.FromFile ("avatar.png"), UpdateType.FacebookUpdate, "London registered the power of attorney over his mother's financial affairs after she began suffering from dementia");
			Update update3 = new Update ("Law Firm of Akin Gump Has Defamation Lawsuit", "bbc.com / John English", UIImage.FromFile ("avatar.png"), UpdateType.TwitterUpdate, "A second defamation lawsuit has been filed against Akin Gump Strauss Hauer & Feld LLP within one week");
			
			var updates = new Update[] { update1, update2, update3 };
			
			return updates;
		}

		static string AddCSSTo (String content)
		{
			String webContent = string.Format ("<html> \n" +
			                        "<head> \n" +
			                        "<style type=\"text/css\"> \n" +
			                        "body {{font-family: \"{0}\"; font-size: {1};}}\n" +
			                        "</style> \n" +
			                        "</head> \n" +
					                "<body>{2}</body> \n" +
			                        "</html>", "helvetica", 16, content);
			return webContent;
		}
	}
}

