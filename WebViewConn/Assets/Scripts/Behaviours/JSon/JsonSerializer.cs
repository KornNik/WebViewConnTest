using System.IO;
using UnityEngine;

namespace Behaviours
{
    sealed class JsonSerializer<T> : IData<T>
    {
        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, str);
        }

        public T Load(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(str);
        }
    }
    public interface IData<T>
    {
        void Save(T data, string path = null);
        T Load(string path = null);
    }
}
