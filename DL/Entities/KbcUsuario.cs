namespace DL.Entities
{
    public class KbcUsuario
    {        
        public int usuId { get; set; }

        public int perfId { get; set; }
        public int perId { get; set; }
        
        public string usuUserName { get; set; }        
        public string usuClave { get; set; }
        public bool usuTipo { get; set; }
        public bool usuVigente { get; set; }
    }
}
