Feature: Covid data analysis feature, contaning scenarios that enable users to decipher data from various continents or countries


Background:
	Given I am targeting baseurl 'https://covid-193.p.rapidapi.com'

	
Scenario Outline: Find 3 countries with the highest death in continent and historical data for dates 2022-08-15
	When When I submit a GET request to Endpoint '/statistics'
	And Response status code returns 200
	And I query the response body using '$.response' for continent '<Continent>'
	Then I am presented with top <countryCount> countries with the highest death rate
	And Im looking for covid historical data for dates '<Dates>' for those countries at endpoint '/history'
	Then Im presented with new covid cases registered for those dates
Examples:
	| Continent     | Dates      | countryCount |
	| Europe        | 2022-08-15 | 3            |
	| Europe        | 2022-08-16 | 3            |
	| Europe        | 2022-08-17 | 3            |
	| North-America | 2022-08-17 | 3            |
	| North-America | 2022-08-16 | 3            |
	| North-America | 2022-08-15 | 3            |
	| North-America | 2022-08-15 | 6            |