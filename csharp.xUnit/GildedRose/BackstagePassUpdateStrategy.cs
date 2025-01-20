namespace GildedRoseKata;

public class BackstagePassUpdateStrategy : IUpdateStrategy
{
    public void Update(Item item)
    {
        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            item.Quality = 0;
            return;
        }

        IncreaseQuality(item);

        if (item.SellIn < 10) IncreaseQuality(item);
        if (item.SellIn < 5) IncreaseQuality(item);
    }

    private static void DecreaseSellIn(Item item) => item.SellIn--;
    private static void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
            item.Quality++;
    }
}