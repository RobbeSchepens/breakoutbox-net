using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakOutBox.Models.Domain
{
    public class Klas
    {
        #region Properties
        public int KlasId { get; set; }
        public ICollection<Leerling> Leerlingen { get; set; }
        public ICollection<KlasLeerkracht> KlasLeerkrachten { get; private set; }
        public IEnumerable<Leerkracht> Leerkrachten => KlasLeerkrachten.Select(k => k.Leerkracht);
        public int NrOfLeerlingen => Leerlingen.Count;
        public int NrOfLeerkrachten => KlasLeerkrachten.Count;
        #endregion

        #region Constructors
        public Klas()
        {
            KlasLeerkrachten = new HashSet<KlasLeerkracht>();
            Leerlingen = new HashSet<Leerling>();
        }
        #endregion

        #region Methods
        public void VoegLeerkrachtToe(Leerkracht leerkracht)
        {
            KlasLeerkrachten.Add(new KlasLeerkracht(this, leerkracht));
        }

        public void VoegLeerlingToe(Leerling leerling)
        {
            Leerlingen.Add(leerling);
        }

        public void VerwijderLeerkracht(Leerkracht leerkracht)
        {
            if (!KlasLeerkrachten.Contains(new KlasLeerkracht(this, leerkracht)))
                throw new ArgumentException($"Leerkracht {leerkracht.Voornaam} {leerkracht.Achternaam} is geen bestaande leerkracht.");
            KlasLeerkrachten.Remove(new KlasLeerkracht(this, leerkracht));
        }

        public void VerwijderLeerling(Leerling leerling)
        {
            if (!Leerlingen.Contains(leerling))
                throw new ArgumentException($"{leerling.Voornaam} {leerling.Achternaam} bestaat niet.");
            Leerlingen.Remove(leerling);
        }
        #endregion Methods
    }
}