using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Presenters.Interfaces
{
    public interface IPresenter<out TFormatDataType>
    {
        TFormatDataType Content { get; }
    }
}
