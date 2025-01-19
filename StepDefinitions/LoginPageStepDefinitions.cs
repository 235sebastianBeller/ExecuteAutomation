using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
//using playwrigthSpecFlowProject.Drivers;
using EaAppAutomationTesting.Pages;
using TechTalk.SpecFlow.NUnit;
using TechTalk.SpecFlow.Assist;
using EaAppAutomationTesting.Hooks;


namespace playwrigthSpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginPageStepDefinitions
    {
        private readonly LoginPage loginPage;

        public LoginPageStepDefinitions()
        {
            loginPage = new LoginPage(PlaywrightHooks.Driver.Page);
        }

        [Given(@"I navigate to application")]
        public async Task GivenINavigateToApplication()
        {
            await PlaywrightHooks.Driver.Page.GotoAsync("http://eaapp.somee.com");
        }

        [Given(@"I click login link")]
        public async Task GivenIClickLoginLink()
        {
            await loginPage.clickLogInInputNav();
        }

        [Given(@"I enter following login details")]
        public async Task GivenIEnterFollowingLoginDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance(); // para usar esto debemos instalar el plugin SpecFlow.Assist.Dynamic
            await loginPage.fillUserName(data.UserName);
            await loginPage.fillPassword(data.Password);


        }

        [When(@"I press the ""([^""]*)"" button")]
        public async Task WhenIPressTheButton(string p0)
        {
            await loginPage.clickLogInButton();
        }

        [Then(@"I should see the following message ""([^""]*)""")]
        public async Task ThenISeeEmployeeLists(string message)
        {
            await loginPage.verifyWelcomeMessage(message);
        }
    }
}
