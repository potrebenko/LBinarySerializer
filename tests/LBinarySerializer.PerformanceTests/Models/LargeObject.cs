using ProtoBuf;

namespace LBinarySerializer.PerformanceTests;

[ProtoContract]
public class LargeObject : ILBinarySerializable
{
    [ProtoMember(1)]
    public int IntValue { get; set; }
    
    [ProtoMember(2)]
    public string StringValue { get; set; }
    
    [ProtoMember(3)]
    public DateTime DateTime { get; set; }
    
    [ProtoMember(4)]
    public double DoubleValue { get; set; }
    
    [ProtoMember(5)]
    public bool BoolValue { get; set; }
    
    [ProtoMember(6)]
    public Guid GuidValue { get; set; }
    
    [ProtoMember(7)]
    public short ShortValue { get; set; }
    
    [ProtoMember(8)]
    public ushort UShortValue { get; set; }
    
    [ProtoMember(9)]
    public int[] IntArray { get; set; }
    
    [ProtoMember(10)]
    public string[] StringArray { get; set; }
    
    [ProtoMember(11)]
    public Dictionary<string, int> StringIntDictionary { get; set; }
    
    [ProtoMember(12)]
    public InlineObject InlineObject { get; set; }
    
    [ProtoMember(13)]
    public InlineObject[] InlineObjects { get; set; }
    
    public void Serialize(LBinarySerializer serializer)
    {
        serializer.Write(IntValue);
        serializer.Write(StringValue);
        serializer.Write(DateTime);
        serializer.Write(DoubleValue);
        serializer.Write(BoolValue);
        serializer.Write(GuidValue);
        serializer.Write(ShortValue);
        serializer.Write(UShortValue);
        serializer.Write(IntArray);
        serializer.Write(StringArray);
        serializer.Write(StringIntDictionary);
        serializer.Write(InlineObject);
        serializer.Write(InlineObjects);
    }

    public void Deserialize<T>(LBinaryDeserializer deserializer)
    {
        IntValue = deserializer.ReadInt();
        StringValue = deserializer.ReadString()!;
        DateTime = deserializer.ReadDateTime();
        DoubleValue = deserializer.ReadDouble();
        BoolValue = deserializer.ReadBool();
        GuidValue = deserializer.ReadGuid();
        ShortValue = deserializer.ReadShort();
        UShortValue = deserializer.ReadUShort();
        IntArray = deserializer.ReadArrayOf<int>()!;
        StringArray = deserializer.ReadArrayOfStrings()!;
        StringIntDictionary = deserializer.ReadDictionaryOfStructs<int>();
        InlineObject = deserializer.Deserialize<InlineObject>()!;
        InlineObjects = deserializer.ReadArrayOf<InlineObject>()!;
    }
}

[ProtoContract]
public class InlineObject : ILBinarySerializable
{
    [ProtoMember(1)]
    public int IntValue { get; set; }
    
    [ProtoMember(2)]
    public string StringValue { get; set; }
    
    [ProtoMember(3)]
    public DateTime DateTime { get; set; }
    
    [ProtoMember(4)]
    public double DoubleValue { get; set; }
    
    public void Serialize(LBinarySerializer serializer)
    {
        serializer.Write(IntValue);
        serializer.Write(StringValue);
        serializer.Write(DateTime);
        serializer.Write(DoubleValue);
    }

    public void Deserialize<T>(LBinaryDeserializer deserializer)
    {
        IntValue = deserializer.ReadInt();
        StringValue = deserializer.ReadString()!;
        DateTime = deserializer.ReadDateTime();
        DoubleValue = deserializer.ReadDouble();
    }
}

