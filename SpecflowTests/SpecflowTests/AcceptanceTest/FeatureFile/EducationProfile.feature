Feature: Education Profile Feature
	In order to update my profile 
	As a skill trader
	I want to add my Educational Background

@mytag
Scenario: Check if user could able to add an educational background
	Given I clicked on the Education tab under Profile page
	When I add a new educational background
	Then that educational background should be displayed on my listings
