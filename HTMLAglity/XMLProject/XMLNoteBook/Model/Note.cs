using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLNoteBook.Model
{
    public class Note
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute]
        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        [XmlArray("Tags")]
        [XmlArrayItem("Tag")]
        public List<string> Tags { get; set; }

    }
}
