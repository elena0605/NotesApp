﻿using NotesConsoleClient.Models;

namespace NotesConsoleClient
{
    public static class ConsoleHelper
    {
        public static void ColorWriteLine(this string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintNotes(this List<NoteResponse> notes)
        {
            Console.Clear();
            "\n\tThe notes:".ColorWriteLine(ConsoleColor.Blue);
            foreach (var note in notes)
            {
                Console.WriteLine(note.ToString());
            }
        }
    }
}
