# CovidRatesAPICheck

CovidRatesAPICheck is a c# framework that analyses backend covid data from various api services. 

## Requirements
- Visual Studio (Not code)
- Install Specflow extension in Visual studio (locally)
- Restore NuGet packages
- Clean
- Build

## Running locally
- After building, Test explorer will populate with available tests
- Select Test you would like to execute and click run

## Test results
- Monitor the console output for data
- Data requested in Specflow files will output in the console using _specFlowOutputHelper.WriteLine function

## Test Configuration

Tests are implemented using Specflow (BDD) which enables the re-use of steps and enables users to understand what's being tested and the expected outcomes.
- Navigate to the Features folder and locate CovidAnalysis.feature file
- You can modify some of the parameters within the feature file, ensuring you understand how the API you are targeting works.
