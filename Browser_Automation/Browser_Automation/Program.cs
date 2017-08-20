using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;


namespace Browser_Automation
{
    public class Program
    {
        private string email_usrname { get; set; }
        private string password;
            static Browser_Simulation sm; static Dictionary<Element, string> myDict;

        public enum Element
        {
            first,
            second,
            third,
            fourth,
            fifth, sixth, seventh, eigth, s,

        }

        Program(string email_usrname, string password,string first_element,string second_element, string third_element, string fourth_element,string fifth_element, string sixth_element,string seventh_element,string eigth_element) {
          this.email_usrname = email_usrname;
            this.password = password;
            myDict = new Dictionary<Element, string>()
            {
                [Element.first]= first_element  ,
                [Element.second]= second_element,
                [Element.third]= third_element,
                [Element.fourth]= fourth_element ,
                [Element.fifth]=fifth_element ,
                [Element.sixth]=sixth_element,
                [Element.seventh]=seventh_element ,
                [Element.eigth]=eigth_element,
            };
    sm = new Browser_Simulation(myDict[Element.sixth]);

}

       
        
        static void Main(string[] args)
        {
           var p= new Program("bhargavak37@gmail.com", "Eetcl90355", "lnkSignin", "ContentPlaceHolder1_txtUserNameEmail", "ContentPlaceHolder1_txtPassword", "ContentPlaceHolder1_btnLogin", "https://myhpgas.in/myHPGas/HPGas/LPGservices.aspx", "chrome", "chrome", "Ie");
            p.Task();
            sm.CleanUp();
            myDict.Clear();
        }
       
        private  void Task()
        {
            string url = myDict[Element.fifth];
            sm.Navigate(url);
            //Thread.Sleep(7);
            sm.getDriver().Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(10);//.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0.9));
           sm.Click_Element(sm.FindElement("Id", myDict[Element.first]));
            sm.getDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            sm.Send_Keys(sm.FindElement("Id", myDict[Element.second]), email_usrname);
           sm.Send_Keys(sm.FindElement("Id", myDict[Element.third]), password);
            sm.getDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); ;
            sm.Click_Element(sm.FindElement("Id", myDict[Element.fourth]));
        }
    }
}
