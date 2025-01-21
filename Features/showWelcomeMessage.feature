

Feature: Show Welcome Message
	As a user
	I want to see a welcome message,
	So that I know I have logged in successfully

Scenario Outline: Show Welcome Message to the registered user
	Given I navigate to application
	And I click login link
	And I enter following login details
		| UserName		| Password	 |
		|  <UserName>   | <Password> |
	When I press the Log In button
	Then I should see the following message "Hello <UserName>!"
Examples: 
	| UserName   | Password |
	| admin      | password |
	| juan perez | Juan.123 |



