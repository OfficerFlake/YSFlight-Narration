using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace YSF_Narrator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public partial class Demonstration
    {
        public string name = "Name";
        public string teamName = "YSFlight Demonstration Team";
        public List<Pilot> pilots = new List<Pilot>();
        public List<Manoeuvre> maneuvers = new List<Manoeuvre>();
    }

    public partial class Manoeuvre
    {
        public string name = "Manuever";
        public int pilotBitwise = 0;
        public string narration = "Narration";
        public string Audio = "Audio Track";
    }

    public partial class Pilot
    {
        public string callSign = "CallSign";
        public string rank = "Rank";
        public string firstName = "FirstName";
        public string surname = "Surname";
        public string location = "Location";
        public string description = "Description";
    }
}
