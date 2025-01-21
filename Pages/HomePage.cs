using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace EaAppAutomationTesting.Pages
{
    public class HomePage
    {
        private IPage page;

        public HomePage(IPage page)
        {
            this.page = page;
        }

        private ILocator logoutButton() => page.Locator("text='Log off'");
        private ILocator loginInputNav() => page.Locator("text=Login");

        private ILocator footerSection() => page.Locator("footer");

        private ILocator signUpInputNav() => page.Locator("text=Register");

        private ILocator aboutSectionTitle() => page.Locator("//html//body//div[2]//div[2]//div[1]//h2");

        private ILocator aboutSectionInfo() => page.Locator("//html//body//div[2]//div[2]//div[1]//p[1]");

        private ILocator coursesSectionTitle() => page.Locator("//html//body//div[2]//div[2]//div[2]//h2");

        private ILocator coursesSectionInfo() => page.Locator("//html//body//div[2]//div[2]//div[2]//p[1]");

        private ILocator sourceCodeSectionTitle() => page.Locator("//html//body//div[2]//div[2]//div[3]//h2");

        private ILocator sourceCodeSectionInfo() => page.Locator("//html//body//div[2]//div[2]//div[3]//p[1]");

        public async Task clickLogInInputNav()
        {
            var response = await page.RunAndWaitForResponseAsync(async () =>
            {
                await this.loginInputNav().ClickAsync();
            }, x => x.Status == 200 && x.Request.Method == "GET"); // verificamos que el status sea 200, la repuesta
            await page.WaitForURLAsync("**/Account/Login");// vemos la url del navegador
        }


        public async Task clickLogOutButton()
        {
            await this.logoutButton().ClickAsync();
        }

        public async Task scrollUntilFooterSection()
        {
            await footerSection().ScrollIntoViewIfNeededAsync();
        }

        public async Task verifySignUpInput()
        {
            await signUpInputNav().IsVisibleAsync();
        }

        public async Task verifyTitleAboutSection(string text)
        {
            await aboutSectionTitle().IsVisibleAsync();
            Assert.AreEqual(await aboutSectionTitle().InnerHTMLAsync(),text);
        }

        public async Task verifyInfoAboutSection(string text)
        {
            await aboutSectionInfo().IsVisibleAsync();
            string actualText = await aboutSectionInfo().InnerHTMLAsync();
            Assert.IsTrue(actualText.Contains(text));
        }

        public async Task verifyTitleCoursesSection(string text)
        {
            await coursesSectionTitle().IsVisibleAsync();
            Assert.AreEqual(await coursesSectionTitle().InnerHTMLAsync(), text);
        }

        public async Task verifyInfoCoursesSection(string text)
        {
            await coursesSectionInfo().IsVisibleAsync();
            string actualText = await coursesSectionInfo().InnerHTMLAsync();
            Assert.IsTrue(actualText.Contains(text));
        }

        public async Task verifySourceCodeSectionTitle(string text)
        {
            await sourceCodeSectionTitle().IsVisibleAsync();
            Assert.AreEqual(await sourceCodeSectionTitle().InnerHTMLAsync(), text);
        }

        public async Task verifyInfoSourceCodeSection(string text)
        {
            await sourceCodeSectionInfo().IsVisibleAsync();
            string actualText = await sourceCodeSectionInfo().InnerHTMLAsync();
            Assert.IsTrue(actualText.Contains(text));
        }

    }
}
