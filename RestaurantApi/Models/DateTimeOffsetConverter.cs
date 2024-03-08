using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestaurantApi.Models;

public class DateTimeOffsetConverter : IsoDateTimeConverter
{
    public DateTimeOffsetConverter(){
        base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
    }
}
