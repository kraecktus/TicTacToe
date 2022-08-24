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
        public static List<Player> Players = new List<Player>();
        public static Player Winner;
        static void Main(string[] args)
        {
            Start();
        }
        // Cleart alle Lists und Fields
        public static void Initialize()
        {
            FieldRows.Clear();
            FieldRows.AddRange(new List<List<FieldType>> { new List<FieldType> { FieldType.Empty, FieldType.Empty, FieldType.Empty }, new List<FieldType> { FieldType.Empty, FieldType.Empty, FieldType.Empty }, new List<FieldType> { FieldType.Empty, FieldType.Empty, FieldType.Empty } });
            AvailableFields.Clear();
            AvailableFields.AddRange(new List<string> { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" });

            Winner = new Player() { PlayerName = "", FieldType = FieldType.Empty };

            Players.Add(new Player { PlayerName = "Spieler 1", FieldType = FieldType.PlaceX});
            Players.Add(new Player { PlayerName = "Spieler 2", FieldType = FieldType.PlaceO});
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
            for (int i = 1; i < 9; i++)
            {
                Console.Title = "Runde " + i;
                if (i % 2 == 1) MakeTurn(Players[0]);
                else MakeTurn(Players[1]);

                DrawField();

                if (CheckWin()) break;
            }
            DrawField();
            Console.WriteLine($"!!Game Over!!");
            if (Winner.PlayerName != "") Console.WriteLine($"Winner: {Winner.PlayerName}");
            else Console.WriteLine("Niemand Hat Gewonnen.");

        }
        // Kriegt den Nächsten Move vom Spieler der an der reihe ist
        public static void MakeTurn(Player player)
        {
            Console.WriteLine($"{player.PlayerName}: Bitte Schreibe ein Spielfeld zum Setzen.");
            string Input = Console.ReadLine();
            while (Input == null || Input == "" || !AvailableFields.Contains(Input))
            {
                DrawField();
                Console.WriteLine($"{player.PlayerName}: Bitte Schreibe ein Richtiges Spielfeld zum Setzen.");
                Input = Console.ReadLine();
            }
            int Field = (Convert.ToInt32(Input[1].ToString()) - 1);
            char Row = Input[0];
            if (Row == 'A') FieldRows[Field][0] = player.FieldType;
            else if (Row == 'B') FieldRows[Field][1] = player.FieldType;
            else if (Row == 'C') FieldRows[Field][2] = player.FieldType;

            AvailableFields.Remove(Input);
        }
        public static Boolean CheckWin()
        {
            Boolean foundWin = false;
            foreach(Player currentPlayer in Players)
            { 
                for (int i = 0; i < FieldRows.Count(); i++)
                {
                    // Links nach Rechts Check
                    if (FieldRows[i][0] == currentPlayer.FieldType && FieldRows[i][1] == currentPlayer.FieldType && FieldRows[i][2] == currentPlayer.FieldType) foundWin = true;

                    // Oben nach Unten Check
                    if (FieldRows[0][i] == currentPlayer.FieldType && FieldRows[1][i] == currentPlayer.FieldType && FieldRows[2][i] == currentPlayer.FieldType) foundWin = true;

                    if (foundWin) break;
                }
                // Check Oben Links nach Unten Rechts
                if(FieldRows[0][0] == currentPlayer.FieldType && FieldRows[1][1] == currentPlayer.FieldType && FieldRows[2][2] == currentPlayer.FieldType) foundWin = true;

                // Check Oben Rechts nach Unten Links
                if (FieldRows[0][2] == currentPlayer.FieldType && FieldRows[1][1] == currentPlayer.FieldType && FieldRows[2][0] == currentPlayer.FieldType) foundWin = true;

                if (foundWin)
                {
                    Console.WriteLine(currentPlayer.PlayerName);
                    Winner = currentPlayer;
                    return true;
                }
            }
            return false;
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
    public class Player
    {
        public string PlayerName { get; set; }
        public FieldType FieldType { get; set; }
    }
    public enum FieldType
    {
        Empty = ' ', 
        PlaceX = 'X',
        PlaceO = '0'
    }
}
