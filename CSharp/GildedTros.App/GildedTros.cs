using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items;
        public const string RingOfCleanseningCode = "Ring of Cleansening Code";
        public const string ElixirOfTheSolid = "Elixir of the SOLID";
        public const string DuplicateCode = "Duplicate Code";
        public const string LongMethods = "Long Methods";
        public const string UglyVariableNames = "Ugly Variable Names";
        public const string BackStagePassesForReFactor = "Backstage passes for Re:factor";
        public const string BackStagePassesForHAXX = "Backstage passes for HAXX";
        public const string GoodWine = "Good Wine";
        public const string BDawgKeyChain = "B-DAWG Keychain";

        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                switch(item.Name)
                {
                    case GoodWine:
                        UpdateGoodWine(item);
                        break;
                    case DuplicateCode:
                    case LongMethods:
                    case UglyVariableNames:
                        UpdateSmellyItems(item);
                        break;
                    case RingOfCleanseningCode:
                    case ElixirOfTheSolid:
                        UpdateNormalItem(item);
                        break;
                    case BackStagePassesForReFactor:
                    case BackStagePassesForHAXX:
                        UpdateBackStagePasses(item);
                        break;
                    case BDawgKeyChain:
                        break;
                    default:
                        break;
                }
            }
        }

        public static void UpdateNormalItem(Item item)
        {
            const int minQuality = 0;
            item.Quality = item.SellIn > 0 ? Math.Max(--item.Quality, minQuality) : Math.Max(item.Quality - 2, minQuality); ;
            item.SellIn--;
        }

        public static void UpdateGoodWine(Item item)
        {
            const int maxQuality = 50;
            item.Quality = item.SellIn > 0 ? Math.Min(++item.Quality , maxQuality) : Math.Min(item.Quality + 2, maxQuality); ;
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

            item.SellIn--;
        }
    }
}
