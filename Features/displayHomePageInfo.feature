Feature: Display Home Page Info
	As a user,
	I want to view the homepage information
	So that I can quickly understand the website's purpose
	And key details

Background: 
	Given I navigate to application

Scenario: Display About Information
	Given I scroll down to footer section
	When I see the About section Title
	Then I should see the following info of about section "EA Employee App v3.0 is an ASP.NET MVC app and used by different automation testing courses hosted in both YouTube and Udemy"

Scenario: Display Courses Information
	Given I scroll down to footer section
	When I see the Courses Title
	Then I should see the following info of courses section "ExecuteAutomation courses are currently hosted in both YouTube and Udemy and this application is useful while learning automation for those courses"


Scenario: Display Source Code Information
	Given I scroll down to footer section
	When I see the Source Code Title
	Then I should see the following info of source code section "More than 30+ source code repositories are hosted in GitHub repo of ExecuteAutomation, you can download and try using them for automation, you can also download this application from the same repo"

