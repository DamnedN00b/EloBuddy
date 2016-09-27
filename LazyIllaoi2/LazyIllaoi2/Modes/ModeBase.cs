using EloBuddy.SDK;

namespace LazyIllaoi2.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Skillshot Q => SpellManager.Q;
        protected Spell.Active W => SpellManager.W;
        protected Spell.Skillshot E => SpellManager.E;
        protected Spell.Active R => SpellManager.R;
        public abstract bool ShouldBeExecuted();
        public abstract void Execute();
    }
}