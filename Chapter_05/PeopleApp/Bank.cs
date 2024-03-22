using Packt.Shared;

public class Bank
{
    public Bank()
    {
        BankAccount.InterestRate = 0.012M; // Store a shared value in static field.
        
        BankAccount jonesAccount = new();
        jonesAccount.AccountName = "Mrs. Jones"; 
        jonesAccount.Balance = 2400;
        WriteLine(format: "{0} earned {1:C} interest.",
                    arg0: jonesAccount.AccountName,
                    arg1: jonesAccount.Balance * BankAccount.InterestRate);

        BankAccount gerrierAccount = new(); 
        gerrierAccount.AccountName = "Ms. Gerrier"; 
        gerrierAccount.Balance = 98;
        WriteLine(format: "{0} earned {1:C} interest.",
                    arg0: gerrierAccount.AccountName,
                    arg1: gerrierAccount.Balance * BankAccount.InterestRate);
    }
}