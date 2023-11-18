# ExcelTest
NET7 api project in hexagonal architecture with dappper and GraphQL, using MYSQL & Code-First with EF.
To create the database, take into account the following commands:
  add-migration InitialCreate -p ExcelTest.EFC.DataContexts -s ExcelTest.EFC.DataContexts -c MigrationContext -o Migrations
  remove-migration -p ExcelTest.EFC.DataContexts -s ExcelTest.EFC.DataContexts -context MigrationContext
  update-database -p ExcelTest.EFC.DataContexts -s ExcelTest.EFC.DataContexts -context MigrationContext
  script-migration -p ExcelTest.EFC.DataContexts -s ExcelTest.EFC.DataContexts -context MigrationContext
