using System.Collections.Generic;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Assets;

namespace Codecool.Quest.Models.Utilities
{
    public class ItemsCollected
    {
        public Key Key { get; set; }

        public Crown Crown { get; set; }

        public List<Actor> AllItems { get; set; }

        public ItemsCollected()
        {
            AllItems = new List<Actor>();
        }

        public void AddItemToTheCollection(Actor collectedItem)
        {
            AllItems.Add(collectedItem);
        }
        public IEnumerable<Actor> GetCollectedItems()
        {
            return AllItems;
        }


    }
}