using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Classes
{
    public class TextFileEntity : FileEntity
    {
        private string _insideContent;
        public TextFileEntity(string name, string path, string insideContent = "") : base(name, path)
        {
            this._insideContent = insideContent;
        }
        public TextFileEntity(FileInfo file) : base(file)
        {

        }
        public override void CreateEntity()
         {
            string file = System.IO.Path.Combine(this.Path, this.Name);
            if (!File.Exists(file))
            {
                if (!this.Name.EndsWith(".txt"))
                {
                    this.Name += ".txt";
                    file += ".txt";
                }
                FileStream fs = File.Create(file);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(this._insideContent);

                sw.Dispose();

                fs.Dispose();
            }
        }

        public override void DeleteEntity()
        {
            if(this._fileInfo != null)
            {
                this._fileInfo.Delete();
            }
        }
    }
}
