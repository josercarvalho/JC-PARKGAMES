using System.Web.Optimization;
using JC_PARK.Web.MVC;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(FontAwesomeBundleConfig), "RegisterBundles")]

namespace JC_PARK.Web.MVC
{
	public class FontAwesomeBundleConfig
	{
		public static void RegisterBundles()
		{
			// Add @Styles.Render("~/Content/fontawesome") in the <head/> of your _Layout.cshtml view
			// When <compilation debug="true" />, MVC will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
			BundleTable.Bundles.Add(new StyleBundle("~/Content/fontawesome").Include("~/Content/fontawesome/font-awesome.css"));
		}
	}
}