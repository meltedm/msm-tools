﻿using System.Text;

#pragma warning disable CS8602
#pragma warning disable IDE1006
namespace msm_tools;

public class MoveSpaceManager
{
    public static void SerializeMove(bool reverse, MoveSpace move, string outputFile)
    {
        using BinaryWriter writer = new(File.OpenWrite(outputFile));
        writer.Write(new byte[4]);
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.version)));
        writer.Write(Encoding.UTF8.GetBytes(move.moveName.PadRight(0x40, '\0')));
        writer.Write(Encoding.UTF8.GetBytes(move.mapName.PadRight(0x40, '\0')));
        writer.Write(Encoding.UTF8.GetBytes(move.measureSet.PadRight(0x40, '\0')));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.moveDuration)));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.moveAccurateLowThreshold)));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.moveAccurateHighThreshold)));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.autoCorrelationThreshold)));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.moveDirectionImpactFactor)));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.moveMeasureBitfield)));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.measureValue)));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.measureCount)));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.energyMeasureCount)));
        writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(move.moveCustomizationFlags)));
        foreach (float measure in move.measures)
        {
            writer.Write(ReverseEndianess(reverse, BitConverter.GetBytes(measure)));
        }
    }

    public static MoveSpace DeserializeMove(bool reverse, string msmFile)
    {
        using BinaryReader reader = new(File.OpenRead(msmFile));
        reader.ReadBytes(4);
        MoveSpace move = new()
        {
            version = BitConverter.ToInt32(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            moveName = Encoding.UTF8.GetString(reader.ReadBytes(0x40)).TrimEnd('\0'),
            mapName = Encoding.UTF8.GetString(reader.ReadBytes(0x40)).TrimEnd('\0'),
            measureSet = Encoding.UTF8.GetString(reader.ReadBytes(0x40)).TrimEnd('\0'),
            moveDuration = BitConverter.ToSingle(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            moveAccurateLowThreshold = BitConverter.ToSingle(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            moveAccurateHighThreshold = BitConverter.ToSingle(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            autoCorrelationThreshold = BitConverter.ToSingle(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            moveDirectionImpactFactor = BitConverter.ToSingle(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            moveMeasureBitfield = BitConverter.ToInt64(ReverseEndianess(reverse, reader.ReadBytes(8)), 0),
            measureValue = BitConverter.ToInt32(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            measureCount = BitConverter.ToInt32(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            energyMeasureCount = BitConverter.ToInt32(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            moveCustomizationFlags = BitConverter.ToInt32(ReverseEndianess(reverse, reader.ReadBytes(4)), 0),
            measures = []
        };
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            move.measures.Add(BitConverter.ToSingle(ReverseEndianess(reverse, reader.ReadBytes(4)), 0));
        }
        return move;
    }

    static byte[] ReverseEndianess(bool reverse, byte[] data)
    {
        if (reverse) Array.Reverse(data);
        return data;
    }

    public class MoveSpace
    {
        public int version { get; set; }
        public string? moveName { get; set; }
        public string? mapName { get; set; }
        public string? measureSet { get; set; }
        public float moveDuration { get; set; }
        public float moveAccurateLowThreshold { get; set; }
        public float moveAccurateHighThreshold { get; set; }
        public float autoCorrelationThreshold { get; set; }
        public float moveDirectionImpactFactor { get; set; }
        public long moveMeasureBitfield { get; set; }
        public int measureValue { get; set; }
        public int measureCount { get; set; }
        public int energyMeasureCount { get; set; }
        public int moveCustomizationFlags { get; set; }
        public List<float>? measures { get; set; }
    }
}
