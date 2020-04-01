using System.Collections.Generic;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Assets;

namespace Codecool.Quest.Models.Utilities
{
    public class ItemsCollected
    {

        public List<Item> AllItems { get; set; }

        public ItemsCollected()
        {
            AllItems = new List<Item>();
        }

        public void AddItemToTheCollection(Item collectedItem)
        {
            AllItems.Add(collectedItem);
        }
        public List<Item> GetCollectedItems()
        {
            return AllItems;
        }

        public void RemoveAnItemFromTheCollection(Item item)
        {
            AllItems.Remove(item);
        }


    }
}