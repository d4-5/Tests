Feature: open account

Scenario: Open account for a customer
	Given open Manager page
	When click Open Account
	And chose customer name: Hermoine Granger
	And chose currency: Dollar 
	And click Process
	Then the result should be an alert that contains Account created successfully with account Number :

Scenario: Try to open account for a customer without setting up value of field Customer Name
	Given open Manager page
	When click Open Account
	And chose currency: Dollar 
	And click Process
	Then the result should be no alert

Scenario: Try to open account for a customer without setting up value of field Currency
	Given open Manager page
	When click Open Account
	And chose customer name: Hermoine Granger
	And click Process
	Then the result should be no alert