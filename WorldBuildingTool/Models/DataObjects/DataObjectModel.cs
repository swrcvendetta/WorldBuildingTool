using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorldBuildingTool.Models.DataObjects
{
    public abstract class DataObjectModel : ModelBase
    {
        private string name;
        private string description;
        private double dateOfBirth;
        private double dateOfDeath;
        private double x;
        private double y;
        private Image previewImage;

        public int ID { get; protected set; }

        public DataObjectModel(string name, string description, double dateOfBirth, double dateOfDeath, Image previewImage)
        {
            // Inits
            this.name = "";
            this.description = "";
            this.dateOfBirth = 0.0;
            this.dateOfDeath = 0.0;
            this.x = 0.0;
            this.y = 0.0;
            this.previewImage = previewImage;   // add default image here
            // Validations
            this.Name = name;
            this.Description = description;
            this.DateOfBirth = dateOfBirth;
            this.DateOfDeath = dateOfDeath;
            this.PreviewImage = previewImage;
        }
        public string Name
        {
            get { return this.Name; }
            set
            {
                if(name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(name));
                }
            }
        }
        public string Description
        {
            get { return this.Description; }
            set
            {
                if (description != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(description));
                }
            }
        }
        public double DateOfBirth
        {
            get => this.dateOfBirth;
            set
            {
                if(dateOfBirth != value)
                {
                    dateOfBirth = value;
                    OnPropertyChanged(nameof(dateOfBirth));
                }
            }
        }
        public double DateOfDeath
        {
            get => this.dateOfDeath;
            set
            {
                if(dateOfDeath != value)
                {
                    if(value < dateOfBirth)
                        dateOfDeath = dateOfBirth;
                    else
                        dateOfDeath = value;

                    OnPropertyChanged(nameof(dateOfDeath));
                }
            }
        }
        public double X
        {
            get => x;
            set
            {
                if(x != value)
                {
                    x = value;
                    OnPropertyChanged(nameof(x));
                }
            }
        }
        public double Y
        {
            get => y;
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged(nameof(y));
                }
            }
        }
        public Image PreviewImage
        {
            get => this.previewImage;
            set
            {
                if(previewImage != value)
                {
                    previewImage = value;
                    OnPropertyChanged(nameof(previewImage));
                }
            }
        }
        public double Age()
        {
            if(dateOfBirth >= Timeline.Tick)
            {
                if(dateOfDeath < Timeline.Tick)
                    return Timeline.CustomRound(Math.Abs(dateOfDeath - dateOfBirth), 1);
                else
                    return Timeline.CustomRound(Math.Abs(Timeline.Tick - dateOfBirth), 1);
            }
            return 0.0;
        }
    }
}
