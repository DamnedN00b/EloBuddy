using LazyEvade.KappaCommon.SpellDetector.DetectedData;
using LazyEvade.KappaCommon.SpellDetector.Detectors;

namespace LazyEvade.KappaCommon.SpellDetector.Events
{
    public class OnTargetedSpellDetected
    {
        public delegate void TargetedSpellDetected(DetectedTargetedSpellData args);
        public static event TargetedSpellDetected OnDetect;
        internal static void Invoke(DetectedTargetedSpellData args)
        {
            var invocationList = OnDetect?.GetInvocationList();
            if (invocationList != null)
                foreach (var m in invocationList)
                    m?.DynamicInvoke(args);
        }

        static OnTargetedSpellDetected()
        {
            new TargetedSpellDetector();
        }
    }
}
