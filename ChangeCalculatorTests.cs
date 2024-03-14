namespace VendingMachine.Tests;

public class ChangeCalculatorsTests
{
    [Fact]
    public void TotalAmountIsInitiallyZero()
    {
        // Arrange, Act
        var changeCalculator = new ChangeCalculator(100);

        // Assert
        Assert.Equal(0, changeCalculator.TotalAmount);
    }

    [Fact]
    public void AddCoin_WhenCalledWithValidInput_ShouldAddToSum()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);

        // Act
        changeCalculator.AddCoin(100);

        // Assert
        Assert.Equal(100, changeCalculator.TotalAmount);
    }

    [Fact]
    public void AddCoin_ThrowsOverflowException_WhenSumExceedsMaxValue()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);

        // Act
        changeCalculator.AddCoin(int.MaxValue);

        // Assert
        Assert.Throws<OverflowException>(() => changeCalculator.AddCoin(1));
    }

    [Fact]
    public void IsEnoughMoney_ReturnsTrue_WhenTotalAmountIsEqualOrGreaterToPrice()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);
        changeCalculator.AddCoin(100);

        // Act
        var result = changeCalculator.IsEnoughMoney;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEnoughMoney_ReturnsFalse_WhenTotalAmountIsLessThanPrice()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);

        // Act
        var result = changeCalculator.IsEnoughMoney;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetChange_ReturnsCorrectChange()
    {
        // Arrange
        var changeCalculator = new ChangeCalculator(100);
        changeCalculator.AddCoin(100);

        // Act
        var result = changeCalculator.GetChange();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetChange_ThrowsInvalidOperationException_WhenTotalAmountIsLessThanPrice()
    {
        // Arrange, Act
        var changeCalculator = new ChangeCalculator(100);

        // Assert
        Assert.Throws<InvalidOperationException>(() => changeCalculator.GetChange());
    }

    [Fact]
    public void UserEntersValidCoins_ReachesProductPriceExactly_Gets_No_Change()
    {
        // Arrange
        var chcm = new CoinHandlingConsoleMock(["1E", "1E"]);

        // Act
        chcm.HandleCoins();

        // Assert
        Assert.Equal([
           "Price: ",
            "Coin: ",
            "Total: 1E \n",
            "Change: 0E",
        ], chcm.Outputs);
    }

    [Fact]
    public void UserEntersValidCoins_TotalAmountExceedsProductPrice_GetsChange()
    {
        // Arrange
        var chcm = new CoinHandlingConsoleMock(["1E", "2E"]);

        // Act
        chcm.HandleCoins();

        // Assert
        Assert.Equal([
            "Price: ",
            "Coin: ",
            "Total: 2E \n",
            "Change: 1E",
        ], chcm.Outputs);
    }

    [Fact]
    public void UserEntersInvalidCoin()
    {
        // Arrange
        var chcm = new CoinHandlingConsoleMock(["1E", "10E", "1E"]);

        // Act
        chcm.HandleCoins();

        // Assert
        Assert.Equal([
            "Price: ",
            "Coin: ",
            "Invalid coin \n",
            "Coin: ",
            "Total: 1E \n",
            "Change: 0E",
        ], chcm.Outputs);
    }
}
