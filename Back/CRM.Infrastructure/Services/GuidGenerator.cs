using CRM.Domain.Interfaces;

namespace CRM.Infrastructure.Services;

public class GuidGenerator : IGuidGenerator
{
    public Guid NewGuid()
    {
        var guidArray = Guid.NewGuid().ToByteArray();
        var now = DateTime.UtcNow;

        var days = BitConverter.GetBytes((short)(now - new DateTime(1900, 1, 1)).Days);
        var msecs = BitConverter.GetBytes((int)(now.TimeOfDay.TotalMilliseconds / 3.333333));

        guidArray[0] = days[1];
        guidArray[1] = days[0];
        guidArray[2] = msecs[3];
        guidArray[3] = msecs[2];
        guidArray[4] = msecs[1];
        guidArray[5] = msecs[0];

        return new Guid(guidArray);
    }
}