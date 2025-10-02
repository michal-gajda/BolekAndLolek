namespace Lolek.Application;

using Microsoft.FeatureManagement;

[FilterAlias("FluentValidation")]
internal sealed class FluentValidationFilter : IFeatureFilter
{
    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
    {
        return Task.FromResult(true);
    }
}
