using UnityEngine;
using UnityEngine.Animations;

namespace Jobus.Extensions
{
    public static class ConstraintExtensions
    {
        /// <summary>
        /// Adds a constraint source.
        /// </summary>
        public static void AddSource(this IConstraint constraint, Transform sourceTransform, float weight = 1f)
        {
            constraint.AddSource(new ConstraintSource {sourceTransform = sourceTransform, weight = weight});
        }
    
        /// <summary>
        /// Adds a constraint source using the current relative offset.
        /// </summary>
        public static void AddSourceWithCurrentOffsets(this ParentConstraint constraint, Transform sourceTransform, float weight = 1f)
        {
            constraint.AddSource(new ConstraintSource {sourceTransform = sourceTransform, weight = weight});
            constraint.SetTranslationOffset(0, sourceTransform.transform.InverseTransformPoint(constraint.transform.position));
            constraint.SetRotationOffset(0, (Quaternion.Inverse(sourceTransform.transform.rotation)*constraint.transform.rotation).eulerAngles);
        }
    }
}