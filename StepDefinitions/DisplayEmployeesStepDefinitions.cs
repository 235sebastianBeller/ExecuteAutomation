using System;
using EaAppAutomationTesting.Pages;
using TechTalk.SpecFlow;
using EaAppAutomationTesting.Hooks;


namespace EaAppAutomationTesting.StepDefinitions
{
    [Binding]

    public class DisplayEmployeesStepDefinitions
    {
        private readonly EmployeeListPage employeesPage;

        public DisplayEmployeesStepDefinitions()
        {
            this.employeesPage = new EmployeeListPage(PlaywrightHooks.Driver.Page);

       }

        [When(@"I click on ""Employee List"" link")]
        public async Task WhenIClickOnLink()
        {
            await employeesPage.clickOnEmployeeListLink();
        }

        [Then(@"I should see the list of employees")]
        public async Task ThenIShouldSeeTheListOfEmployees()
        {

            await employeesPage.verifyEmployeeList(PlaywrightHooks.Employees);
            //throw new PendingStepException();
        }
    }
}
