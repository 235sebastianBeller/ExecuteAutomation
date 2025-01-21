using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace EaAppAutomationTesting.Pages
{

    public class LoginPage
    {
        private IPage page;



        private ILocator txtUserName() => page.Locator("#UserName");
        private ILocator txtPassword() => page.Locator("#Password");

        private ILocator txtWelcomeMessage() => page.Locator("a[title='Manage']");

        private ILocator loginButton() => page.Locator("text='Log in'");
      


        public async Task fillUserName(string username)
            => await this.txtUserName().FillAsync(username);

        public async Task fillPassword(string password)
            => await this.txtPassword().FillAsync(password);

    

        public async Task clickLogInButton()
        {
            await this.loginButton().ClickAsync();
            await page.WaitForURLAsync("http://eaapp.somee.com/");

        }


        public async Task login(string username, string password)
        {
            await this.fillUserName(username);
            await this.fillPassword(password);
            await this.clickLogInButton();
        }

        public async Task verifyWelcomeMessage(string message)
         {
            await this.txtWelcomeMessage().IsVisibleAsync();
            Assert.AreEqual(await this.txtWelcomeMessage().InnerHTMLAsync(), message);
        }


        public LoginPage(IPage page)
        {
            this.page = page;
        }
    }
}
