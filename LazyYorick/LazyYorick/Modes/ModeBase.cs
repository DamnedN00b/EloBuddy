using EloBuddy.SDK;

namespace LazyYorick.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Active Q => SpellManager.Q;
        protected Spell.Skillshot W => SpellManager.W;
        protected Spell.Skillshot E => SpellManager.E;
        protected Spell.Skillshot R => SpellManager.R;
        public abstract bool ShouldBeExecuted();
        public abstract void Execute();
    }
}