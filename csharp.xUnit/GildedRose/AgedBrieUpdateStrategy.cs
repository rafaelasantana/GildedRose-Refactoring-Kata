namespace GildedRoseKata;

public class AgedBrieUpdateStrategy : IUpdateStrategy
{
    public void Update(Item item)
    {
        DecreaseSellIn(item);

        IncreaseQuality(item);

        if (item.SellIn < 0)
        {
            IncreaseQuality(item);
        }
    }

    private static void DecreaseSellIn(Item item) => item.SellIn--;
    private static void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
            item.Quality++;
    }
}