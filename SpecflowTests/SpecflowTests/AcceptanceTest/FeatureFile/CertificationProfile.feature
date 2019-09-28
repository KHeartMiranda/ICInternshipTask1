Feature: Certification Profile Feature
	In order to update my profile 
	As a skill trader
	I want to add my Certifications

@mytag
Scenario: Check if user could able to add a certification
	Given I clicked on the Certifications tab under Profile page
	When I add a certification
	Then that certification should be displayed on my listings
