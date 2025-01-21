using System;
using EaAppAutomationTesting.Hooks;
using EaAppAutomationTesting.Pages;
using TechTalk.SpecFlow;

namespace EaAppAutomationTesting.StepDefinitions
{
    [Binding]
    public class LogOutStepDefinitions
    {
        private readonly HomePage homePage;

        public LogOutStepDefinitions()
        {
            this.homePage = new HomePage(PlaywrightHooks.Driver.Page);
        }


        [When(@"I press the Log out button")]
        public async Task WhenIPressTheLogOutButton()
        {
            await homePage.clickLogOutButton();
        }

        [Then(@"I should see the Register button")]
        public async Task ThenIShouldSeeTheRegisterButton()
        {
            await homePage.verifySignUpInput();
        }
    }
}
