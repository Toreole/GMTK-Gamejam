using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class ReplayCheck
{
    const string fileName = "Error.log";
    const string fileContent = "So apparently somehow an error happened.\n The good old turn it off and on again trick should help?\nGod i hope that works.";

    public static bool HasPlayedBefore(bool createFileOnFalse)
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            if (createFileOnFalse)
            {
                var stream = File.Create(path);
                byte[] buffer = System.Text.Encoding.ASCII.GetBytes(fileContent);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                stream.Close();
            }
            return false;
        }
    }
}
