using System.Collections.ObjectModel;

namespace ComponentAndHttpErrorsHandling.Utilities;

public class ExceptionRecorderService
{
    public ObservableCollection<Exception> Exceptions { get; set; } = new();
}
