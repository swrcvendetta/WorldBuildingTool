using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorldBuildingTool.Models.DataObjects
{
    public class DataDictionaryModel : DataObjectModel
    {
        private static int _id = 0;
        private ObservableCollection<DataWordModel> _words;
        public DataDictionaryModel(string name, string description, double dateOfBirth, double dateOfDeath, Image previewImage) : base(name, description, dateOfBirth, dateOfDeath, previewImage)
        {
            this.ID = _id++;
            _words = new ObservableCollection<DataWordModel>();
        }
        public ObservableCollection<DataWordModel> Words
        {
            get => _words;
            set
            {
                if(_words != value)
                {
                    _words = value;
                    OnPropertyChanged(nameof(Words));   // just in case?
                }
            }
        }
        public void AddWord(DataWordModel word)
        {
            _words.Add(word);
        }
        public bool RemoveWord(DataWordModel word)
        {
            return _words.Remove(word);
        }
    }
}
