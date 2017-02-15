using LazyEvade.KappaCommon.SpellDetector.DetectedData;
using LazyEvade.KappaCommon.SpellDetector.Detectors;

namespace LazyEvade.KappaCommon.SpellDetector.Events
{
    public class OnSpecialSpellDetected
    {
        public delegate void SpecialSpellDetected(DetectedSpecialSpellData args);
        public static event SpecialSpellDetected OnDetect;
        internal static void Invoke(DetectedSpecialSpellData args)
        {
            var invocationList = OnDetect?.GetInvocationList();
            if (invocationList != null)
                foreach (var m in invocationList)
                    m?.DynamicInvoke(args);
        }

        static OnSpecialSpellDetected()
        {
            new SpecialSpellDetector();
        }
    }
}
