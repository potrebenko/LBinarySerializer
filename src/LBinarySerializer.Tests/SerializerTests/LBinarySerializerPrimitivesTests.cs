namespace LBinarySerializer.Tests;

/// <summary>
/// Primitive types serialization tests
/// </summary>
public class LBinarySerializerPrimitivesTests
{
    [Theory]
    [AutoData]
    public void Write_True_ShouldContainOne(LBinarySerializer serializer)
    {
        // Arrange
        var value = true;

        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData()[0].Should().Be(1);
        serializer.GetData().Should().HaveCount(1);
    }
    
    [Theory]
    [AutoData]
    public void Write_False_ShouldContainZero(LBinarySerializer serializer)
    {
        // Arrange
        var value = false;

        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData()[0].Should().Be(0);
        serializer.GetData().Should().HaveCount(1);
    }
    
    [Theory]
    [AutoData]
    public void Write_Byte_ShouldContainValue(LBinarySerializer serializer, byte value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData()[0].Should().Be(value);
        serializer.GetData().Should().HaveCount(1);
    }
    
    [Theory]
    [AutoData]
    public void Write_ByteArray_ShouldContainValue(LBinarySerializer serializer, byte[] value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(value);
        serializer.GetData().Should().HaveCount(value.Length);
    }
    
    [Theory]
    [AutoData]
    public void Write_Span_ShouldContainValue(LBinarySerializer serializer, byte[] value)
    {
        // Act
        serializer.Write(value.AsSpan());

        // Assert
        serializer.GetData().Should().BeEquivalentTo(value);
        serializer.GetData().Should().HaveCount(value.Length);
    }
    
    [Theory]
    [AutoData]
    public void Write_Int32_ShouldContainValue(LBinarySerializer serializer, int value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(int));
    }
    
    [Theory]
    [AutoData]
    public void Write_UInt32_ShouldContainValue(LBinarySerializer serializer, uint value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(uint));
    }
    
    [Theory]
    [AutoData]
    public void Write_Int16_ShouldContainValue(LBinarySerializer serializer, short value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(short));
    }
    
    [Theory]
    [AutoData]
    public void Write_UInt16_ShouldContainValue(LBinarySerializer serializer, ushort value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(ushort));
    }
    
    [Theory]
    [AutoData]
    public void Write_Long_ShouldContainValue(LBinarySerializer serializer, long value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(long));
    }
    
    [Theory]
    [AutoData]
    public void Write_ULong_ShouldContainValue(LBinarySerializer serializer, ulong value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(ulong));
    }
    
    [Theory]
    [AutoData]
    public void Write_Float_ShouldContainValue(LBinarySerializer serializer, float value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(float));
    }
    
    [Theory]
    [AutoData]
    public void Write_Double_ShouldContainValue(LBinarySerializer serializer, double value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(double));
    }
        
    [Theory]
    [AutoData]
    public void Write_Decimal_ShouldContainValue(LBinarySerializer serializer, decimal value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(decimal.GetBits(value).SelectMany(BitConverter.GetBytes));
        serializer.GetData().Should().HaveCount(sizeof(decimal));
    }
    
    [Theory]
    [AutoData]
    public void Write_Half_ShouldContainValue(LBinarySerializer serializer, Half value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(short));
    }
    
    [Theory]
    [AutoData]
    public void Write_Guid_ShouldNotEmptyGuid(LBinarySerializer serializer, Guid value)
    {
        // Act
        var guidSize = 16;
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(value.ToByteArray());
        serializer.GetData().Should().HaveCount(guidSize);
    }
    
    [Theory]
    [AutoData]
    public void Write_DateTime_ShouldContainValue(LBinarySerializer serializer, DateTime value)
    {
        // Arrange
        var expectedLength = sizeof(int) + sizeof(long);
        
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Take(4).Should().BeEquivalentTo(BitConverter.GetBytes((int)DateTimeKind.Unspecified));
        serializer.GetData().Skip(4).Should().BeEquivalentTo(BitConverter.GetBytes(value.Ticks));
        serializer.GetData().Should().HaveCount(expectedLength);
    }
    
    [Theory]
    [AutoData]
    public void Write_TimeSpan_ShouldContainValue(LBinarySerializer serializer, TimeSpan value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value.Ticks));
        serializer.GetData().Should().HaveCount(sizeof(long));
    }
    
    [Theory]
    [AutoData]
    public void Write_Char_ShouldContainValue(LBinarySerializer serializer, char value)
    {
        // Act
        serializer.Write(value);

        // Assert
        serializer.GetData().Should().BeEquivalentTo(BitConverter.GetBytes(value));
        serializer.GetData().Should().HaveCount(sizeof(short));
    }
}