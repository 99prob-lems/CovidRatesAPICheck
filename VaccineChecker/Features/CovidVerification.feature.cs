﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CovidRatesAPICheck.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CovidDataAnalysisFeatureContaningScenariosThatEnableUsersToDecipherDataFromVariousContinentsOrCountriesFeature : object, Xunit.IClassFixture<CovidDataAnalysisFeatureContaningScenariosThatEnableUsersToDecipherDataFromVariousContinentsOrCountriesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CovidVerification.feature"
#line hidden
        
        public CovidDataAnalysisFeatureContaningScenariosThatEnableUsersToDecipherDataFromVariousContinentsOrCountriesFeature(CovidDataAnalysisFeatureContaningScenariosThatEnableUsersToDecipherDataFromVariousContinentsOrCountriesFeature.FixtureData fixtureData, CovidRatesAPICheck_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Covid data analysis feature, contaning scenarios that enable users to decipher da" +
                    "ta from various continents or countries", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line hidden
#line 5
 testRunner.Given("I am targeting baseurl \'https://covid-193.p.rapidapi.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Find 3 countries with the highest death in continent and historical data for date" +
            "s 2022-08-15")]
        [Xunit.TraitAttribute("FeatureTitle", "Covid data analysis feature, contaning scenarios that enable users to decipher da" +
            "ta from various continents or countries")]
        [Xunit.TraitAttribute("Description", "Find 3 countries with the highest death in continent and historical data for date" +
            "s 2022-08-15")]
        [Xunit.InlineDataAttribute("Europe", "2022-08-15", "3", new string[0])]
        [Xunit.InlineDataAttribute("Europe", "2022-08-16", "3", new string[0])]
        [Xunit.InlineDataAttribute("Europe", "2022-08-17", "3", new string[0])]
        [Xunit.InlineDataAttribute("North-America", "2022-08-17", "3", new string[0])]
        [Xunit.InlineDataAttribute("North-America", "2022-08-16", "3", new string[0])]
        [Xunit.InlineDataAttribute("North-America", "2022-08-15", "3", new string[0])]
        [Xunit.InlineDataAttribute("North-America", "2022-08-15", "6", new string[0])]
        public virtual void Find3CountriesWithTheHighestDeathInContinentAndHistoricalDataForDates2022_08_15(string continent, string dates, string countryCount, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Continent", continent);
            argumentsOfScenario.Add("Dates", dates);
            argumentsOfScenario.Add("countryCount", countryCount);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find 3 countries with the highest death in continent and historical data for date" +
                    "s 2022-08-15", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 9
 testRunner.When("When I submit a GET request to Endpoint \'/statistics\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.And("Response status code returns 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And(string.Format("I query the response body using \'$.response\' for continent \'{0}\'", continent), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.Then(string.Format("I am presented with top {0} countries with the highest death rate", countryCount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 13
 testRunner.And(string.Format("Im looking for covid historical data for dates \'{0}\' for those countries at endpo" +
                            "int \'/history\'", dates), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.Then("Im presented with new covid cases registered for those dates", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CovidDataAnalysisFeatureContaningScenariosThatEnableUsersToDecipherDataFromVariousContinentsOrCountriesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CovidDataAnalysisFeatureContaningScenariosThatEnableUsersToDecipherDataFromVariousContinentsOrCountriesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion