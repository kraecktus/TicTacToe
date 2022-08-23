using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        // Field Rows sind von Oben nach unten (links an der seite die nummerierung) und die List in FieldRows sind A B C
        public static List<List<FieldType>> FieldRows = new List<List<FieldType>>();
        public static List<string> AvailableFields = new List<string>();
        public static string Winner = "";
        static void Main(string[] args)
        {
            Start();
        }
        // Cleart alle Lists und Fields
        public static void Initialize()
        {
            FieldRows.Clear();
            FieldRows.Add(new List<FieldType> { FieldType.Empty, FieldType.Empty, FieldType.Empty });
            FieldRows.Add(new List<FieldType> { FieldType.Empty, FieldType.Empty, FieldType.Empty });
            FieldRows.Add(new List<FieldType> { FieldType.Empty, FieldType.Empty, FieldType.Empty });
            AvailableFields.Clear();
            AvailableFields.AddRange(new List<string> { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" });
        }
        public static void Start()
        {
            Initialize();
            DrawField();
            StartGame();
            Console.ReadKey();
        }
        public static void StartGame()
        {
            for(int i = 1; i < 9; i++)
            {
                Console.Title = "Runde " + i;
                if (i % 2 == 1) GetPlayer("Spieler 1", FieldType.PlaceX);
                else GetPlayer("Spieler 2", FieldType.PlaceO);
                DrawField();
                if (CheckWin())
                {
                    break;
                }
            }
            DrawField();
            Console.WriteLine($"!!Game Over!!");
            if (Winner != "") Console.WriteLine($"Winner: {Winner}");
            else Console.WriteLine("Niemand Hat Gewonnen.");

        }
        // Kriegt den Nächsten Move vom Spieler der an der reihe ist
        public static void GetPlayer(string Player, FieldType playerType)
        {
            Console.WriteLine($"{Player}: Bitte Schreibe ein Spielfeld zum Setzen.");
            string Input = Console.ReadLine();
            if (Input == null || Input == "")
            {
                DrawField();
                GetPlayer(Player, playerType);
            }
            if(AvailableFields.Contains(Input))
            {
                int Field = (Convert.ToInt32(Input[1].ToString()) - 1);
                switch (Input[0].ToString())
                {
                    case "A":
                        FieldRows[Field][0] = playerType;
                        AvailableFields.Remove(Input);
                        break;
                    case "B":
                        FieldRows[Field][1] = playerType;
                        AvailableFields.Remove(Input);
                        break;
                    case "C":
                        FieldRows[Field][2] = playerType;
                        AvailableFields.Remove(Input);
                        break;
                    default:
                        // Wird Warscheinlich nicht gecallt, deswegen bleibt es leer.
                        break;
                }
            }
            else
            {
                DrawField();
                GetPlayer(Player, playerType);
            }
        }
        public static Boolean CheckWin()
        {
            FieldType type = FieldType.PlaceX;
            Boolean foundWin = false;
            for (int x = 0; x < 2; x++)
            {
                for (int i = 0; i < FieldRows.Count(); i++)
                {
                    // Links nach Rechts Check
                    if (FieldRows[i][0] == type && FieldRows[i][1] == type && FieldRows[i][2] == type)
                    {
                        foundWin = true;
                        break;
                    }
                    // Oben nach Unten Check
                    if (FieldRows[0][i] == type && FieldRows[1][i] == type && FieldRows[2][i] == type)
                    {
                        foundWin = true;
                        break;
                    }
                }
                // Check Oben Links nach Unten Rechts
                if(FieldRows[0][0] == type && FieldRows[1][1] == type && FieldRows[2][2] == type) foundWin = true;

                // Check Oben Rechts nach Unten Links
                if (FieldRows[0][2] == type && FieldRows[1][1] == type && FieldRows[2][0] == type) foundWin = true;

                if (foundWin) break;
                
                type = FieldType.PlaceO;
            }
            if (foundWin)
            {
                if (type == FieldType.PlaceX) Winner = "Spieler 1";
                else Winner = "Spieler 2";
                return true;
            }
            else return false;
        }
        public static void DrawField()
        {
            Console.Clear();
            Console.WriteLine("   | A | B | C ");
            Console.WriteLine("---------------");

            for (int i = 0; i < FieldRows.Count(); i++)
            {
                Console.Write($" {i + 1} ");
                foreach (FieldType x in FieldRows[i])
                {
                    Console.Write($"| {((char)x)} ");
                }
                Console.WriteLine("\n---------------");
            }
        }
    }
    public enum FieldType
    {
        Empty = ' ', 
        PlaceX = 'X',
        PlaceO = '0'
    }
}
