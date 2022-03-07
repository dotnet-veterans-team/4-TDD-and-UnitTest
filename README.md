# TDD-and-Unit-Test

#####1. Install Coverlet 
PM> Install-Package coverlet.msbuild -Version 2.7.0

#####2. First run
dotnet test CoverletSample.Test /p:CollectCoverage=true

#####3. ReportGenerator
Install-Package ReportGenerator

#####4. Global Version
dotnet tool install --global dotnet-reportgenerator-globaltool --version 4.3.1

#####5. Generate report for actual tests
reportgenerator "-reports:.coverage/Data.opencover.xml" "-targetdir:.coverage-report" -reporttypes:HTML;
