using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json;
using Unity.Mathematics;
using Unity.VisualScripting;

namespace JsonDataSaver
{
    public class JsonData<T> : IData<T>
    {
        public void Save(T data, string path = null, string filename = null)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(Path.Combine(path,filename)))
            {
                using FileStream createStream = File.Create(Path.Combine(path, filename));
            }
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(Path.Combine(path, filename), json);
        }
        public void SaveAndAppend(T data, string path = null, string filename = null)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(Path.Combine(path, filename)))
            {
                using FileStream createStream = File.Create(Path.Combine(path, filename));
            }
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.AppendAllText(Path.Combine(path, filename), json);
        }
        public T Load(string path = null, string filename = null)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(Path.Combine(path, filename)))
            {
                using FileStream createStream = File.Create(Path.Combine(path, filename));
                return default(T);
            }
            var str = File.ReadAllText(Path.Combine(path, filename));
            T _data = JsonConvert.DeserializeObject<T>(str);
            return _data;
        }
    }
    public static class Crypto
    {
        public static string CryptoXOR(string text, int key = 12)
        {
            var result = String.Empty;
            foreach (var simbol in text)
            {
                result += (char)(simbol ^ key);
            }
            return result;
        }
    }
    [Serializable]
    public struct Vector3Serializable
    {
        public float X;
        public float Y;
        public float Z;
        private Vector3Serializable(float valueX, float valueY, float valueZ)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
        }

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }
        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);

        }

        public override string ToString() => $" (X = {X} Y = {Y} Z = {Z})";
    }
}

