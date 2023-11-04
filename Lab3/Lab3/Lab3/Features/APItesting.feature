Feature: API testing

A short summary of the feature

@tag1
Scenario: GetBooking
	Given connect to db
	And create get request to booking/1
	When send request
	Then response is success
	And json that contains booking

Scenario: CreateBooking
	Given connect to db
	And create post request to booking
	And include json body that contains new booking
	When send request
	Then response is success
	And json that contains the same booking
