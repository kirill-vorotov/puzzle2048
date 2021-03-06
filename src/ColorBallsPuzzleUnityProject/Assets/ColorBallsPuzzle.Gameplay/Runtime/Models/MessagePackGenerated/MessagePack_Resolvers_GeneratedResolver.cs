// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Resolvers
{
    using System;

    public class GeneratedResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new GeneratedResolver();

        private GeneratedResolver()
        {
        }

        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            internal static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
                var f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    Formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }

    internal static class GeneratedResolverGetFormatterHelper
    {
        private static readonly global::System.Collections.Generic.Dictionary<Type, int> lookup;

        static GeneratedResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<Type, int>(15)
            {
                { typeof(global::ColorBallsPuzzle.Gameplay.BallLevel[]), 0 },
                { typeof(global::ColorBallsPuzzle.Gameplay.CampaignLevelDescId[]), 1 },
                { typeof(global::System.Collections.ObjectModel.ReadOnlyDictionary<global::ColorBallsPuzzle.Gameplay.CampaignLevelDescId, global::ColorBallsPuzzle.Gameplay.CampaignLevelDescModel>), 2 },
                { typeof(global::ColorBallsPuzzle.Gameplay.BallLevel), 3 },
                { typeof(global::ColorBallsPuzzle.Gameplay.CampaignDescModel), 4 },
                { typeof(global::ColorBallsPuzzle.Gameplay.CampaignLevelDescId), 5 },
                { typeof(global::ColorBallsPuzzle.Gameplay.CampaignLevelDescModel), 6 },
                { typeof(global::ColorBallsPuzzle.Gameplay.CampaignLevelResultModel), 7 },
                { typeof(global::ColorBallsPuzzle.Gameplay.CampaignLevelVisualDescModel), 8 },
                { typeof(global::ColorBallsPuzzle.Gameplay.CampaignStateModel), 9 },
                { typeof(global::ColorBallsPuzzle.Gameplay.DescriptionsModel), 10 },
                { typeof(global::ColorBallsPuzzle.Gameplay.DescriptionsVersion), 11 },
                { typeof(global::ColorBallsPuzzle.Gameplay.Health), 12 },
                { typeof(global::ColorBallsPuzzle.Gameplay.PlayerModel), 13 },
                { typeof(global::ColorBallsPuzzle.Gameplay.PlayerModelVersion), 14 },
            };
        }

        internal static object GetFormatter(Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key))
            {
                return null;
            }

            switch (key)
            {
                case 0: return new global::MessagePack.Formatters.ArrayFormatter<global::ColorBallsPuzzle.Gameplay.BallLevel>();
                case 1: return new global::MessagePack.Formatters.ArrayFormatter<global::ColorBallsPuzzle.Gameplay.CampaignLevelDescId>();
                case 2: return new global::MessagePack.Formatters.ReadOnlyDictionaryFormatter<global::ColorBallsPuzzle.Gameplay.CampaignLevelDescId, global::ColorBallsPuzzle.Gameplay.CampaignLevelDescModel>();
                case 3: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.BallLevelFormatter();
                case 4: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.CampaignDescModelFormatter();
                case 5: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.CampaignLevelDescIdFormatter();
                case 6: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.CampaignLevelDescModelFormatter();
                case 7: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.CampaignLevelResultModelFormatter();
                case 8: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.CampaignLevelVisualDescModelFormatter();
                case 9: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.CampaignStateModelFormatter();
                case 10: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.DescriptionsModelFormatter();
                case 11: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.DescriptionsVersionFormatter();
                case 12: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.HealthFormatter();
                case 13: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.PlayerModelFormatter();
                case 14: return new MessagePack.Formatters.ColorBallsPuzzle.Gameplay.PlayerModelVersionFormatter();
                default: return null;
            }
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1649 // File name should match first type name
