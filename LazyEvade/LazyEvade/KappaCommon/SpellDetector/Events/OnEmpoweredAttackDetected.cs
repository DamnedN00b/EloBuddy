using LazyEvade.KappaCommon.SpellDetector.DetectedData;
using LazyEvade.KappaCommon.SpellDetector.Detectors;

namespace LazyEvade.KappaCommon.SpellDetector.Events
{
    public class OnEmpoweredAttackDetected
    {
        public delegate void EmpoweredAttackDetected(DetectedEmpoweredAttackData args);
        public static event EmpoweredAttackDetected OnDetect;
        internal static void Invoke(DetectedEmpoweredAttackData args)
        {
            var invocationList = OnDetect?.GetInvocationList();
            if (invocationList != null)
                foreach (var m in invocationList)
                    m?.DynamicInvoke(args);
        }

        static OnEmpoweredAttackDetected()
        {
            new EmpoweredAttackDetector();
        }
    }
}
