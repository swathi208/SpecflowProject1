using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    internal class OpeningApplication
    {
        public IWebDriver driver=new ChromeDriver();
      
        [Given(@"open application")]
        public void GivenOpenApplication()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://www.amazon.in/ap/signin?openid.pape.max_auth_age=900&openid.return_to=https%3A%2F%2Fwww.amazon.in%2Fgp%2Fhomepage.html%3F_encoding%3DUTF8%26ref_%3Dnavm_em_signin%26action%3Dsign-out%26path%3D%252Fgp%252Fhomepage.html%253F_encoding%253DUTF8%2526ref_%253Dnavm_em_signin%26signIn%3D1%26useRedirectOnSuccess%3D1%26ref_%3Dnav_em_signout_0_1_1_41&openid.assoc_handle=inflex&openid.mode=checkid_setup&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0");
            driver.Navigate().Refresh();
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[id='continue']")));
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait=(TimeSpan.FromSeconds(10));
            string width = driver.Manage().Window.Size.Width.ToString();
            string height = driver.Manage().Window.Size.Height.ToString();
            Console.WriteLine("width and height are "+width +" " + height);
            Thread.Sleep(5000);
            string title=driver.Title;
            Console.WriteLine(title);
        }
        public IWebElement element;
        string mail1 = "karlapudiswathi8@gmail.com";
        [Given(@"Enter login details")]
        public void GivenEnterLoginDetails()
        {
            element = driver.FindElement(By.CssSelector("[id='ap_email']"));
            //element = driver.FindElement(By.CssSelector("input[id='ap_email']"));
            //element = driver.FindElement(By.Id("ap_email"));
          
            element.SendKeys(mail1);
            element=driver.FindElement(By.CssSelector("input[type='submit']"));
            element.Click();
            Console.WriteLine("entered mailid");
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(50);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //element = driver.FindElement(By.CssSelector("[id='ap_email']"));
            element = fluentwait.Until(driver =>driver.FindElement(By.CssSelector("[id='ap_email']")));
            element.Click();
            driver.Close();
            //Swathi@02*09
            //
        }

    }
}
