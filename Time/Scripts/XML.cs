using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using Time.Model;

namespace Time.Scripts
{
    class XML
    {
        private XmlSerializer serializer { get; set; } = new XmlSerializer(typeof(ObservableCollection<WorkData>));

        public void Serialize(ObservableCollection<WorkData> coll)
        {
            using (FileStream fs = new FileStream("TimeData.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, coll);
            }
        }

        public ObservableCollection<WorkData> Deserialize()
        {
            ObservableCollection<WorkData> coll = null;
            using (FileStream fs = new FileStream("TimeData.xml", FileMode.OpenOrCreate))
            {
                coll = (ObservableCollection<WorkData>)serializer.Deserialize(fs);
            }
            return coll;
        }
    }
}
