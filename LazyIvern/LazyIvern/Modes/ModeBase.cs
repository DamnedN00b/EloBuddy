using EloBuddy.SDK;

namespace LazyIvern.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Skillshot Q => SpellManager.Q;
        protected Spell.SimpleSkillshot W => SpellManager.W;
        protected Spell.Targeted E => SpellManager.E;
        protected Spell.Targeted R => SpellManager.R;
        public abstract bool ShouldBeExecuted();
        public abstract void Execute();
    }
}