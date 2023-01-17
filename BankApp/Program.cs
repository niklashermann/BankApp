using BankApp;

Console.WriteLine("Geben Sie bitte ihren Namen ein:");
string name = Console.ReadLine();


var account = new BankAccount($"{name}");
Console.WriteLine($"Account {account.Nummer} wurde erstellt für {account.Besitzer} mit dem Kontostand von {account.Kontostand}.");

account.Einzahlung(1000, DateTime.Now, "Du hast eingezahlt.");
//Console.WriteLine(account.Kontostand);
account.Auszahlung(500, DateTime.Now, "Steuern zahlen");
//Console.WriteLine(account.Kontostand);
account.Einzahlung(250, DateTime.Now, "Freund hat dir zurück gezahlt.");
//Console.WriteLine(account.Kontostand);
account.Einzahlung(1800, DateTime.Now, "Du hast einen Lohn bekommen.");
account.Auszahlung(500, DateTime.Now, "Steuern zahlen");
account.Auszahlung(300, DateTime.Now, "Du hast einen Freund zurück gezahlt.");
account.Auszahlung(500, DateTime.Now, "Steuern zahlen");
account.Einzahlung(1000, DateTime.Now, "Du hast eingezahlt.");

BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid");
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Ausnahme gefunden wärhend Account mit negativen Kontostand erstellt wird.");
    Console.WriteLine(e.ToString());
    return;
}
try
{
    account.Auszahlung(750, DateTime.Now, "Du hast ausgezahlt.");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Ausnahme gefunden wärhend versuchen zu überzeichnen.");
    Console.WriteLine(e.ToString());
}
Console.WriteLine(account.GetAccountHistory());