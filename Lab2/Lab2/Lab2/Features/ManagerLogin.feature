Feature: manager login

A short summary of the feature

@tag1
Scenario: Login as a manager
	Given open Login page
	When press Bank Manager Login button
	Then the result should be page that contains buttons: Open Account, Add Customer, Customers
