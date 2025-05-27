using System.Text.Json;
using AutoFixture;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using ProtoBuf;

namespace LBinarySerializer.PerformanceTests;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[MemoryDiagnoser]
public class SerializerSmallObjectsBenchmarks
{
    private readonly LBinarySerializer _serializer = new();
    private readonly LBinaryDeserializer _deserializer = new();
    private readonly MemoryStream _protobufStream = new(1024);
    
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    [Params(1)]
    public int N;
    
    private SmallObject? _rawData;
    private byte[]? _lBinarySerializedData;
    private byte[]? _protobufSerializedData;
    private byte[]? _jsonSerializedData;

    [GlobalSetup]
    public void Setup()
    {
        _rawData = new Fixture().Create<SmallObject>();
        
        // Serialize
        _rawData.Serialize(_serializer);
        _lBinarySerializedData = _serializer.GetData();
        _serializer.Reset();
        
        Serializer.Serialize(_protobufStream, _rawData);
        _protobufSerializedData = _protobufStream.ToArray();
        _protobufStream.Position = 0;
        
        _jsonSerializedData = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_rawData, _jsonSerializerOptions);
    }

    [Benchmark(Baseline = true, Description = "LBinarySerializer")]
    [BenchmarkCategory(BenchmarkCategories.SerializeSmall)]
    public void LBinarySerializer()
    {
        for (int i = 0; i < N; i++)
        {
            _rawData!.Serialize(_serializer);
            var bytes = _serializer.GetData();
            _serializer.Reset();
        }
    }

    [Benchmark(Description = "ProtoBufSerializer")]
    [BenchmarkCategory(BenchmarkCategories.SerializeSmall)]
    public void ProtoBufSerializer()
    {
        for (int i = 0; i < N; i++)
        {
            Serializer.Serialize(_protobufStream, _rawData);
            var bytes = _protobufStream.ToArray();
            _protobufStream.Position = 0;
        }
    }

    [Benchmark(Description = "JsonSerializer")]
    [BenchmarkCategory(BenchmarkCategories.SerializeSmall)]
    public void JsonSerializer()
    {
        for (int i = 0; i < N; i++)
        {
            var bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_rawData, _jsonSerializerOptions);
        }
    }

    [Benchmark(Description = "LBinaryDeserializer")]
    [BenchmarkCategory(BenchmarkCategories.DeserializeSmall)]
    public void LBinaryDeserializer()
    {
        for (int i = 0; i < N; i++)
        {
            var result = _deserializer.Deserialize<SmallObject>(_lBinarySerializedData!);
        }
    }
    
    [Benchmark(Description = "ProtoBufDeserializer")]
    [BenchmarkCategory(BenchmarkCategories.DeserializeSmall)]
    public void ProtoBufDeserializer()
    { 
        for (int i = 0; i < N; i++)
        {
            var result = Serializer.Deserialize<SmallObject>((ReadOnlySpan<byte>)_protobufSerializedData);
        }
    }
    
    [Benchmark(Description = "JsonSerializerDeserializer")]
    [BenchmarkCategory(BenchmarkCategories.DeserializeSmall)]
    public void JsonSerializerDeserializer()
    {
        for (int i = 0; i < N; i++)
        {
            var result = System.Text.Json.JsonSerializer.Deserialize<SmallObject>(_jsonSerializedData);
        }
    }
}