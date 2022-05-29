using SportsStore.Entities;
using Xunit;

namespace SportsStore.Tests.Entities;

public class CartTests
{
    [Fact]
    public void Add_New_Lines()
    {
        // Arrange
        var p1 = new Product(1, "Baseball 3-Stripes CT Cap", "Adidas Performance 3S Cap Mens", 10.5m, "Baseball");
        var p2 = new Product(2, "Metal Swoosh Cap", "Nike Swoosh Cap", 13, "Baseball");

        var sut = new Cart();

        // Act
        sut.AddItem(p1, 1);
        sut.AddItem(p2, 1);

        // Assert
        Assert.Equal(2, sut.Lines.Count);
        Assert.Equal(p1, sut.Lines[0].Product);
        Assert.Equal(p2, sut.Lines[1].Product);
    }

    [Fact]
    public void Add_Quantity_for_Existing_Lines()
    {
        // Arrange
        var p1 = new Product(1, "Baseball 3-Stripes CT Cap", "Adidas Performance 3S Cap Mens", 10.5m, "Baseball");
        var p2 = new Product(2, "Metal Swoosh Cap", "Nike Swoosh Cap", 13, "Baseball");

        var sut = new Cart();

        // Act
        sut.AddItem(p1, 1);
        sut.AddItem(p2, 1);
        sut.AddItem(p1, 10);

        // Assert
        Assert.Equal(2, sut.Lines.Count);
        Assert.Equal(11, sut.Lines[0].Quantity);
        Assert.Equal(1, sut.Lines[1].Quantity);
    }

    [Fact]
    public void Remove_a_Line()
    {
        // Arrange
        var p1 = new Product(1, "Baseball 3-Stripes CT Cap", "Adidas Performance 3S Cap Mens", 10.5m, "Baseball");
        var p2 = new Product(2, "Metal Swoosh Cap", "Nike Swoosh Cap", 13, "Baseball");
        var p3 = new Product(3, "Blitzing Cap Mens", "Under Armour Blitzing Cap Mens", 14, "Baseball");

        var sut = new Cart();

        sut.AddItem(p1, 1);
        sut.AddItem(p2, 3);
        sut.AddItem(p3, 5);
        sut.AddItem(p2, 1);

        // Act
        sut.RemoveLine(p2);

        // Assert
        Assert.Equal(2, sut.Lines.Count);
        Assert.Empty(sut.Lines.Where(c => c.Product == p2));
    }

    [Fact]
    public void Calculate_Total()
    {
        // Arrange
        var p1 = new Product(1, "Baseball 3-Stripes CT Cap", "Adidas Performance 3S Cap Mens", 10.5m, "Baseball");
        var p2 = new Product(2, "Metal Swoosh Cap", "Nike Swoosh Cap", 13, "Baseball");

        var sut = new Cart();

        sut.AddItem(p1, 1);
        sut.AddItem(p2, 1);
        sut.AddItem(p1, 3);

        // Act
        var total = sut.TotalValue;

        // Assert
        Assert.Equal(55m, total);
    }

    [Fact]
    public void Clear_Contents()
    {
        // Arrange
        var p1 = new Product(1, "Baseball 3-Stripes CT Cap", "Adidas Performance 3S Cap Mens", 10.5m, "Baseball");
        var p2 = new Product(2, "Metal Swoosh Cap", "Nike Swoosh Cap", 13, "Baseball");

        var sut = new Cart();

        sut.AddItem(p1, 1);
        sut.AddItem(p2, 1);

        // Act
        sut.Clear();

        // Assert
        Assert.Empty(sut.Lines);
    }
}
