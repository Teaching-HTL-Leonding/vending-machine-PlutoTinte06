namespace VendingMachine;

public class ChangeCalculator(int price)
{
    public int Price { get; set; } = price;
    public int TotalAmount { get; private set; }
    public bool IsEnoughMoney => TotalAmount >= Price;

    public int AddCoin(int price)
    {
        return checked(TotalAmount += price);
    }

    public int GetChange()
    {
        if (!IsEnoughMoney)
        {
            throw new InvalidOperationException("Not enough money");
        }

        var change = TotalAmount - Price;
        TotalAmount = 0;
        return change;
    }
}