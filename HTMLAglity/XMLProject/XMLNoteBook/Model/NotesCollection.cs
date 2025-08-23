using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLNoteBook.Model
{
    [XmlRoot("Notes")]
    public class NotesCollection
    {
        [XmlElement("Note")]
        public List<Note> Notes { get; set; } = new();

    }
}
