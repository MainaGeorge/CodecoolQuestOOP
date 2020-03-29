using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public interface IFights
    {
        int Health { get; set; }

        Weapons Weapons { get; set; }

        bool IsDead { get; }
        bool Fight(IFights actor);
    }
}