using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit;

namespace CovidRatesAPICheck.StepDefinitions
{
    [Binding]
    public class StepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        public RestClient client;
        public RestResponse response;
        public RestRequest request;
        public bool historicalFlag = false;

        public StepDefinition(ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper = specFlowOutputHelper;

        }

        [StepDefinition(@"I am targeting baseurl '([^']*)'")]
        public void GivenIAmTargetingBaseurl(string url)
        {
            client = new RestClient(url);
        }


        [StepDefinition(@"When I submit a GET request to Endpoint '([^']*)'")]
        public void WhenWhenISubmitAGETRequestToEndpoint(string endpoint)
        {
            if (historicalFlag)
            {
                var continent = (string)_scenarioContext["continent"];
                var day = (string)_scenarioContext["day"];

                request = new RestRequest(endpoint, Method.Get);
                request.AddQueryParameter("country", continent);
                request.AddQueryParameter("day", day);

                // can be stored in config file for scalability
                request.AddHeader("X-RapidAPI-Key", "cd8fb14be8msh975472a18e59e89p1f9510jsn8cbb2adcbc4a");
                request.AddHeader("X-RapidAPI-Host", "covid-193.p.rapidapi.com");
                historicalFlag = false; // reset flag
            }
            else
            {
                request = new RestRequest(endpoint, Method.Get);

                request.AddHeader("X-RapidAPI-Key", "cd8fb14be8msh975472a18e59e89p1f9510jsn8cbb2adcbc4a");
                request.AddHeader("X-RapidAPI-Host", "covid-193.p.rapidapi.com");

            }
            response = client.ExecuteGet(request);

        }

        [StepDefinition(@"Response status code returns (.*)")]
        public void WhenResponseStatusCodeReturns(int ExpectedCode)
        {
            var statusCode = (int)response.StatusCode;
            Assert.True(statusCode.Equals(ExpectedCode));

            _specFlowOutputHelper.WriteLine(statusCode.ToString());
        }


        [StepDefinition(@"response JSON should contain field '([^']*)' with value '([^']*)'")]
        public void ThenResponseJSONShouldContainFieldWithValue(string field, string value)
        {
            var jo = JObject.Parse(response.Content);
            var result = jo.SelectToken(field).ToString();
            Assert.True(result.Equals(value));

        }


        [StepDefinition(@"I query the response body using '([^']*)' for continent '([^']*)'")]
        public void WhenIQueryTheResponseBodyUsingForContinent(string query, string continent)
        {
            _scenarioContext["continent"] = continent; // store continent for later use

            var jo = JObject.Parse(response.Content).SelectToken(query);

            // Simple use of linq to extract data from the json file, for scalability could Model the response to objects but this is does the trick for now
            var Countries =
                from item in jo
                where (string)item["continent"] == continent
                orderby item["cases"]["total"] descending
                select item["country"].ToObject<string>();

            var newCountries = Countries.ToList();
            newCountries.RemoveAll(country => country == continent); // remove continent from list

            // store the data to share later
            _scenarioContext["newCountries"] = newCountries.ToArray();

        }

        [StepDefinition(@"I am presented with top (.*) countries with the highest death rate")]
        public void ThenIAmPresentedWithTopCountriesWithTheHighestDeathRateInEurope(int topCount)
        {
            string[] newCountries = (string[])_scenarioContext["newCountries"];

            var top = newCountries.Take(topCount).ToArray();

            Assert.True(top.Length.Equals(topCount));

            foreach (var country in top)
            {
                // print out top country deaths in specific continent
                _specFlowOutputHelper.WriteLine(country);

            }

            _scenarioContext["filteredCountries"] = top; // store for later use

        }

        [StepDefinition(@"Im looking for covid historical data for dates '([^']*)' for those countries at endpoint '([^']*)'")]
        public void ThenImLookingForCovidHistoricalDataForDates(string date, string endpoint)
        {
            var countriesList = (string[])_scenarioContext["filteredCountries"]; // shared

            List<string> historicalReportNewCases = new(); // store new values to share
            _scenarioContext["Report"] = historicalReportNewCases;

            foreach (var country in countriesList.ToArray())
            {
                request = new RestRequest(endpoint, Method.Get);
                request.AddHeader("X-RapidAPI-Key", "cd8fb14be8msh975472a18e59e89p1f9510jsn8cbb2adcbc4a");
                request.AddHeader("X-RapidAPI-Host", "covid-193.p.rapidapi.com");
                request.AddQueryParameter("day", date);
                _specFlowOutputHelper.WriteLine(country);
                response = client.ExecuteGet(request.AddQueryParameter("country", country));

                var jo = JObject.Parse(response.Content);
                var newCovid = jo.SelectToken("response[0].cases.new").ToString();
                if (newCovid == "" || newCovid == null) newCovid = "[No Data]";
                historicalReportNewCases.Add($"For dates {date}, {country} had {newCovid} new registered cases");
            }

        }

        [Then(@"Im presented with new covid cases registered for those dates")]
        public void ThenIPresentedWithNewCovidCasesRegisteredForThoseDates()
        {
            var reports = (List<string>)_scenarioContext["Report"];

            foreach (var report in reports)
            {
                // print out top country deaths in specific continent
                _specFlowOutputHelper.WriteLine(report);

            }
        }

    }
}
