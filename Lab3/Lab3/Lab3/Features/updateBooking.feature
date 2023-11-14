Feature: updateBooking

Scenario: Update Booking
	Given connect to https://restful-booker.herokuapp.com
	And create booking
	And create PUT request to booking/{id}
	And set parameter id
	And add header Accept with value application/json
	And add json with booking
	And add authorization token
	When send request
	Then response is Ok
	And response contains json with booking