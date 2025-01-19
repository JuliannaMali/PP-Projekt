using Projekt.Postaci;
using System.Text.Json.Serialization;

namespace Projekt.Mapy;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Hero), nameof(Hero))]
[JsonDerivedType(typeof(Knight), nameof(Knight))]
[JsonDerivedType(typeof(Scout), nameof(Scout))]
public interface IMappable
{
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point p);
}

