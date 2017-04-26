using EloBuddy.SDK;
// ReSharper disable InconsistentNaming

namespace LazyXayah.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Skillshot Q => SpellManager.Q;
        protected Spell.Active W => SpellManager.W;
        protected Spell.Active E => SpellManager.E;
        protected Spell.Skillshot R => SpellManager.R;
        protected Spell.Skillshot Flash => SpellManager.Flash;
        public abstract bool ShouldBeExecuted();
        public abstract void Execute();
    }
}