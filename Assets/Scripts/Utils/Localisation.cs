using UnityEngine;

namespace Utils
{
    public enum StringType
    {
        MenuLabelTitle, MenuButtonNewGame, MenuButtonExitGame, UIWaveCounter, UIWaveTimer, UIWaveSeconds
    }

    public enum LangType
    {
        English, Spanish, Russian
    }
    
    public class Localisation : MonoBehaviour
    {
        public static LangType CurrentLang = LangType.English;

        private static readonly string[] TextFieldEnglish =
        {
            "Project Farm", "New Game", "Exit Game", "Wave", "Next Wave In", "Sec(s)"
        };

        private static readonly string[] TextFieldSpanish =
        {

        };

        private static readonly string[] TextFieldRussian =
        {

        };

        private static string[][] _textFieldAll;

        public static string GetString(StringType type)
        {
            int index = (int)type;
            
            switch (CurrentLang)
            {
                case LangType.English:
                    return TextFieldEnglish[index];
                case LangType.Spanish:
                    return TextFieldSpanish[index];
                case LangType.Russian:
                    return TextFieldRussian[index];
            }

            return null;
        }
        
    }
}
