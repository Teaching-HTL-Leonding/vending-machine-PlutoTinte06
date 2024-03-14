namespace VendingMachine;

public class CoinHandlingConsole
{
    public virtual void WriteLine(string s) => Console.Write(s);

    public virtual string ReadLine() => Console.ReadLine()!;

    public void HandleCoins()
    {

        var coin = new Coin();
        WriteLine($"Price: ");
        var priceInput = ReadLine();

        if (!double.TryParse(priceInput.Replace("E", ""), out double priceDouble))
        {
            return;
        }
        var price = (int)(priceDouble * 100);

        var changeCalculator = new ChangeCalculator(price);
        while (true)
        {
            WriteLine("Coin: ");
            var input = ReadLine();
            if (input == "q")
            {
                break;
            }
            try
            {
                changeCalculator.AddCoin(coin.Parse(input));
                WriteLine($"Total: {changeCalculator.TotalAmount / 100.0}E \n");
            }
            catch (FormatException)
            {
                WriteLine("Invalid coin \n");
            }
            catch (OverflowException)
            {
                WriteLine("Total amount is too high \n");
            }
            if (changeCalculator.IsEnoughMoney)
            {
                var change = changeCalculator.GetChange();
                WriteLine($"Change: {change / 100.0}E");
                break;
            }
        }
    }
}