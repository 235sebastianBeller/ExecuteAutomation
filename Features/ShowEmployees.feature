@Employees
Feature: Display Employees
	As a user
	I want to see all the employees
	So that I can meet my colleagues

Scenario: Display the List of Registered Employees
	Given I navigate to application
	When I click on "Employee List" link
	Then I should see the list of employees


Scenario Outline: Display the List of Matches for the Employee
	Given I navigate to application
	When I click on "Employee List" link
	And I search the list of matches for "<Employee>"
	Then I should see the list of employees that matches for "<Employee>"
Examples: 
	| Employee |
	| John     |
	| Karthik  |
	| Veronica |
			