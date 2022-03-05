using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class TestFieldAttribute : Attribute
{
    public string Name;
}