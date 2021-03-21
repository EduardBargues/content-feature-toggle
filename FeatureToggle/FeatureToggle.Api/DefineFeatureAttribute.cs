using System;

namespace FeatureToggle.Api
{
    public class DefineFeatureAttribute : Attribute
    {
        public string FeatureName { get; }

        public DefineFeatureAttribute(string featureName)
        {
            FeatureName = featureName ?? throw new ArgumentNullException(nameof(featureName));
        }
    }
}
