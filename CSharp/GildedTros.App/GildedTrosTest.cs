using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void RingOfCleansing_NormalDecrease_ShouldDecreaseWithOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Ring of Cleansening Code", SellIn = 10, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Ring of Cleansening Code", Items[0].Name);
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(19, Items[0].Quality);
        }

        [Fact]
        public void RingOfCleansing_FastDecrease_ShouldDecreaseWithTwo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Ring of Cleansening Code", SellIn = 0, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Ring of Cleansening Code", Items[0].Name);
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void GoodWine_Increase_ShouldIncreaseWithOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 5, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Good Wine", Items[0].Name);
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void GoodWine_Increase_ShouldIncreaseWithTwo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Good Wine", SellIn = -1, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Good Wine", Items[0].Name);
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void GoodWine_QualityFifty_ShouldNotIncrease()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 5, Quality = 50 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Good Wine", Items[0].Name);
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void ElixirOfTheSolid_NormalDecrease_ShouldNotDecreaseBelowZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Elixir of the SOLID", SellIn = 5, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Elixir of the SOLID", Items[0].Name);
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void BackStagePasses_IncreasesBeforeEvent()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 20 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 5, Quality = 20 },
                new Item { Name = "Backstage passes for HAXX", SellIn = 5, Quality = 49 }
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes for Re:factor", Items[0].Name);
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(21, Items[0].Quality);

            Assert.Equal("Backstage passes for Re:factor", Items[1].Name);
            Assert.Equal(9, Items[1].SellIn);
            Assert.Equal(22, Items[1].Quality);

            Assert.Equal("Backstage passes for Re:factor", Items[2].Name);
            Assert.Equal(4, Items[2].SellIn);
            Assert.Equal(23, Items[2].Quality);

            Assert.Equal("Backstage passes for HAXX", Items[3].Name);
            Assert.Equal(4, Items[3].SellIn);
            Assert.Equal(50, Items[3].Quality);
        }

        [Fact]
        public void BackStagePasses_AfterEvent_ShouldBeZero()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 20 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes for Re:factor", Items[0].Name);
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void BDawgKeychain_ShouldNotIncreaseOrDecrease()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "B-DAWG Keychain", SellIn = 0, Quality = 80 },
                new Item { Name = "B-DAWG Keychain", SellIn = -1, Quality = 80 }
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("B-DAWG Keychain", Items[0].Name);
            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);

            Assert.Equal("B-DAWG Keychain", Items[1].Name);
            Assert.Equal(-1, Items[1].SellIn);
            Assert.Equal(80, Items[1].Quality);
        }

        [Fact]
        public void ElixirOfTheSOLID_Decrease_ShouldDecreaseByOne()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Elixir of the SOLID", SellIn = 5, Quality = 7 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Elixir of the SOLID", Items[0].Name);
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(6, Items[0].Quality);
        }

        [Fact]
        public void SmellyItems_ShouldDecreaseTwiceAsFast()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Duplicate Code", SellIn = 3, Quality = 7 },
                new Item { Name = "Long Methods", SellIn = 3, Quality = 7 },
                new Item { Name = "Ugly Variable Names", SellIn = -1, Quality = 7 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("Duplicate Code", Items[0].Name);
            Assert.Equal(2, Items[0].SellIn);
            Assert.Equal(5, Items[0].Quality);

            Assert.Equal("Long Methods", Items[1].Name);
            Assert.Equal(2, Items[1].SellIn);
            Assert.Equal(5, Items[1].Quality);

            Assert.Equal("Ugly Variable Names", Items[2].Name);
            Assert.Equal(2, Items[2].SellIn);
            Assert.Equal(3, Items[2].Quality);
        }
    }
}