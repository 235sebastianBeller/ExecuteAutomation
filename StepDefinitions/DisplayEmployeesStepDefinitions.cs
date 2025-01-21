using System;
using EaAppAutomationTesting.Pages;
using TechTalk.SpecFlow;
using EaAppAutomationTesting.Hooks;
using TechTalk.SpecFlow.Assist;
using ServiceStack;


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
        }

        [When(@"I search the list of matches for ""([^""]*)""")]
        public async Task WhenISearchTheListOfMatchesFor(string name)
        {
            await employeesPage.fillSearchField(name);
            await employeesPage.clickSearchButton();
        }

        [Then(@"I should see the list of employees that matches for ""([^""]*)""")]
        public async Task ThenIShouldSeeTheListOfEmployeesThatMatchesFor(string name)
        {
            //throw new PendingStepException();
            await employeesPage.verifyEmployeeList(PlaywrightHooks.Employees.FindAll(e=>e.Name.StartsWith(name)));
        }




    }
}
