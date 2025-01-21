using System;
using EaAppAutomationTesting.Hooks;
using EaAppAutomationTesting.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace EaAppAutomationTesting.StepDefinitions
{
    [Binding]
    public class DisplayHomePageInfoStepDefinitions
    {
        private readonly HomePage homePage;

        public DisplayHomePageInfoStepDefinitions()
        {
            this.homePage = new HomePage(PlaywrightHooks.Driver.Page);
        }

        [Given(@"I scroll down to footer section")]
        public async Task GivenIScrollDown()
        {
            await homePage.scrollUntilFooterSection();
        }

        [When(@"I see the About section Title")]
        public async Task WhenISeeTheAboutSection()
        {
            await homePage.verifyTitleAboutSection("About");
        }

        [Then(@"I should see the following info of about section ""([^""]*)""")]
        public async Task ThenIShouldSeeTheFollowingInfoOfAboutSection(string p0)
        {
            await homePage.verifyInfoAboutSection(p0);
        }


        [When(@"I see the Courses Title")]
        public async Task WhenISeeTheCoursesTitle()
        {
            await homePage.verifyTitleCoursesSection("Courses");
        }

        [Then(@"I should see the following info of courses section ""([^""]*)""")]
        public async Task ThenIShouldSeeTheFollowingInfoOfCoursesSection(string p0)
        {
            await homePage.verifyInfoCoursesSection(p0);
        }

        [When(@"I see the Source Code Title")]
        public async Task WhenISeeTheSourceCodeTitle()
        {
            await homePage.verifySourceCodeSectionTitle("Source Code");
        }

        [Then(@"I should see the following info of source code section ""([^""]*)""")]
        public async Task ThenIShouldSeeTheFollowingInfoOfSourceCodeSection(string p0)
        {
            await homePage.verifyInfoSourceCodeSection(p0);
        }

    }
}
