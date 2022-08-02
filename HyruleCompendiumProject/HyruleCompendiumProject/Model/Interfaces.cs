using System.Collections.Generic;

namespace HyruleCompendiumProject.Model
{
    public interface IHasDrops
    {
        List<string> Drops { get; }
    }

    public interface IHasHeartsRecovered
    {
        string HeartsRecovered { get; }
    }

    public interface IHasCookingEffects
    {
        string CookingEffects { get; }
    }

    public interface IHasAttack
    {
        string Attack { get; }
    }

    public interface IHasDefense
    {
        string Defense { get; }
    }
}
