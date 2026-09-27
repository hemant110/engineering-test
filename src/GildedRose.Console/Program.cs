using System.Collections.Generic;

namespace GildedRose.Console;

public class Program
{
    public IList<Item> Items = new List<Item>();

    static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");

        var app = new Program()
                      {
                          Items = new List<Item>
                                      {
                                          new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                          new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                          new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                          new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                          new Item
                                              {
                                                  Name = "Backstage passes to a TAFKAL80ETC concert",
                                                  SellIn = 15,
                                                  Quality = 20
                                              },
                                          new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                                          new Item {Name = "Conjured Items1", SellIn = 5, Quality = 10},
                                          new Item {Name = "Conjured Items2", SellIn = 0, Quality = 8},
                                          new Item {Name = "Conjured Items3", SellIn = 3, Quality = 1}
                                      }

                      };

        app.UpdateQuality();

        System.Console.ReadKey();
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            // Normal case quality decreases and increase as per item names
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Quality > 0)
                {
                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }

                    if (Items[i].Name.StartsWith("Conjured") && Items[i].Quality > 0) //Added extra code for conjured items to degrade quality twice faster
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

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
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

            // Decrease sell in date apply to all items except  Sulfuras
            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            //  Check if sellin date as passed, decrease quality again 
            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                        if (Items[i].Name.StartsWith("Conjured") && Items[i].Quality > 0) //Added extra code for conjured items to degrade quality twice faster
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                    else
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;// Backstage passes becom 0 after sellin
                    }
                }
                else // Aged Brie alway increases in quality
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }
            }
            //chekcing output
            System.Console.WriteLine($"Item Name: {Items[i].Name}, Sellin: {Items[i].SellIn}, Quality: {Items[i].Quality}" );
        }
    }
}

public class Item
{
    public string Name { get; set; } = "";

    public int SellIn { get; set; }

    public int Quality { get; set; }
}
