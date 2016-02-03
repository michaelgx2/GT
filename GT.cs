using System.Collections.Generic;
using System.Text;

public static class GT
{

    private static Dictionary<string, string> _texts = new Dictionary<string, string>();

    /// <summary>
    /// Load all texts from a long string
    /// </summary>
    /// <param name="texts"></param>
    public static void LoadText(string texts)
    {
        _texts.Clear();
        _texts = GetDicFromString(texts);
    }

    /// <summary>
    /// Get string by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string G(string key)
    {
        if (_texts.ContainsKey(key))
        {
            return _texts[key];
        }
        else
        {
            return "#ERROR";
        }
    }

    /// <summary>
    /// Get string by key and replace part of it
    /// </summary>
    /// <param name="key"></param>
    /// <param name="replacePair">target, replaced, target, replaced...</param>
    /// <returns></returns>
    public static string G(string key, params string[] replacePair)
    {
        StringBuilder sb = new StringBuilder(G(key));
        for (int i = 0; i < replacePair.Length - 1; i+=2)
        {
            sb.Replace(replacePair[i], replacePair[i + 1]);
        }
        return sb.ToString();
    }

    private static Dictionary<string, string> GetDicFromString(string texts)
    {
        Dictionary<string, string> ret = new Dictionary<string, string>();

        string[] lines = texts.Split('\n');
        foreach (string line in lines)
        {
            if (!line.Contains("="))
                continue;
            bool value = false;
            string key = "";
            string val = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '=')
                {
                    if (value)
                    {
                        val += line[i];
                    }
                    else
                    {
                        value = true;
                    }
                }
                else
                {
                    if (line[i] != '\r')
                    {
                        if (value)
                        {
                            val += line[i];
                        }
                        else
                        {
                            key += line[i];
                        }
                    }
                }
            }
            ret.Add(key, val);
        }

        return ret;
    }
}

