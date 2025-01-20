namespace GildedRoseKata;

public class SulfurasUpdateStrategy : IUpdateStrategy
{
    // "Sulfuras" never changes in Quality or SellIn
    public void Update(Item item)
    {
        // No update needed, so we do nothing here
    }
}
