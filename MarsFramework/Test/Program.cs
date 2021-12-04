using NUnit.Framework;
using MarsFramework.Pages;
using MarsFramework.Global;
using RelevantCodes.ExtentReports;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        public class User : Base
        {
            Profile profileObj;
            ShareSkill sharSkillObj;
            ManageListings manageListingsObj;


            [Test, Order(1001), Description("Check if use able to click on 'shar skill' button in profile home page")]
            public void viewsharskillPage()
            {
                test.Log(LogStatus.Info, " viewsharskillPage");

                profileObj = new Profile();
                profileObj.EditProfile();
                GlobalDefinitions.wait(15);

            }
            [Test, Order(1002),Description("create a Listings")]
            public void creatListing()
            {
               test.Log(LogStatus.Info, " createing listing");
                profileObj = new Profile();
                sharSkillObj = new ShareSkill();
                profileObj.EditProfile();
                //creating listing from the excel sheet row 1
                sharSkillObj.EnterShareSkill();
                GlobalDefinitions.wait(15);


            }

            [Test, Order(1003), Description("view all Listings in manage listing page ")]
            public void view_all_listings()
            {
                test.Log(LogStatus.Info, " view all Listings in manage listing page");
                profileObj = new Profile();
                profileObj.manageListingpage();
                

            }
            
            [Test, Order(1004),Description("view detail listing ")]
            public void viewdetailListing()
            {
                test.Log(LogStatus.Info, " view details listing ");
                profileObj = new Profile();
                manageListingsObj = new ManageListings();
                profileObj.manageListingpage();
                manageListingsObj.viewListings();


            }


            [Test, Order(1005),Description("edit listing Manage a Listings")]
            public void editthelisting()
            {
                test.Log(LogStatus.Info, " edit listing Manage a Listings");
                profileObj = new Profile();
                manageListingsObj = new ManageListings();
                sharSkillObj = new ShareSkill();
                profileObj.manageListingpage();
                manageListingsObj.editListings(sharSkillObj);
                
                
            }


            [Test, Order(1006),Description("delete listing Manage a Listings")]
            public void deletingthelisting()
            {
                test.Log(LogStatus.Info, " delete listing Manage a Listings");
                profileObj = new Profile();
                manageListingsObj = new ManageListings();
                //open the manage listing page
                profileObj.manageListingpage();
                //deleting the listings 
                manageListingsObj.delListings();


            }


        }
    }
}