using System;

namespace UMV.Reference.Patterns.Base.Interfaces
{
    public interface ISpannable
    {
        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }
    }
}