
namespace Lang
{
    public abstract class Lang
    {
        //Action
        public string takeMessage;

        //Object name
        public string stone;
    }
    public class IT : Lang
    {
        public IT()
        {
            takeMessage = "[E] Prendi ";
            stone = "Pietra";
        }
    }

    public class ENG : Lang 
    {
        public ENG()
        {
            takeMessage = "[E] Take ";
            stone = "Stone";
        }
    }

}
