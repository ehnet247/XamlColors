using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlColors.Model
{
    public interface ICloseableViewModel
    {
        public void Closing();
    }
}
