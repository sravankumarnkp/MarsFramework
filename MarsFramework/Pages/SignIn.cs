﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MarsFramework.Global;
namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            SignIntab.Click();
            //sending login data
            Email.Click();
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            Password.Click();
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            LoginBtn.Click();
            GlobalDefinitions.wait(25);
            GlobalDefinitions.ExcelLib.ClearData();

        }
    }
}