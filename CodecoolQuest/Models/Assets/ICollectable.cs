using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Assets
{
    public interface ICollectable
    {
        bool GetCollected(Player player);
    }



}