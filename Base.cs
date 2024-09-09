﻿#pragma warning disable IDE1006
#pragma warning disable CS8618
namespace jd_tools;

public class Base
{
    public static readonly string newLine = Environment.NewLine;
    public static readonly string version = "0.7.0";
    #if (DEBUGX86 || RELEASEX86)
    public static readonly string architecture = "[x86]";
    #elif (DEBUGX64 || RELEASEX64)
    public static readonly string architecture = "[x64]";
    #endif
    public static readonly string[] commands =
    [
        "  [0] Compare scoring API's from recorded data",
        "  [1] Generate MSM's from recorded data"
    ];
    public static readonly string header = "Just Dance Tools | Created by Cami" + newLine + $"Version: {version} {architecture}" + newLine;
    public static string console = "...";
    public static string mapsPath = "";
    public static Settings settings;

    public static string BuildPath(string middlePath, string endPath) => @$"{Environment.CurrentDirectory}\" + middlePath + endPath;

    public static void WriteStaticHeader(bool sleep, string log, int commandID)
    {
        Console.Clear();
        Console.WriteLine(header);
        Console.WriteLine($"{commands[commandID].Replace($"[{commandID}] ", "")}{newLine}");
        Console.Write($"[Console]");
        console = log;
        Console.Write($"{newLine}{newLine}{DateTime.Now.ToString("hh:mm:ss")} - {console}");
        if (sleep) Thread.Sleep(500);
    }
}

public class Settings
{
    public string? mapsPath { get; set; }
    public float defaultLowThreshold { get; set; }
    public float defaultHighThreshold { get; set; }
    public float defaultAutoCorrelationThreshold { get; set; }
    public float defaultDirectionImpactFactor { get; set; }
    public uint defaultCustomizationBitField { get; set; }
}

public class RecordedAccData
{
    public int coachID { get; set; }
    public float accX { get; set; }
    public float accY { get; set; }
    public float accZ { get; set; }
    public float gyroX { get; set; }
    public float gyroY { get; set; }
    public float gyroZ { get; set; }
    public float mapTime { get; set; }
}

public class MusicTrack
{
    public float videoStartTime { get; set; }
    public float videoEndTime { get; set; }
    public int startBeat { get; set; }
    public int endBeat { get; set; }
    public List<float>? beats { get; set; }
}

public class Timeline
{
    public List<Move>? moves { get; set; }
}

public class Move
{
    public float time { get; set; }
    public float duration { get; set; }
    public string? name { get; set; }
    public int goldMove { get; set; }
    public int coachID { get; set; }
}
