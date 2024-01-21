using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WorldBuildingTool.Models
{
    public class MainWindowModel : ModelBase
    {
        private XmlDocument _document;
        public MainWindowModel()
        {
            _document = new XmlDocument();
        }

        public TimelineModel OpenProjectXML(string path)
        {
            Debug.WriteLine("Trying to read from: " + path);
            _document.LoadXml(path);

            // TODO:

            XmlNode firstTickNode = _document.GetElementsByTagName("FirstTick").Item(0);
            XmlNode currentTickNode = _document.GetElementsByTagName("CurrentTick").Item(0);
            XmlNode lastTickNode = _document.GetElementsByTagName("LastTick").Item(0);

            double firstTick = 0.0;
            double currentTick = 0.0;
            double lastTick = 0.0;
            if(firstTickNode != null)
                Convert.ToDouble(firstTickNode.Value);
            if(currentTickNode != null)
                Convert.ToDouble(currentTickNode.Value);
            if(lastTickNode != null)
                Convert.ToDouble(lastTickNode.Value);

            return new TimelineModel(firstTick, currentTick, lastTick);
        }
    }
}
