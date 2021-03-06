// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.ColorBallsPuzzle.Gameplay
{
    using global::System.Buffers;
    using global::MessagePack;

    public sealed class PlayerModelFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::ColorBallsPuzzle.Gameplay.PlayerModel>
    {
        // 0.2.5-version
        private static global::System.ReadOnlySpan<byte> GetSpan_Version() => new byte[1 + 13] { 173, 48, 46, 50, 46, 53, 45, 118, 101, 114, 115, 105, 111, 110 };
        // 0.2.5-campaign_progress
        private static global::System.ReadOnlySpan<byte> GetSpan_CampaignState() => new byte[1 + 23] { 183, 48, 46, 50, 46, 53, 45, 99, 97, 109, 112, 97, 105, 103, 110, 95, 112, 114, 111, 103, 114, 101, 115, 115 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::ColorBallsPuzzle.Gameplay.PlayerModel value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            var formatterResolver = options.Resolver;
            writer.WriteMapHeader(2);
            writer.WriteRaw(GetSpan_Version());
            formatterResolver.GetFormatterWithVerify<global::ColorBallsPuzzle.Gameplay.PlayerModelVersion>().Serialize(ref writer, value.Version, options);
            writer.WriteRaw(GetSpan_CampaignState());
            formatterResolver.GetFormatterWithVerify<global::ColorBallsPuzzle.Gameplay.CampaignStateModel>().Serialize(ref writer, value.CampaignState, options);
        }

        public global::ColorBallsPuzzle.Gameplay.PlayerModel Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var formatterResolver = options.Resolver;
            var length = reader.ReadMapHeader();
            var ____result = new global::ColorBallsPuzzle.Gameplay.PlayerModel();

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.Internal.CodeGenHelpers.ReadStringSpan(ref reader);
                switch (stringKey.Length)
                {
                    default:
                    FAIL:
                      reader.Skip();
                      continue;
                    case 13:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_Version().Slice(1))) { goto FAIL; }

                        ____result.Version = formatterResolver.GetFormatterWithVerify<global::ColorBallsPuzzle.Gameplay.PlayerModelVersion>().Deserialize(ref reader, options);
                        continue;
                    case 23:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_CampaignState().Slice(1))) { goto FAIL; }

                        ____result.CampaignState = formatterResolver.GetFormatterWithVerify<global::ColorBallsPuzzle.Gameplay.CampaignStateModel>().Deserialize(ref reader, options);
                        continue;

                }
            }

            reader.Depth--;
            return ____result;
        }
    }
}
