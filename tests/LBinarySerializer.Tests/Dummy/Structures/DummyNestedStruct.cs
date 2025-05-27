namespace LBinarySerializer.Tests;

public struct DummyNestedStruct
{
    public int IntValue { get; set; }
    public bool BoolValue { get; set; }
    public double DoubleValue { get; set; }
    public float FloatValue { get; set; }
    public decimal DecimalValue { get; set; }
    public short ShortValue { get; set; }
    public long LongValue { get; set; }
    public ulong ULongValue { get; set; }
    public byte ByteValue { get; set; }
    public sbyte SByteValue { get; set; }
    public ushort UShortValue { get; set; }
    public uint UIntValue { get; set; }
    public char CharValue { get; set; }
    public Guid GuidValue { get; set; }
    public TimeSpan TimeSpanValue { get; set; }
    public DummyEnum EnumValue { get; set; }
}