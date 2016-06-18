using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Lazy_Illaoi
{
    internal class FarmHandler
    {
        public static AIHeroClient Player = ObjectManager.Player;

        public static void JungleClear()
        {
            var monster = EntityManager.MinionsAndMonsters.GetJungleMonsters(ObjectManager.Player.ServerPosition,
                    Spells.Q.Range)
                    .FirstOrDefault(x => x.IsValidTarget(Spells.Q.Range));
            if (monster == null) return;
            {
                if (Spells.Q.IsReady() && Init.FarmMenu["useQjungle"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.Q.Cast(monster);
                }

                if (!Spells.W.IsReady() || !Init.FarmMenu["useWjungle"].Cast<CheckBox>().CurrentValue) return;
                {
                    var tentaclesNearMonster = Events.TentacleList.Count(x => x.Distance(monster) < Spells.Q.Range);
                    if (tentaclesNearMonster > 0)
                    {
                        Spells.W.Cast();
                    }
                }
            }
        }

        public static void LaneClear()
        {
            var minions =
                EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                    Player.Position, Spells.Q.Range);
            var aiMinions = minions.ToArray();

            if (Spells.Q.IsReady() && 
                Player.Mana > Init.FarmMenu["qManaLane"].Cast<Slider>().CurrentValue &&
                Init.FarmMenu["useQlane"].Cast<CheckBox>().CurrentValue)
            {
                if (!aiMinions.Any()) return;

                foreach (var m in (from m in aiMinions
                    let p = new Geometry.Polygon.Rectangle((Vector2) Player.ServerPosition,
                        Player.ServerPosition.Extend(m.ServerPosition, Spells.Q.Range), Spells.Q.Width)
                    where
                        aiMinions.Count(x => p.IsInside(x.ServerPosition)) >=
                        Init.FarmMenu["qMinionsLane"].Cast<Slider>().CurrentValue
                    select m))
                {
                    Spells.Q.Cast(m.ServerPosition);
                }
            }

            if (!Spells.W.IsReady() ||
                !Init.FarmMenu["useWlane"].Cast<CheckBox>().CurrentValue ||
                    Player.Mana < Init.FarmMenu["wManaLane"].Cast<Slider>().CurrentValue ||
                    !aiMinions.Any()) return;
            {
                foreach (var m in from m in (from m in aiMinions.Where(x => x.Distance(Player) < 450) select m)
                    let tentaclesNearMinion = Events.TentacleList.Count(x => x.Distance(m) < Spells.Q.Range)
                    where tentaclesNearMinion > 0
                    where m.Distance(Player.ServerPosition) <= 450
                    select m)
                {
                    Spells.W.Cast();
                }
            }
        }
    }
}