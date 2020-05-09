using UnityEngine;

namespace Lang
{
    public class LanguageManager : MonoBehaviour
    {
        [SerializeField]
        public string languageSelected = "IT";

        public Lang lang;

        private void Start()
        {
            if (languageSelected.CompareTo("IT") == 0)
            {
                lang = new IT();
            }
            else if (languageSelected.CompareTo("ENG") == 0)
            {
                lang = new ENG();
            }
        }

    }
}