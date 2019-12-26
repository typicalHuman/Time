using System;
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
            ClearFileContent();
            using (FileStream fs = new FileStream("TimeData.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, coll);
            }
        }

        private void ClearFileContent()
        {
            StreamWriter sr = new StreamWriter("TimeData.xml", false);
            sr.WriteLine("");
            sr.Close();
        }

        public void Deserialize()
        {
            ObservableCollection<WorkData> tempList = _Deserialize();
            if (tempList?.Count > 0)
            {
                App.MainVM.WorkDatas = tempList;
                App.MainVM.SelectedData = App.MainVM.WorkDatas[0];
                if (App.MainVM.SelectedData.Date == $"Date: {DateTime.Now.ToShortDateString()}")
                    App.MainVM.IsEnabled = true;
                App.MainVM.SelectedData.Timer.IsStart = false;

            }
        }

        private ObservableCollection<WorkData> _Deserialize()
        {
            ObservableCollection<WorkData> coll = null;
            try
            {
                using (FileStream fs = File.OpenRead("TimeData.xml"))
                {
                    coll = (ObservableCollection<WorkData>)serializer.Deserialize(fs);
                }
            }
            catch (FileNotFoundException) { }
            return coll;
        }
    }
}
