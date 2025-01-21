Feature: Log Out
	As a logged-in user,
	I want to log out from the website
	So that my session ends successfully.

Background: 
	Given I navigate to application
	And I click login link


Scenario Outline: Log out from the website
	Given I enter following login details
		| UserName		| Password	 |
		|  <UserName>   | <Password> |
	And I press the Log In button
	When I press the Log out button
	Then I should see the Register button
	Examples: 
	| UserName   | Password |
	| admin      | password |
	| juan perez | Juan.123 |

