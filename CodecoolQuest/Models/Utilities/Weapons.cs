namespace Codecool.Quest.Models.Utilities
{
    public class Weapons
    {
        public bool Gun { get; set; }
        public bool Sword { get; set; }
        public bool Headmask { get; set; }
        public bool IsBulletProof => Gun && Headmask && Sword;
    }
}
