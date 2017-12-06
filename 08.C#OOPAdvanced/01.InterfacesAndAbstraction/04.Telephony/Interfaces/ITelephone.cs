namespace _04.Telephony
{
    using System.Collections.Generic;

    public interface ITelephone
    {
        ICollection<string> PhoneNumber { get; }
        ICollection<string> Site { get; }
        
    }
}
