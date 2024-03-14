namespace VendingMachine;

public class Coin
{
    public int Parse(string coin)
    {
        return coin switch
        {
            "2E" => 200,
            "1E" => 100,
            "50C" => 50,
            "20C" => 20,
            "10C" => 10,
            _ => throw new FormatException("Invalid coin"),
        };
    }
}
