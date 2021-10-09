using System;
using MessagePack;
using UnityEngine;

namespace ColorBallsPuzzle.Gameplay
{
    public static class PlayerModelPlayerPrefsStorage
    {
        public const string PlayerModelKey = "PlayerModel";
        
        public static void Write(PlayerModel playerModel)
        {
            var byteArray = MessagePackSerializer.Serialize(playerModel);
            var playerModelString = Convert.ToBase64String(byteArray);
            if (string.IsNullOrEmpty(playerModelString))
            {
                return;
            }
            PlayerPrefs.SetString(PlayerModelKey, playerModelString);
            PlayerPrefs.Save();
        }
        
        public static PlayerModel Read()
        {
            try
            {
                var playerModel = PlayerLogic.CreatePlayerModel(PlayerModelVersion.Parse(GameConstants.PlayerModelVersion));
                var playerModelString = PlayerPrefs.GetString(PlayerModelKey, "");
                if (string.IsNullOrEmpty(playerModelString))
                {
                    return playerModel;
                }

                var byteArray = Convert.FromBase64String(playerModelString);
                playerModel = MessagePackSerializer.Deserialize<PlayerModel>(byteArray);
                return playerModel;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
    }
}