using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileOperate
{
    public static byte[] ReadFileBytes(string filepath)
    {
        try
        {
            if (string.IsNullOrEmpty(filepath))
            {
                return null;
            }

            if (!File.Exists(filepath))
            {
                return null;
            }

            File.SetAttributes(filepath, FileAttributes.Normal);
            return File.ReadAllBytes(filepath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError(string.Format("ReadFileBytes failed! path = {0} with err = {1}", filepath, ex.Message));
            return null;
        }
    }
}
