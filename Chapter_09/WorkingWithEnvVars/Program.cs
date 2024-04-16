/*
    https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/setx

    Environment variable:
    https://ss64.com/bash/export.html
*/

SectionTitle("Reading all environment variables for process");
IDictionary vars = GetEnvironmentVariables();
DictionaryToTable(vars);

SectionTitle("Reading all environment variables for machine");
IDictionary varsMachine = GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
DictionaryToTable(varsMachine);

SectionTitle("Reading all environment variables for user");
IDictionary varsUser = GetEnvironmentVariables(EnvironmentVariableTarget.User);
DictionaryToTable(varsUser);
WriteLine();

// Setting in various ways, and getting environment variables:
string myComputer = "My username is %USERNAME%. My CPU is %PROCESSOR_IDENTIFIER%.";
WriteLine(ExpandEnvironmentVariables(myComputer));
WriteLine();

string password_key = "MY_PASSWORD";
SetEnvironmentVariable(password_key, "Pa$$w0rd");
string? password = GetEnvironmentVariable(password_key);
WriteLine($"{password_key}: {password}");
WriteLine();

string secret_key = "MY_SECRET";
string? secret = GetEnvironmentVariable(secret_key, EnvironmentVariableTarget.Process);
WriteLine($"Process - {secret_key}: {secret}");

secret = GetEnvironmentVariable(secret_key, EnvironmentVariableTarget.Machine);
WriteLine($"Machine - {secret_key}: {secret}");

secret = GetEnvironmentVariable(secret_key, EnvironmentVariableTarget.User);
WriteLine($"User - {secret_key}: {secret}");
WriteLine();
