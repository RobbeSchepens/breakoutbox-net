using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using BreakOutBox.Models.Domain;

namespace BreakOutBoxG22.Tests.Data
{
    public class DummyApplicationDbContext
    {
        //bevat alle testgevallen : 
        //Brewer Bavik - alle gegevens zijn ingevuld
        //Brewer Moortgat - sommige gegevens zijn nog null
        //Brewer DeLeeuw bevat geen bieren.
        public IEnumerable<Sessie> Sessies { get; }
        public IEnumerable<Groep> Groepen { get; }
        public IEnumerable<Leerkracht> Leerkrachten { get; }
        public IEnumerable<Vak> Vakken { get; }
        public Sessie SessieGoed { get; }
        public Sessie SessieGroepenLeeg { get; }
        public Sessie SessieInSpel { get; }
        public Vak Wiskunde { get; }
        private readonly Pad _pad;

        public DummyApplicationDbContext()
        {
            Wiskunde = new Vak { Naam = "Wiskunde" };
            Vak chemie = new Vak { Naam = "Chemie" };
            Vak informatica = new Vak { Naam = "Informatica" };
            Vakken = new[] { Wiskunde, chemie, informatica };
            
            #region SessieGoed (zoals in data initializer)
            var toegangscodes = new List<Toegangscode>();

            for (var i = 100; i < 140; i++)
            {
                toegangscodes.Add(new Toegangscode(i));
            }

            // ACTIES
            // de mogelijke acties dat je moet ondernemen (in een balon prikken, telefoonboek opendoen)
            var acties = new List<Actie>();

            for (var i = 0; i < 40; i++)
            {
                acties.Add(new Actie("pak ballon " + (i + 1)));
            }

            // OEFENINGEN
            var oefeningen = new List<Oefening> { // dit zijn de oefeningen die in de sessie gebruikt worden
                    new Oefening("BerekenOmtrek", "oefening1.pdf", 10, new Vak("Wiskunde")),
                    new Oefening("Oefening2", "oefening2.pdf", 11, new Vak("Informatica")),
                    new Oefening("Oefening3", "oefening3.pdf", 12, new Vak("Aardrijkskunde")),
                    new Oefening("Oefening4", "oefening4.pdf", 13, new Vak("Mechanica")),
                    new Oefening("Oefening5", "oefening5.pdf", 14, new Vak("Nederlands")),
                    new Oefening("Oefening6", "oefening6.pdf", 15, new Vak("Engels")),
                    new Oefening("Oefening7", "oefening7.pdf", 16, new Vak("Fysica")),
                    new Oefening("Oefening8", "oefening8.pdf", 17, new Vak("Chemie"))
                };

            // FEEDBACK in OEFENING
            for (var i = 1; i < 9; i++)
            {
                oefeningen[i - 1].Feedback = "TheorieOefening" + i + ".pdf";
            }

            Box box = new Box(acties, oefeningen, toegangscodes, "Een box met diverse oefeningen", "BoxNaam");

            // GROEPSBEWERKINGEN
            var lijstMetGroepsbewerkingen = new List<String>();
            for (int i = 50; i < 90; i++)
            {
                lijstMetGroepsbewerkingen.Add("Tel " + i.ToString() + " bij op");
            }

            var act = box.Acties.ToList();
            var oef = box.Oefeningen.ToList();
            var toe = box.Toegangscodes.ToList();

            var opdrachtenGroep1 = new List<Opdracht>{ // lijst met alle opdrachten van groep1 (1,2, 3, 4, 5, 6, 7, 8)             
                    new Opdracht(1,act[0],oef[0],toe[0]),
                    new Opdracht(2,act[1],oef[1],toe[1]),
                    new Opdracht(3,act[2],oef[2],toe[2]),
                    new Opdracht(4,act[3],oef[3],toe[3]),
                    new Opdracht(5,act[4],oef[4],toe[4]),
                    new Opdracht(6,act[5],oef[5],toe[5]),
                    new Opdracht(7,act[6],oef[6],toe[6]),
                    new Opdracht(8,act[7],oef[7],toe[7])
                };

            for (int z = 0; z < 8; z++)
            {
                opdrachtenGroep1[z].Oefening.Opgave = "opdracht" + (z + 1) + "G1.pdf";
                opdrachtenGroep1[z].Oefening.Antwoord = z + 200;
            }
            
            for (int i = 0; i < 8; i++)
            {
                opdrachtenGroep1[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i];
            }

            var opdrachtenGroep2 = new List<Opdracht>{ // lijst met alle opdrachten van groep2 (7, 6, 5, 4, 3, 2, 1, 8)
                    new Opdracht(9,act[8],oef[6],toe[8]),
                    new Opdracht(10,act[9],oef[5],toe[9]),
                    new Opdracht(11,act[10],oef[4],toe[10]),
                    new Opdracht(12,act[11],oef[3],toe[11]),
                    new Opdracht(13,act[12],oef[2],toe[12]),
                    new Opdracht(14,act[13],oef[1],toe[13]),
                    new Opdracht(15,act[14],oef[0],toe[14]),
                    new Opdracht(16,act[15],oef[7],toe[15])
                };

            for (int i = 0; i < 8; i++)
            {
                opdrachtenGroep2[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i + 8];
                opdrachtenGroep1[i].Oefening.Antwoord = (i + 8) + 200;
            }

            var opdrachtenGroep3 = new List<Opdracht>{ // lijst met alle opdrachten van groep3 (3, 5, 7, 1, 2, 4, 6, 8)
                    new Opdracht(17,act[16],oef[2],toe[16]),
                    new Opdracht(18,act[17],oef[4],toe[17]),
                    new Opdracht(19,act[18],oef[6],toe[18]),
                    new Opdracht(20,act[19],oef[0],toe[19]),
                    new Opdracht(21,act[20],oef[1],toe[20]),
                    new Opdracht(22,act[21],oef[3],toe[21]),
                    new Opdracht(23,act[22],oef[5],toe[22]),
                    new Opdracht(24,act[23],oef[7],toe[23])
                };
            for (int i = 0; i < 8; i++)
            {
                opdrachtenGroep3[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i + 16];
                opdrachtenGroep1[i].Oefening.Antwoord = (i + 16) + 200;
            }


            var opdrachtenGroep4 = new List<Opdracht>{ // lijst met alle opdrachten van groep4 ( 6, 2, 5, 1, 4, 7, 3, 8 )
                    new Opdracht(25,act[24],oef[5],toe[24]),
                    new Opdracht(26,act[25],oef[1],toe[25]),
                    new Opdracht(27,act[26],oef[4],toe[26]),
                    new Opdracht(28,act[27],oef[0],toe[27]),
                    new Opdracht(29,act[28],oef[3],toe[28]),
                    new Opdracht(30,act[29],oef[6],toe[29]),
                    new Opdracht(31,act[30],oef[2],toe[30]),
                    new Opdracht(32,act[31],oef[7],toe[31])
                };

            for (int i = 0; i < 8; i++)
            {
                opdrachtenGroep4[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i + 24];
                opdrachtenGroep1[i].Oefening.Antwoord = (i + 24) + 200;
            }
            
            var opdrachtenGroep5 = new List<Opdracht>{ // lijst met alle opdrachten van groep5 (4, 3, 6, 2, 7, 5, 1, 8)
                    new Opdracht(33,act[32],oef[3],toe[32]),
                    new Opdracht(34,act[33],oef[2],toe[33]),
                    new Opdracht(35,act[34],oef[5],toe[34]),
                    new Opdracht(36,act[35],oef[1],toe[35]),
                    new Opdracht(37,act[36],oef[6],toe[36]),
                    new Opdracht(38,act[37],oef[4],toe[37]),
                    new Opdracht(39,act[38],oef[0],toe[38]),
                    new Opdracht(40,act[39],oef[7],toe[39])
                };
            
            for (int i = 0; i < 8; i++)
            {
                opdrachtenGroep5[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i + 32];
                opdrachtenGroep1[i].Oefening.Antwoord = (i + 32) + 200;
            }
            
            var paden = new List<Pad> { // elk pad heeft zijn eigen volgorde van vragen (region: LijstenMetOpdrachtenPerGroep)
                    new Pad(opdrachtenGroep1),
                    new Pad(opdrachtenGroep2),
                    new Pad(opdrachtenGroep3),
                    new Pad(opdrachtenGroep4),
                    new Pad(opdrachtenGroep5)
                };

            _pad = paden[0];
            
            var leerlingen = new List<Leerling>{
                    new Leerling("Andrea", "Van Dijk"),
                    new Leerling("Henk", "Bakker"),
                    new Leerling("Stephanie", "Mulder"),
                    new Leerling("Tom", "De Groot"),
                    new Leerling("Lily", "Bos"),
                    new Leerling("Jayden", "Hendriks"),
                    new Leerling("Pamela", "Dekker"),
                    new Leerling("Luc", "Dijkstra"),
                    new Leerling("Eva", "Jacobs"),
                    new Leerling("Harry", "Vermeulen"),

                    new Leerling("Katy", "Schouten"),
                    new Leerling("Marcel", "Willems"),
                    new Leerling("Rosa", "Hoekstra"),
                    new Leerling("Bob", "Koster"),
                    new Leerling("Sasha", "Verhoeven"),
                    new Leerling("Thijmen", "Prins"),
                    new Leerling("Sam", "Leunens"),
                    new Leerling("Sarah", "VanBossche"),
                    new Leerling("Femke", "Vanhoeke"),
                    new Leerling("Sep", "Jacobs"),
                };

            var groepen = new List<Groep> {
                  new Groep(paden[0], leerlingen.GetRange(0, 4), 0),
                  new Groep(paden[1], leerlingen.GetRange(4, 4), 0),
                  new Groep(paden[2], leerlingen.GetRange(8, 4), 1),
                  new Groep(paden[3], leerlingen.GetRange(12, 4), 1),
                  new Groep(paden[4], leerlingen.GetRange(16, 4), 2)
                };
            
            var lk = new Leerkracht("Tom", "Pieters", "Tom_Pieters@school.be");
            var k = new Klas(leerlingen, lk);
            lk.VoegKlasToe(k);

            var s = new Sessie("ABC", "Sessie1", "Maandag ochtend D klas", groepen, box, 1);
            s.Klas = k;
            lk.VoegSessieToe(s);
            #endregion
        }

        public Pad Pad => _pad;
    }
}

