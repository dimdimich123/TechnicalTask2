using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class DataSerializer
{
    public static void SerializeData<T>(T data, string path)
    {
        string pathToSettings = path.Contains(Application.persistentDataPath) ? path : Application.persistentDataPath + path;
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(pathToSettings, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    public static T DeserializeData<T>(string path)
    {
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
}
