using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lm_km.core
{
    public class KeynoteRepository
    {
        private string _path;
        private List<Keynote> _keynoteEntriesList;

        public event Action<Keynote> KeynoteAdded;
        public event Action<Keynote> KeynoteDeleted;
        public List<Keynote> keynoteEntriesList { get => _keynoteEntriesList; set => _keynoteEntriesList = value; }

        public KeynoteRepository()
        {
            MediatorHelper.Register("OnKeynoteAdd", Insert);
            MediatorHelper.Register("OnKeynoteDelete", Delete);
            MediatorHelper.Register("OnKeynoteRepositorySaved", SaveKeynotes);
        }

        private Keynote Get(string category)
        {
            return _keynoteEntriesList.Find(x => x.Category == category);
        }

        public List<Keynote> GetItems()
        {
            var dic = KeynoteTable.GetKeynoteTable(RVT_App.RVT_UIApp.ActiveUIDocument.Document).GetExternalResourceReferences();
            _path = dic.Values.FirstOrDefault().InSessionPath;
            _keynoteEntriesList = CSV_Helper.ReadCSVFile(_path);
            return _keynoteEntriesList;
        }

        public void Insert(object o)
        {
            var keynote = o as Keynote;
            _keynoteEntriesList.Add(keynote);
        }
        public void Delete(object o)
        {
            var keynote = o as Keynote;
            _keynoteEntriesList.Remove(keynote);
        }
        public void Edit(Keynote newKeynote, Keynote oldKeynote)
        {
            oldKeynote.Text = newKeynote.Text;
            oldKeynote.Category = newKeynote.Category;
            oldKeynote.Parent = newKeynote.Parent;
        }

        private void SaveKeynotes(object o)
        {
            CSV_Helper.WriteCSVFile(_keynoteEntriesList, _path);
        }
        private void ReloadKeynotes()
        {
            throw new NotImplementedException();
        }

    }
}