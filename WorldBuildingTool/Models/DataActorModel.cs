﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorldBuildingTool.Models
{
    public class DataActorModel : DataObjectModel
    {
        private static int _id = 0;
        public DataActorModel(string name, string description, double dateOfBirth, double dateOfDeath, Image previewImage) : base(name, description, dateOfBirth, dateOfDeath, previewImage)
        {
            this.ID = _id++;
        }
    }
}