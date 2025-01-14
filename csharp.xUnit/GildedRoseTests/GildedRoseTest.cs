using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void NormalItem_QualityDecreasesByOne_BeforeSellByDate()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Normal Item", SellIn = 5, Quality = 10 } 
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(9, Items[0].Quality);
        Assert.Equal(4, Items[0].SellIn);
    }

    [Fact]
    public void NormalItem_QualityDecreasesByTwo_AfterSellByDate()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Normal Item", SellIn = 0, Quality = 10 } 
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(8, Items[0].Quality);
        Assert.Equal(-1, Items[0].SellIn);
    }

    [Fact]
    public void NormalItem_QualityNeverNegative()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Normal Item", SellIn = 5, Quality = 0 } 
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void NormalItem_QualityNeverAboveFifty()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Normal Item", SellIn = 5, Quality = 50 } 
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(49, Items[0].Quality);
    }

    [Fact]
    public void AgedBrie_QualityIncreasesByOne_BeforeSellByDate()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } 
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(11, Items[0].Quality);
        Assert.Equal(4, Items[0].SellIn);
    }

    [Fact]
    public void AgedBrie_QualityIncreasesByTwo_AfterSellByDate()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } 
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(12, Items[0].Quality);
        Assert.Equal(-1, Items[0].SellIn);
    }

    [Fact]
    public void AgedBrie_QualityNeverAboveFifty()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } 
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(50, Items[0].Quality);
    }
    
        [Fact]
    public void Sulfuras_NeverChanges()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 }
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(80, Items[0].Quality);
        Assert.Equal(5, Items[0].SellIn);
    }

    [Fact]
    public void BackstagePasses_QualityIncreasesByOne_WhenSellInGreaterThanTen()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 20 }
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(21, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_QualityIncreasesByTwo_WhenSellInTenOrLess()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 }
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(22, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_QualityIncreasesByThree_WhenSellInFiveOrLess()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 }
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(23, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_QualityDropsToZero_AfterConcert()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_QualityNeverExceedsFifty()
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 }
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(50, Items[0].Quality);
    }
    
    [Theory]
    [InlineData("Normal Item")]
    [InlineData("Aged Brie")]
    [InlineData("Backstage passes to a TAFKAL80ETC concert")]
    public void CommonRules_SellInDecreasesByOne_ExceptSulfuras(string itemName)
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = itemName, SellIn = 5, Quality = 10 }
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(4, Items[0].SellIn);
    }

    [Theory]
    [InlineData("Normal Item")]
    [InlineData("Aged Brie")]
    [InlineData("Backstage passes to a TAFKAL80ETC concert")]
    public void CommonRules_QualityNeverNegative(string itemName)
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = itemName, SellIn = 0, Quality = 0 }
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.True(Items[0].Quality >= 0);
    }

    [Theory]
    [InlineData("Normal Item")]
    [InlineData("Aged Brie")]
    [InlineData("Backstage passes to a TAFKAL80ETC concert")]
    public void CommonRules_QualityNeverMoreThanFifty_ExceptSulfuras(string itemName)
    {
        IList<Item> Items = new List<Item> 
        { 
            new Item { Name = itemName, SellIn = 5, Quality = 50 }
        };
        var app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.True(Items[0].Quality <= 50);
    }
}