using System;
using System.IO;
using ColorBallsPuzzle.Gameplay;
using MessagePack;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace ColorBallsPuzzle.Editor
{
    public static class DescriptionsModelEditor
    {
        [MenuItem("ColorBallsPuzzle/Create descriptions json")]
        public static void SaveDescriptionsModelToJson()
        {
            var descriptions = DescriptionsFactory.CreateDescriptions();
            SaveDescriptionsModelToJson(descriptions, Path.Combine(Application.dataPath, "Descriptions.json"));
        }
        
        public static void SaveDescriptionsModelToJson(DescriptionsModel descriptions, string destPath)
        {
            var text = JsonConvert.SerializeObject(descriptions, Formatting.Indented);
            {
                using var sw = new StreamWriter(destPath, false);
                sw.Write(text);
            }

            {
                using var sr = new StreamReader(destPath);
                var str = sr.ReadToEnd();
                var desc = JsonConvert.DeserializeObject<DescriptionsModel>(str);
            }
        }
        
        [MenuItem("ColorBallsPuzzle/Create descriptions msgpack")]
        public static void SaveDescriptionsModelToMsgpack()
        {
            var descriptions = DescriptionsFactory.CreateDescriptions();
            SaveDescriptionsModelToMsgpack(descriptions, Path.Combine(Application.dataPath, "DescriptionsMsgpack.txt"));
        }
        
        public static void SaveDescriptionsModelToMsgpack(DescriptionsModel descriptions, string destPath)
        {
            StaticCompositeResolver.Instance.Register(
                UnityResolver.Instance,
                UnityBlitWithPrimitiveArrayResolver.Instance,
                StandardResolver.Instance,
                GeneratedResolver.Instance);
            var options = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);
            MessagePackSerializer.DefaultOptions = options;
            
            {
                var bytes = MessagePackSerializer.Serialize(descriptions);
                var text = Convert.ToBase64String(bytes);
                using var sw = new StreamWriter(destPath, false);
                sw.Write(text);
            }

            {
                using var sr = new StreamReader(destPath);
                var text = sr.ReadToEnd();
                var bytes = Convert.FromBase64String(text);
                var model = MessagePackSerializer.Deserialize<DescriptionsModel>(bytes);
            }
        }
    }
}