using System;

namespace TheGame.Engine
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ReadOnlyAttribute : Attribute
    {
    }
}