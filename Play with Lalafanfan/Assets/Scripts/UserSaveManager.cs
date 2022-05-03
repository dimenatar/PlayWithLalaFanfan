using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class UserSaveManager
{
    public static string Path { get; private set; } = Application.persistentDataPath + "/UserData.bin";
    public static UserData UserData { get; private set; }

    public static UserData LoadUserData(string path)
    {
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        try
        {
            UserData = (UserData)new BinaryFormatter().Deserialize(stream);
            return UserData;
        }
        catch (System.Exception)
        {
            return new UserData();
        }
        finally
        {
            stream.Close();
        }
    }

    public static void SaveUserData(UserData userData)
    {
        UserData = userData;
    }

    public static void RewriteUserData()
    {
        FileStream stream = new FileStream(Path, FileMode.OpenOrCreate);
        new BinaryFormatter().Serialize(stream, UserData);
        stream.Close();
    }
}
