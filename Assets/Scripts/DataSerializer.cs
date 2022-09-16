using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/// <summary>
/// Class for writing/reading data to/from a binary file.
/// </summary>
public static class DataSerializer
{
    /// <summary>
    /// Writes data in binary format
    /// </summary>
    /// <typeparam name="T"> Any class to serialize it to a file. </typeparam>
    /// <param name="data"> Serialization class object. </param>
    /// <param name="path"> Path without (<see cref="Application.persistentDataPath"/>). </param>
    public static void SerializeData<T>(T data, string path)
    {
        CheckDirectory();

        string pathToSettings = path.Contains(Application.persistentDataPath) ? path : Application.persistentDataPath + path;
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(pathToSettings, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    /// <summary>
    /// Reads data from a binary file.
    /// </summary>
    /// <typeparam name="T"> Any class to Deserialize it from a file. </typeparam>
    /// <param name="path"> Path without (<see cref="P:Application.persistentDataPath"/>). </param>
    /// <returns> Class object obtained by reading. </returns>
    public static T DeserializeData<T>(string path)
    {
        CheckDirectory();

        string pathToSettings = path.Contains(Application.persistentDataPath) ? path : Application.persistentDataPath + path;
        BinaryFormatter formatter = new BinaryFormatter();
        T data;

        if (File.Exists(pathToSettings) == false)
        {
            data = (T)Activator.CreateInstance(typeof(T));
            using (FileStream stream = new FileStream(pathToSettings, FileMode.Create))
            {
                formatter.Serialize(stream, data);
            }
        }
        else
        {
            using (FileStream stream = new FileStream(pathToSettings, FileMode.Open))
            {
                data = (T)formatter.Deserialize(stream);
            }
        }
        return data;
    }

    private static void CheckDirectory()
    {
        if (Directory.Exists(Application.persistentDataPath + "/data") == false)
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
    }
}
