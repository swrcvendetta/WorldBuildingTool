using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorldBuildingTool.Models.DataObjects
{
    public class DataLanguageModel : DataObjectModel
    {
        private static int _id = 0;
        private DataScriptModel _scriptModel;
        public ObservableCollection<DataDictionaryModel> _dictionaryModel;
        public DataLanguageModel(string name, string description, double dateOfBirth, double dateOfDeath, Image previewImage, DataScriptModel script) : base(name, description, dateOfBirth, dateOfDeath, previewImage)
        {
            this.ID = _id++;
            _scriptModel = script;
            _dictionaryModel = new ObservableCollection<DataDictionaryModel>();
        }
        public ObservableCollection<DataDictionaryModel> DictionaryModel
        {
            get => _dictionaryModel;
            set
            {
                if(_dictionaryModel != value)
                {
                    _dictionaryModel = value;
                    OnPropertyChanged(nameof(DictionaryModel));
                }
            }
        }
        public void AddDictionary(DataDictionaryModel dictionary)
        {
            _dictionaryModel.Add(dictionary);
        }
        public bool RemoveDictionary(DataDictionaryModel dictionary)
        {
            return _dictionaryModel.Remove(dictionary);
        }
        public DataScriptModel Script
        {
            get => _scriptModel;
            set
            {
                if(_scriptModel != value)
                {
                    _scriptModel = value;
                    OnPropertyChanged(nameof(Script));
                }
            }
        }
    }
}
