using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionUtil : MonoBehaviour {

    public enum VersionCompareResult
    {
        GT,
        EQ,
        LT
    }

    public static VersionCompareResult VersionStringCompare(string currentVersionStr, string clientVersionStr)
    {
        if (string.IsNullOrEmpty(clientVersionStr))
        {
            return VersionCompareResult.GT;
        }
        else
        {
            int currentVersionNum = VersionStrToNum(currentVersionStr);
            int clientVersionNum = VersionStrToNum(clientVersionStr);
            if (currentVersionNum == clientVersionNum)
            {
                return VersionCompareResult.EQ;
            }
            else if (currentVersionNum > clientVersionNum)
            {
                return VersionCompareResult.GT;
            }
            else
            {
                return VersionCompareResult.LT;
            }
        }
    }

    //1.12.40
    //1.12.400 is not ok
    public static int VersionStrToNum(string versionStr)
    {
        string[] parts=versionStr.Split('.');
        int part0=int.Parse(parts[0]);
        int part1=int.Parse(parts[1]);
        int part2=int.Parse(parts[2]);

        //Debug.Log(part0+"|"+part1+"|"+part2);

        int totalNum = part2 + part1 * 100 + part0 * 10000;

        return totalNum;
    }


    public static bool VersionFormatCheck(string versionStr)
    {
        if (string.IsNullOrEmpty(versionStr))
        {
            return false;
        }
        else
        {
            string[] parts = versionStr.Split('.');
            if (parts.Length != 3)
            {
                return false;
            }
            else
            {
                foreach (string part in parts)
                { 
                    int result;
                    if (!int.TryParse(part, out result))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
