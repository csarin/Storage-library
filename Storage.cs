//----------------------------------------------------------------------------------//
//<author> César Reneses Cárcamo </author> 
//<date> 04/05/2016  </date> 
//<summary> Storage helper for Universal Windows Platform </summary> 
//<website> http://cesarreneses.net </website>
//----------------------------------------------------------------------------------//

namespace StorageLibrary
{
    #region Namespaces
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Storage;
    #endregion

    public static class Storage
    {
        #region Public Methods
        public static async Task Save(string filename, string value)
        {
            var folder = ApplicationData.Current.RoamingFolder;
            var file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            using (var stream = await file.OpenStreamForWriteAsync())
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                await writer.WriteAsync(value);
            }
        }

        public static async Task<string> Load(string value)
        {
            var folder = ApplicationData.Current.RoamingFolder;
            var file = await folder.GetFileAsync(value);
            string json = string.Empty;

            using (var stream = await file.OpenStreamForReadAsync())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                json = await reader.ReadToEndAsync();
            }

            return json;
        }
        #endregion
    }
}
