using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }
        //finding the listing which one to view
        [FindsBy (How= How.XPath, Using="//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[*]/td[3]")]
           private IList <IWebElement> findTitle { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[*]/td[8]/div/button[1]/i")]
        private IList<IWebElement> view;

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[*]/td[8]/div/button[3]/i")]
        private IList<IWebElement> delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[*]/td[8]/div/button[2]/i")]
        private IList<IWebElement> edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        private IWebElement clickActionsButton { get; set; }
        ///html/body/div[2]/div/div[3]/button[2]
        //

        internal void viewListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            string viewtilte = GlobalDefinitions.ExcelLib.ReadData(2, "view");
            if(viewtilte.Contains("y"))
            {
                string titleview = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                int size=findTitle.Count;
                Console.WriteLine(titleview+"is "+size);

                for (int i=0;i<size;i++)
                {
                    string s = findTitle.ElementAt(i).Text;
                    Console.WriteLine(s);
                    if (s.Contains(titleview))
                    {
                        //Click on view 
                        Console.WriteLine("befor manager click if");
                        
                        view.ElementAt(i).Click();
                        manageListingsLink.Click();
                        
                        Console.WriteLine("after manager click if");
                    }
                }
                
            }


        }
        internal void editListings(ShareSkill sharskillObj)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            string edittilte = GlobalDefinitions.ExcelLib.ReadData(2, "edit");
            if (edittilte.Contains("y"))
            {
                string titleview = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                int size = findTitle.Count;
                Console.WriteLine(titleview + "is " + size);

                for (int i = 0; i < size; i++)
                {
                    string s = findTitle.ElementAt(i).Text;
                    Console.WriteLine(s);
                    if (s.Contains(titleview))
                    {
                        //Click on view 
                        Console.WriteLine("befor share click if");

                        edit.ElementAt(i).Click();

                        sharskillObj.EditShareSkill();
                        Console.WriteLine("after edit share skill click if");
                    }
                }

            }

         
        }
        internal void delListings()
        {
           
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            string edittilte = GlobalDefinitions.ExcelLib.ReadData(2, "delete");
            if (edittilte.Contains("y"))
            {
                string titleview = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                int size = findTitle.Count;
                Console.WriteLine(titleview + "is " + size);

                for (int i = 0; i < size; i++)
                {
                    string s = findTitle.ElementAt(i).Text;
                    Console.WriteLine(s);
                    if (s.Contains(titleview))
                    {
                        //Click on view 
                        Console.WriteLine("befor share click if");

                        delete.ElementAt(i).Click();
                        clickActionsButton.Click();
                        Thread.Sleep(25);
                        //sharskillObj.EditShareSkill();
                        size = findTitle.Count;
                        i = 0;
                        Console.WriteLine("after edit share skill click if new size"+size);
                    }
                }

            }

        }


    }
}
