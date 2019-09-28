using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class EducationProfileFeatureSteps
    {
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            //Click on Profile tab
            Driver.driver.FindElement(By.XPath("(//a[@class='item'][contains(.,'Profile')])[2]")).Click();

            // Click Educatin on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();

        }

        [When(@"I add a new educational background")]
        public void WhenIAddANewEducationalBackground()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();

            //Add College or Univeristy Name 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")).SendKeys("PUP");

            //Click on Country of College or University Dropdown
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select")).Click();

            //Choose a Country
            SelectElement country = new SelectElement (Driver.driver.FindElement(By.Name("country")));
            country.SelectByText("Philippines");

            //Click on Title Dropdown
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select")).Click();

            //Choose a Title
            SelectElement title = new SelectElement(Driver.driver.FindElement(By.Name("title")));
            title.SelectByText("B.Sc");

            //Add Degree
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")).SendKeys("Information Technology");

            //Click on Year of Graduation Dropdown
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select")).Click();

            //Choose a Year
            SelectElement year = new SelectElement(Driver.driver.FindElement(By.Name("yearOfGraduation")));
            year.SelectByText("2015");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")).Click();


        }

        [Then(@"that educational background should be displayed on my listings")]
        public void ThenThatEducationalBackgroundShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a COllege or University Name");

                Thread.Sleep(1000);
                string ExpectedValue = "PUP";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a COllege or University Name Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationalBackgroundAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
