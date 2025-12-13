using System;

namespace ppiLib.Types._Attributes;

[AttributeUsage ( AttributeTargets.All )]
public class Normal : Attribute {
    public bool Normalized { get; }

    public Normal ( bool normalized ) {
        Normalized = normalized;
    }
}
