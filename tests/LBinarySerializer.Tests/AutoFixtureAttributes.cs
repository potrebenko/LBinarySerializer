using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace LBinarySerializer.Tests;

public class AutoNSubstituteDataAttribute() : AutoDataAttribute(() =>
{
    var fixture = new Fixture().Customize(new AutoNSubstituteCustomization())
        .Customize(new SupportMutableValueTypesCustomization());
    return fixture;
});
    
public class InlineAutoNSubstituteDataAttribute : InlineAutoDataAttribute
{
    public InlineAutoNSubstituteDataAttribute(params object[] arguments) 
        : base(new AutoNSubstituteCustomization(), arguments)
    {
            
    }
}