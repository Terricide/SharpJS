using System;
using System.Runtime.InteropServices;

public static class Program {
    public static unsafe void Main (string[] args) {
        var types = new Type[] {
            typeof(EmptyStruct),
            typeof(TwoBytes),
            typeof(TwoBytesOneInt),
            typeof(TwoBytesShortDouble),
            typeof(DoubleTwoBytes),
            typeof(ByteNestedByte)
        };

        foreach (var type in types)
            Console.WriteLine("sizeof({0}) == {1}", type.Name, Marshal.SizeOf(type));
    }
}