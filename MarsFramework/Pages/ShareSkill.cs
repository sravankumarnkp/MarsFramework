using System;
using System.Collections.Generic;
using System.Linq;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AutoItX3Lib;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }


        [FindsBy(How = How.TagName, Using = "option")]

        private IList<IWebElement> CategoryDropDownlist { get; set; }


        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        [FindsBy(How = How.TagName, Using = "option")]

        private IList<IWebElement> subCategoryDropDownlist { get; set; }


        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        [FindsByAll] [FindsBy(How = How.Name, Using = "serviceType")]
        private IList<IWebElement> ServiceType { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        [FindsByAll]
        [FindsBy(How = How.Name, Using = "locationType")]
        private IList<IWebElement> LocationType { get; set; }



        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        ////[FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        ////private IList< IWebElement> Days1 { get; set; }

        //////Storing the table of available days

        [FindsBy(How = How.XPath, Using = "//div[@class='ui checkbox']//input[@name='Available']")]
        private IList<IWebElement> Days { get; set; }



        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[@class='four wide field']//input[@name='StartTime']")]
        private IList<IWebElement> StartTimeDropdown { get; set; }

        ////Click on StartTime dropdown
        //[FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        //private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[@class='four wide field']//input[@name='EndTime']")]
        private IList<IWebElement> EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']//input[@name='skillTrades']")]
        private IList<IWebElement> SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input")]

        private IWebElement CreditAmount { get; set; }
        //form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']
        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//div[@class = 'field']//input[@name='isActive']")]
        private IList<IWebElement> ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //image icon webelment
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement imageIcon { get; set; }

        internal void EnterShareSkill()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            shareSkillTitle();
            //AutoItX3 autoIt = new AutoItX3();
            //sending the descriptiion
            string desText = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
            shareListenDescTextField(desText);
            //selecting cat 
            string categoryType = GlobalDefinitions.ExcelLib.ReadData(2, "Category");

            selectCategory(categoryType);
            string subcategoryType = GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory");
            //sub cat
            selectSubcategory(subcategoryType);
            String tagText = GlobalDefinitions.ExcelLib.ReadData(2, "Tags");
            tagField(tagText);

            //Working with Service Type

            string userserviceType = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
            serviceTypeButton(userserviceType);

            //Working with Location Type


            string userLocationType = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");
            locationtypeButton(userLocationType);

            // ServiceTypeOptions.Click();
            GlobalDefinitions.wait(15);

            //working with start date and end date

            String Enddate = GlobalDefinitions.ExcelLib.ReadData(2, "Enddate");
            // StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));

            EndDateDropDown.SendKeys(Enddate);
            GlobalDefinitions.wait(25);

            //bool sun =suncheckbox.Selected;
            Console.WriteLine(Days.Count);
            string selectDay = GlobalDefinitions.ExcelLib.ReadData(2, "Selectday");
            switch (selectDay)
            {
                case "Sun":
                    selectDay = "0";
                    break;
                case "Mon":
                    selectDay = "1";
                    break;

                case "Tue":
                    selectDay = "2";
                    break;

                case "Wed":
                    selectDay = "3";
                    break;

                case "Thu":
                    selectDay = "4";
                    break;

                case "Fri":
                    selectDay = "5";
                    break;

                case "Sat":
                    selectDay = "6";
                    break;


            }
            //String endt = GlobalDefinitions.ExcelLib.ReadData(2, "Endtime");
            //Console.WriteLine(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            String startTimetext = GlobalDefinitions.ExcelLib.ReadData(2, "Starttime");
            String endTimeText = GlobalDefinitions.ExcelLib.ReadData(2, "Endtime");
            int size = Days.Count;
            selectDayandTime(selectDay, startTimetext, endTimeText, size);
            GlobalDefinitions.wait(125);


            //skill trade  and applying Skill-Exchange and Credit service

            String skillTradebutton = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
            String skillExe = GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange");
            String exclcredit = GlobalDefinitions.ExcelLib.ReadData(2, "Credit");
            skillTrade(skillTradebutton, skillExe, exclcredit);

            //upload image 
            imageIcon.Click();
            AutoItX3 autoIt = new AutoItX3();
            Thread.Sleep(2000);
            autoIt.WinActivate("Open"); // Window name to select a file 
            autoIt.Send(@"C:\Users\Dell\Documents\test.txt"); // file path 
            Thread.Sleep(1500);
            autoIt.Send("{Enter}");
           // var procStartInfo = new System.Diagnostics.ProcessStartInfo(@"C:\Users\Dell\Documents\marsframework\MarsFramework\TestReports\fileupload.exe");

            //var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };

            //proc.Start();

            //proc.WaitForExit(5000);

            //proc.Kill();

            //active or hidden 
            String exlActive = GlobalDefinitions.ExcelLib.ReadData(2, "Active");
            activeButton(exlActive);
                   

            GlobalDefinitions.wait(25);

            Save.Click();

            GlobalDefinitions.wait(25);


        }

        private void activeButton(string exlActive)
        {
            if ((exlActive.Contains("Active")))
            {
                ActiveOption.ElementAt(0).Click();
                Console.WriteLine("Active  if cond");
            }

            else
            {
                ActiveOption.ElementAt(1).Click();
                Console.WriteLine(" Hidden if cond ");
            }
        }

        private void skillTrade(string skillTradebutton, string skillExe, string exclcredit)
        {
            if ((skillTradebutton.Contains("Skil-Exchange")))
            {
                SkillTradeOption.ElementAt(0).Click();
                SkillExchange.SendKeys(skillExe + Keys.Enter);
                Console.WriteLine("in if cond");
            }
            else
            {
                SkillTradeOption.ElementAt(1).Click();

                //PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
                CreditAmount.SendKeys(exclcredit);
                Console.WriteLine("not in  if cond");
            }
        }

        private void selectDayandTime(string selectDay, string startTimetext, string endTimeText, int size)
        {
            for (int j = 0; j < size; j++)
            {
                string s = Days.ElementAt(j).GetAttribute("index");
                if (s == selectDay)
                {
                    Days.ElementAt(j).Click();
                    // GlobalDefinitions.wait(35);
                    StartTimeDropdown.ElementAt(j).SendKeys(stringToTime(startTimetext));

                    EndTimeDropDown.ElementAt(j).SendKeys(stringToTime(endTimeText));


                }

            }
        }

        private void locationtypeButton(string userLocationType)
        {
            GlobalDefinitions.wait(15);



            // This will check that if the userserviceType is Hourly basis service means if the first radio button is selected
            if (userLocationType.Contains("On-site"))
            {
                // This will select Second radio button, if the first radio button is selected by default
                LocationType.ElementAt(0).Click();
            }
            else
            {
                // If the first radio button is not selected by default, the first will be selected
                LocationType.ElementAt(1).Click();
            }
        }

        private void serviceTypeButton(string userserviceType)
        {
            GlobalDefinitions.wait(15);



            // This will check that if the userserviceType is Hourly basis service means if the first radio button is selected
            if (userserviceType == "Hourly basis service")
            {
                // This will select Second radio button, if the first radio button is selected by default
                ServiceType.ElementAt(0).Click();
            }
            else
            {
                // If the first radio button is not selected by default, the first will be selected
                ServiceType.ElementAt(1).Click();
            }
        }

        private void tagField(string tagText)
        {
            //working with Tag field
            Tags.Click();
            Tags.SendKeys(tagText);
            Tags.SendKeys(Keys.Enter);
        }

        private void selectSubcategory(string subcategoryType)
        {
            SubCategoryDropDown.Click();
            
            foreach (IWebElement cat in subCategoryDropDownlist)
            {
                if (cat.Text == subcategoryType)
                {
                    cat.Click();
                    Console.WriteLine(cat);
                    // i++;
                    break;
                }

                Console.WriteLine("test" + subcategoryType);


            }
        }

        private void selectCategory(string categoryType)
        {
            CategoryDropDown.Click();
            //int i = 2;

            foreach (IWebElement cat in CategoryDropDownlist)
            {
                if (cat.Text == categoryType)
                {
                    cat.Click();
                    Console.WriteLine(cat);
                    //i++;
                    break;
                }

                Console.WriteLine("test" + categoryType);


            }
        }

        private void shareListenDescTextField(string desText)
        {
            Description.Click();
            Description.SendKeys(desText);
        }

        private void shareSkillTitle()
        {
            //entering the data from excel sheet
            Title.Click();
            GlobalDefinitions.wait(15);
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
        }

        private static string stringToTime(string endt)
        {
            Console.WriteLine(endt);
            var result = Convert.ToDateTime(endt);
            String time = result.ToString("hhmmtt", System.Globalization.CultureInfo.CurrentCulture);
            Console.WriteLine(time + "new ");
            return time;
        }

        internal void EditShareSkill()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "editShareSkill");
            String exlActive = GlobalDefinitions.ExcelLib.ReadData(2, "Active");
            GlobalDefinitions.wait(25);
            StartDateDropDown.SendKeys(DateTime.Now.ToString("ddMMyyyy"));

            activeButton(exlActive);
            Save.Click();





        }
    }
}
