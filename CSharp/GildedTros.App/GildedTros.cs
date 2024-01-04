using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items;
        public static readonly IList<String> NormalItems = new ReadOnlyCollection<string>(
            new List<String> { "Ring of Cleansening Code", "Elixir of the SOLID" });
        public static readonly IList<String> SmellyItems = new ReadOnlyCollection<string>(
            new List<String> { "Duplicate Code", "Long Methods", "Ugly Variable Names" });
        public static readonly IList<String> BackstagePasses = new ReadOnlyCollection<string>(
            new List<String> { "Backstage passes for Re:factor", "Backstage passes for HAXX" });
        public const string GoodWine = "Good Wine";
        public const string BDawgKeyChain = "B-DAWG Keychain";

        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Good Wine" 
                    && Items[i].Name != "Backstage passes for Re:factor"
                    && Items[i].Name != "Backstage passes for HAXX")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "B-DAWG Keychain")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes for Re:factor"
                        || Items[i].Name == "Backstage passes for HAXX")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "B-DAWG Keychain")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Good Wine")
                    {
                        if (Items[i].Name != "Backstage passes for Re:factor"
                            && Items[i].Name != "Backstage passes for HAXX")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "B-DAWG Keychain")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        public static void UpdateNormalItem(Item item)
        {
            item.Quality = item.Quality > 0? item.Quality-- : 0;
            item.SellIn--;
        }

        public static void UpdateGoodWine(Item item)
        {
            const int maxQuality = 50;
            item.Quality = item.SellIn > 0 ? Math.Min(item.Quality ++ , maxQuality) : Math.Min(item.Quality + 2, maxQuality); ;
            item.SellIn--;
        }

        public static void UpdateSmellyItems(Item item)
        {
            const int minQuality = 0;
            item.Quality = item.SellIn > 0 ? Math.Max(item.Quality - 2, minQuality) : Math.Max(item.Quality - 4, minQuality);
            item.SellIn--;
        }

        public static void UpdateBackStagePasses(Item item)
        {
            const int maxQuality = 50;

            if (item.SellIn > 10)
            {
                item.Quality = Math.Min(item.Quality + 1, maxQuality);
            }
            else if (item.SellIn > 5)
            {
                item.Quality = Math.Min(item.Quality + 2, maxQuality);
            }
            else if (item.SellIn > 0)
            {
                item.Quality = Math.Min(item.Quality + 3, maxQuality);
            }
            else
            {
                item.Quality = 0;
            }
        }
    }
}
