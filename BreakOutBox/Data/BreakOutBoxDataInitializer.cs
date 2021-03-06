﻿using BreakOutBox.Models;
using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BreakOutBox.Data
{
    public class BreakOutBoxDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public BreakOutBoxDataInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                await InitializeLeerkrachten();

                #region Box aanmaken
                // TOEGANGSCODES
                // deze code geeft aan wat je volgende oefening is (bv. de code die je in een balon terugvind)
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
                    acties.Add(new Actie("Pak ballon met nummer van jouw groepsantwoord"));
                }

                // OEFENINGEN
                var wisk = new Vak("Wiskunde");
                var nl = new Vak("Nederlands");
                var nk = new Vak("Natuurkunde");
                var aard = new Vak("Aardrijkskunde");

                var oefeningen = new List<Oefening> { // dit zijn de oefeningen die in de sessie gebruikt worden
                    new Oefening("Aftrekkingen", "oefening1.pdf", 80, wisk),
                    new Oefening("Delingen", "oefening2.pdf", 23, wisk),
                    new Oefening("Dieren", "oefening3.pdf", 10, nk),
                    new Oefening("Hoofdstad VK", "oefening4.pdf", 10, aard),
                    new Oefening("Kleuren", "oefening5.pdf", 14, nl),
                    new Oefening("Letters", "oefening6.pdf", 15, nl),
                    new Oefening("Optelsommen", "oefening7.pdf", 40, wisk),
                    new Oefening("Organen", "oefening8.pdf", 17, nk),
                    new Oefening("Rekensommen", "oefening7.pdf", 800, wisk),
                    new Oefening("Vermenigsvuldigingen", "oefening7.pdf", 542, wisk),
                    new Oefening("Voltooid deelwoorden", "oefening8.pdf", 17, nl),
                    new Oefening("Werkwoorden", "oefening8.pdf", 17, nl)
                };

                // FEEDBACK in OEFENING
                for (var i = 1; i < 9; i++)
                {
                    oefeningen[i - 1].Feedback = "TheorieOefening" + i + ".pdf";
                }

                Box box = new Box(acties, oefeningen, toegangscodes, "Focus op wiskunde", "Wiskunde");
                #endregion

                #region Opdrachten opvullen en in pad steken
                // GROEPSBEWERKINGEN
                //var lijstMetGroepsbewerkingen = new List<String>();
                //for (int i = 50; i < 90; i++)
                //{
                //    lijstMetGroepsbewerkingen.Add("Tel " + i.ToString() + " bij op");
                //}

                var act = box.Acties.ToList();
                var oef = box.Oefeningen.ToList();
                var toe = box.Toegangscodes.ToList();

                var opdrachtenGroep1 = new List<Opdracht>{ // lijst met alle opdrachten van groep1 (1,2, 3, 4, 5, 6, 7, 8)             
                    new Opdracht(1,act[0],oef[0],toe[0],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(2,act[1],oef[1],toe[1],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(3,act[2],oef[2],toe[2],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(4,act[3],oef[3],toe[3],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(5,act[4],oef[4],toe[4],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(6,act[5],oef[5],toe[5],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(7,act[6],oef[6],toe[6],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(8,act[7],oef[7],toe[7],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN)
                };

                for (int z = 0; z < 8; z++)
                {
                    opdrachtenGroep1[z].Oefening.Opgave = "opdracht" + (z + 1) + "G1.pdf";
                    opdrachtenGroep1[z].Oefening.Antwoord = z + 200;
                    opdrachtenGroep1[z].IsToegankelijk = true;
                    opdrachtenGroep1[z].IsGestart = true;
                    //opdrachtenGroep1[z].MaxTijdInMinuten = 1;
                }

                for (int z = 0; z < 7; z++)
                    opdrachtenGroep1[z].IsOpgelost = true;

                //for (int i = 0; i < 8; i++)
                //{
                //    opdrachtenGroep1[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i];
                //}
                _dbContext.SaveChanges();

                var opdrachtenGroep2 = new List<Opdracht>{ // lijst met alle opdrachten van groep2 (7, 6, 5, 4, 3, 2, 1, 8)
                    new Opdracht(1,act[8],oef[6],toe[8],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(2,act[9],oef[5],toe[9],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(3,act[10],oef[4],toe[10],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(4,act[11],oef[3],toe[11],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(5,act[12],oef[2],toe[12],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(6,act[13],oef[1],toe[13],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(7,act[14],oef[0],toe[14],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(8,act[15],oef[7],toe[15],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN)
                };
                for (int i = 0; i < 8; i++)
                {
                    //opdrachtenGroep2[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i + 8];
                    opdrachtenGroep1[i].Oefening.Antwoord = (i + 8) + 200;
                }
                _dbContext.SaveChanges();

                var opdrachtenGroep3 = new List<Opdracht>{ // lijst met alle opdrachten van groep3 (3, 5, 7, 1, 2, 4, 6, 8)
                    new Opdracht(1,act[16],oef[2],toe[16],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(2,act[17],oef[4],toe[17],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(3,act[18],oef[6],toe[18],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(4,act[19],oef[0],toe[19],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(5,act[20],oef[1],toe[20],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(6,act[21],oef[3],toe[21],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(7,act[22],oef[5],toe[22],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(8,act[23],oef[7],toe[23],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN)
                };
                for (int i = 0; i < 8; i++)
                {
                    //opdrachtenGroep3[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i + 16];
                    opdrachtenGroep1[i].Oefening.Antwoord = (i + 16) + 200;
                }
                _dbContext.SaveChanges();

                var opdrachtenGroep4 = new List<Opdracht>{ // lijst met alle opdrachten van groep4 ( 6, 2, 5, 1, 4, 7, 3, 8 )
                    new Opdracht(1,act[24],oef[5],toe[24],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(2,act[25],oef[1],toe[25],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(3,act[26],oef[4],toe[26],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(4,act[27],oef[0],toe[27],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(5,act[28],oef[3],toe[28],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(6,act[29],oef[6],toe[29],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(7,act[30],oef[2],toe[30],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(8,act[31],oef[7],toe[31],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN)
                };
                for (int i = 0; i < 8; i++)
                {
                    //opdrachtenGroep4[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i + 24];
                    opdrachtenGroep1[i].Oefening.Antwoord = (i + 24) + 200;
                }
                _dbContext.SaveChanges();

                var opdrachtenGroep5 = new List<Opdracht>{ // lijst met alle opdrachten van groep5 (4, 3, 6, 2, 7, 5, 1, 8)
                    new Opdracht(1,act[32],oef[3],toe[32],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(2,act[33],oef[2],toe[33],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(3,act[34],oef[5],toe[34],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(4,act[35],oef[1],toe[35],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(5,act[36],oef[6],toe[36],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(6,act[37],oef[4],toe[37],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(7,act[38],oef[0],toe[38],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN),
                    new Opdracht(8,act[39],oef[7],toe[39],GenereerGroepsbewerking(),EnumOpdrachtBepaler.POGINGEN)
                };
                for (int i = 0; i < 8; i++)
                {
                    //opdrachtenGroep5[i].Oefening.Groepsbewerking = lijstMetGroepsbewerkingen[i + 32];
                    opdrachtenGroep1[i].Oefening.Antwoord = (i + 32) + 200;
                }
                _dbContext.SaveChanges();

                var paden = new List<Pad> { // elk pad heeft zijn eigen volgorde van vragen (region: LijstenMetOpdrachtenPerGroep)
                    new Pad(opdrachtenGroep1),
                    new Pad(opdrachtenGroep2),
                    new Pad(opdrachtenGroep3),
                    new Pad(opdrachtenGroep4),
                    new Pad(opdrachtenGroep5)
                };
                _dbContext.SaveChanges();
                #endregion

                #region Leerlingen en groepen
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
                #endregion

                #region Klas, leerkracht en sessie
                var lk = new Leerkracht("Tom", "Pieters", "Tom_Pieters@school.be");
                var k = new Klas(leerlingen, lk);
                lk.VoegKlasToe(k);

                var s = new Sessie("XYZ", "Wis A1 Ma", "Een sessie wiskunde op donderdag", groepen, box, false, 1);
                s.Klas = k;
                lk.VoegSessieToe(s);

                _dbContext.Leerkrachten.Add(lk);
                _dbContext.Sessies.Add(s);
                _dbContext.SaveChanges();
                #endregion
            }
        }

        private async Task InitializeLeerkrachten()
        {
            string eMailAddress = "Tom_Pieters@school.be";
            ApplicationUser leerkracht = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress };
            await _userManager.CreateAsync(leerkracht, "P@ssword1!");
            await _userManager.AddClaimAsync(leerkracht, new Claim(ClaimTypes.Role, "leerkracht"));
        }

        private Groepsbewerking GenereerGroepsbewerking()
        {
            Random rnd = new Random();
            Groepsbewerking groepsbewerking = new Groepsbewerking((EnumBewerking)rnd.Next(0, 4), rnd.Next(1, 6));
            return groepsbewerking;
        }
    }
}
