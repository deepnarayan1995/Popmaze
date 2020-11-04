using System.Collections;
using Boomlagoon.JSON;
using System;

public class JsonUtil
{

    public static string CollectionToJsonString<T>(T array, string jsonKey) where T : IList
    {
        JSONObject jObject = new JSONObject();

        JSONArray jArray = new JSONArray();
        for (int i = 0; i < array.Count; i++)
            jArray.Add(new JSONValue(array[i].ToString()));

        jObject.Add(jsonKey, jArray);

        return jObject.ToString();
    }

    public static T[] JsonStringToArray<T>(string jSonString, string jSonKey, Func<string, T> parser)
    {
        JSONObject jObject = JSONObject.Parse(jSonString);
        JSONArray jArray = jObject.GetArray(jSonKey);

        T[] convertedArray = new T[jArray.Length];

        for (int i = 0; i < jArray.Length; i++)
            convertedArray[i] = parser(jArray[i].Str.ToString());

        return convertedArray;

    }


}
