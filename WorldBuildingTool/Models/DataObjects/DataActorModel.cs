using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorldBuildingTool.Models.DataObjects
{
    public class DataActorModel : DataObjectModel
    {
        private static int _id = 0;
        private DataPeopleModel _people;
        public DataActorModel(string name, string description, double dateOfBirth, double dateOfDeath, Image previewImage, DataPeopleModel people) : base(name, description, dateOfBirth, dateOfDeath, previewImage)
        {
            this.ID = _id++;
            _people = people;
        }
        public DataPeopleModel People
        {
            get => _people;
            set
            {
                if(_people != value)
                {
                    _people = value;
                    OnPropertyChanged(nameof(People));
                }
            }
        }
    }
}
