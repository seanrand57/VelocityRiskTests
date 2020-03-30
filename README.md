HOW TO SET UP DATABASE AND PREFILL IT WITH TEST DATA:
There are two ways how to create the DB: with .bak file or just run migrations

1. Using .bak file

Restore db from backup file. Please, change the connection string in VelocityRisk.Persistence project VelocityRiskDbContext class 
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) method. 

Here you can see the string "Server=(localdb)\mssqllocaldb;Database=velocityRisk;Trusted_Connection=True;" on line 19
Pay attention to this part: (localdb)\mssqllocaldb. It should be your server name. 
Please, check your db location with this string. 

2. Using Migrations
Navigate to Package Manager Console.
Select "Default project" : VelocityRisk.Persistence.

Type "update-database" and press Enter

To populate the content of panels by initial data you should navigate to nunit.tests project, select VelocityRiskClaimsPageShould and uncomment line 25 with code: _claimsPage.PopulateDb();
This method will be run before tests and populates the expected content for Claims from UI.


HOW TO RUN TESTS:

To run tests please navigate to the Test Explorer window. In case you do not see it please select View -> Test Explorer. To 
There you can see two groups: mstest.tests and nunit.tests. 
It is possible to do right-click on the group and choose "Run" for starting tests for each group. 
Also, you can expand the group and see two tests in more detail. (Here you can do right-click on the chosen test and select "Run".)
Here you can see VelocityRiskClaimsPageShould class (PanelItemsAreCorrectTest test) for the second task 
and VelocityRiskMenuShould class (MenuItemsAreCorrectTest) for the first one.