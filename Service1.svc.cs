using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace WCFService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public bool UploadFile(string filename, string practiceid, long fileSise, byte[] fileBytes)
        {
            const int BUFFERSIZE = 4 * 1024;
            string rootDirectoty = @"C:\NewFile\Practice" + practiceid.ToString();
            if (!Directory.Exists(rootDirectoty))
                Directory.CreateDirectory(rootDirectoty);
            string filePath = rootDirectoty + "\\" + filename;
            Stream stream = new MemoryStream(fileBytes);
            using (stream) // data is the Stream value.
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Append))
                    {
                        using (BinaryWriter writer = new BinaryWriter(fs))
                        {

                            byte[] buffer = reader.ReadBytes(BUFFERSIZE);
                            writer.Write(buffer);
                        }
                    }
                }
            }
            return true;
        }

       
    }
    
}
