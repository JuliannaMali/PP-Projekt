namespace Projekt.Ruch;

public readonly struct TurnCourse
{

    public readonly double hero_dmg;
    public readonly double enem_dmg;
    public readonly double curr_hero_hp;
    public readonly double curr_enem_hp;

    public TurnCourse(double hd, double ed, double hhp, double ehp)
        => (hero_dmg, enem_dmg, curr_hero_hp, curr_enem_hp) =
        (Math.Round(hd, 2),
        Math.Round(ed, 2),
        Math.Round(hhp, 2),
        Math.Round(ehp, 2));
}