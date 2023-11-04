Feature: open account

A short summary of the feature

@tag1
Scenario: Open account for a customer
	Given open Manager page
	When click Open Account, chose customer name: Hermoine Granger, currency: Dollar and click Process
	Then the result should be an alert that contains Account created successfully with account Number :