
/*
    Generate SQLite DB:
    > sqlite3 Northwind.db -init Northwind4Sqlite.sql
*/

ConfigureConsole();  // Sets US English by default.

// Filtering and sorting sequences.
FilterAndSort();

// Joining sequences.
JoinCategoriesAndProducts();

// Group-joining sequences.
GroupJoinCategoriesAndProducts();

// Grouping for lookups.
ProductsLookup();

// Aggregating.
AggregateProducts();

// Paging sequences.
PagingProducts();

// Extra: Generating XML using LINQ to XML.
OutputProductsAsXml();

// Extra: Reading XML using LINQ to XML.
ProcessSettings();

// Extra: Trying the chainable extension method.
FilterAndSortExtension();

// Extra: Trying the mode and median methods.
CustomExtensionMethods();

WriteLine();
