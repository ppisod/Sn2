using System;

namespace ppiLib.Types;

public abstract class ConfigurableField <T>
{
    public static T defaultValue;
    public Func <T> getter;
    public Action<T> setter;
}