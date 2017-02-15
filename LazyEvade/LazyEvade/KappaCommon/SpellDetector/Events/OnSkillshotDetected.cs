using LazyEvade.KappaCommon.SpellDetector.DetectedData;
using LazyEvade.KappaCommon.SpellDetector.Detectors;

namespace LazyEvade.KappaCommon.SpellDetector.Events
{
    public class OnSkillShotDetected
    {
        public delegate void SkillShotDetected(DetectedSkillshotData args);
        public static event SkillShotDetected OnDetect;
        internal static void Invoke(DetectedSkillshotData args)
        {
            var invocationList = OnDetect?.GetInvocationList();
            if (invocationList != null)
                foreach (var m in invocationList)
                    m?.DynamicInvoke(args);
        }

        static OnSkillShotDetected()
        {
            new SkillshotDetector();
        }
    }
}
