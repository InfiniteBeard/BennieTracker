using System;
using System.Collections.Generic;
using System.Text;

namespace BennieTracker.Actions
{
    /**
     * An implementation of the Command design pattern. It represents a syncrhonous action.
     */
    interface Action
    {
        bool Do();
    }
}
