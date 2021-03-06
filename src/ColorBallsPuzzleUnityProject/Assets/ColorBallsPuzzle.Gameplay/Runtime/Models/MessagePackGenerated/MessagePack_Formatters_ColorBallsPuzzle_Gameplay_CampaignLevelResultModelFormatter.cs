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

    public sealed class CampaignLevelResultModelFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::ColorBallsPuzzle.Gameplay.CampaignLevelResultModel>
    {
        // 0.2.5-score
        private static global::System.ReadOnlySpan<byte> GetSpan_Score() => new byte[1 + 11] { 171, 48, 46, 50, 46, 53, 45, 115, 99, 111, 114, 101 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::ColorBallsPuzzle.Gameplay.CampaignLevelResultModel value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteMapHeader(1);
            writer.WriteRaw(GetSpan_Score());
            writer.Write(value.Score);
        }

        public global::ColorBallsPuzzle.Gameplay.CampaignLevelResultModel Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                throw new global::System.InvalidOperationException("typecode is null, struct not supported");
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadMapHeader();
            var ____result = new global::ColorBallsPuzzle.Gameplay.CampaignLevelResultModel();

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.Internal.CodeGenHelpers.ReadStringSpan(ref reader);
                switch (stringKey.Length)
                {
                    default:
                    FAIL:
                      reader.Skip();
                      continue;
                    case 11:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_Score().Slice(1))) { goto FAIL; }

                        reader.Skip();
                        continue;

                }
            }

            reader.Depth--;
            return ____result;
        }
    }
}
