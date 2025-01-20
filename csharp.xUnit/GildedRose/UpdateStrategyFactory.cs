namespace GildedRoseKata;

public static class UpdateStrategyFactory
{
    public static IUpdateStrategy GetStrategy(Item item)
    {
        return item.Name switch
        {
            ItemNames.AgedBrie => new AgedBrieUpdateStrategy(),
            ItemNames.BackstagePass => new BackstagePassUpdateStrategy(),
            ItemNames.Sulfuras => new SulfurasUpdateStrategy(),
            _ => new StandardItemUpdateStrategy()
        };
    }
}

public static class ItemNames
{
    public const string AgedBrie = "Aged Brie";
    public const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
    public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
}