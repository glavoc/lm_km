using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lm_km.core
{
    public class KeynoteRepository
    {
        public event Action<Keynote> KeynoteAdded;
        public event Action<Keynote> KeynoteDeleted;
        private List<Keynote> _keynoteEntriesList { get; set; }

        public KeynoteRepository()
        {
        }

        private Keynote Get(string category)
        {
            return _keynoteEntriesList.Find(x => x.Category == category);
        }

        public List<Keynote> GetItems()
        {
            var dic = KeynoteTable.GetKeynoteTable(RVT_App.RVT_UIApp.ActiveUIDocument.Document).GetExternalResourceReferences();
            var path = dic.Values.FirstOrDefault().InSessionPath;
            _keynoteEntriesList = CSV_Helper.ReadCSVFile(path);
            return _keynoteEntriesList;
        }

        public void Add(Keynote keynote)
        {
            _keynoteEntriesList.Add(keynote);
            KeynoteAdded?.Invoke(keynote);
        }
        public void Delete(Keynote keynote)
        {
            _keynoteEntriesList.Remove(keynote);
            KeynoteDeleted?.Invoke(keynote);
        }
        public void Edit(Keynote newKeynote, Keynote oldKeynote)
        {
            oldKeynote.Text = newKeynote.Text;
            oldKeynote.Category = newKeynote.Category;
            oldKeynote.Parent = newKeynote.Parent;
        }

        public void SaveKeynotes()
        {
            throw new NotImplementedException();
        }
        public void ReloadKeynotes()
        {
            throw new NotImplementedException();
        }

    }
}