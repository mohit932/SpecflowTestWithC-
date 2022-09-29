Feature: Liberis
Write an automated test framework for the following user journey using BDD scenarios


@mytag
Scenario: Demo Page Partner Selection Validation Message
	Given Log into liberis website - Using Chrome browser
	And Open ‘Get a Demo’ page
	When User does not make a partner selection and click ‘Get a demo’
	Then Verify the validation message
	Then  Close the Bowser


Scenario Outline: Select Partner Type
	Given Log into liberis website - Using Chrome browser
	And Open ‘Get a Demo’ page
	And Select type of partner <Type of Partner>
	When User does not make a partner selection and click ‘Get a demo’
	Then Verify application display broker-iso-form
	Then  Close the Bowser	
	
	Examples: 
	|Type of Partner|
	| "I'm an ISO"    |
	| "I'm a Broker"  |
	| "I'm a Strategic Partner"  |