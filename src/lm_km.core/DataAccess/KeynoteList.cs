using System;
using System.Collections.Generic;

namespace lm_km.core
{
    public static class KeynoteList
    {
        private static List<Keynote> _keynoteEntriesList;
        public static List<Keynote> KeynoteEntriesList { get => _keynoteEntriesList; set => _keynoteEntriesList = value; }

        private static Keynote Get(string category)
        {
            return _keynoteEntriesList.Find(x => x.Category == category);
        }

        public static List<Keynote> GetItems(string path)
        {
            KeynoteEntriesList = CSV_Helper.ReadCSVFile(path);
            return KeynoteEntriesList;
        }

        public static void Add(Keynote keynote)
        {
            _keynoteEntriesList.Add(keynote);
        }
        public static void Edit(Keynote newKeynote, Keynote oldKeynote)
        {
            oldKeynote.Text = newKeynote.Text;
            oldKeynote.Category = newKeynote.Category;
            oldKeynote.Parent = newKeynote.Parent;
        }

        public static void SaveKeynotes()
        {
            throw new NotImplementedException();
        }
        public static void ReloadKeynotes()
        {
            throw new NotImplementedException();
        }

    }
}