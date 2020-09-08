using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker.Actions
{
    /**
     * An implementation of the Command design pattern. It represnts an asynchronous action.
     */
    public interface AsyncAction
    {
        Task Do();
    }
}
