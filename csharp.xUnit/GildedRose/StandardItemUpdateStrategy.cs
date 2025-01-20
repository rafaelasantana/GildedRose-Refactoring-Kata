namespace GildedRoseKata;

public class StandardItemUpdateStrategy : IUpdateStrategy
{
    public void Update(Item item)
    {
        DecreaseSellIn(item);

        DecreaseQuality(item);

        if (item.SellIn < 0)
        {
            DecreaseQuality(item);
        }
    }

    private static void DecreaseSellIn(Item item) => item.SellIn--;
    private static void DecreaseQuality(Item item)
    {
        if (item.Quality > 0)
            item.Quality--;
    }
}