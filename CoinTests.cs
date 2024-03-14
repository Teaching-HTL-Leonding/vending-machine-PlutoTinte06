namespace VendingMachine.Tests;

public class CoinTests
{
    [Fact]
    public void Coin_WhenValidInput_ShouldParseToCent()
    {
        // Arrange, Act
        var coin = new Coin();

        // Assert
        Assert.Equal(200, coin.Parse("2E"));
        Assert.Equal(100, coin.Parse("1E"));
        Assert.Equal(50, coin.Parse("50C"));
        Assert.Equal(20, coin.Parse("20C"));
        Assert.Equal(10, coin.Parse("10C"));
    }

    [Fact]
    public void Coin_WhenInvalidInput_ThrowsFormatException()
    {
        // Arrange, Act
        var coin = new Coin();

        // Assert
        Assert.Throws<FormatException>(() => coin.Parse("3E"));
        Assert.Throws<FormatException>(() => coin.Parse("1D"));
        Assert.Throws<FormatException>(() => coin.Parse("50"));
        Assert.Throws<FormatException>(() => coin.Parse("20Cents"));
    }
}