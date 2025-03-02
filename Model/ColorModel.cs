using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlColors.Model
{
    public class XamlColorsAppSettings
    {
        public IEnumerable<ColorModel> Colors { get; set; }
    }

    public class ColorModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
