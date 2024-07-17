using System;

namespace ProjektZakharB.Models
{
    public class Reminder
    {
        public int ReminderID { get; set; }
        public int UserID { get; set; }
        public string TekstPrzypomnienia { get; set; }
        public DateTime DataPrzypomnienia { get; set; }

        public User User { get; set; }
    }
}
