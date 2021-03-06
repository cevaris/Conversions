﻿using System;
using System.Collections.Generic;
using System.Linq;
using Conversion.Resx;

namespace Conversion
{
    public enum UnitGroup
    {
        data,
        distance,
        speed,
        temperature,
        time,
        weight
    }

    public enum UnitType
    {
        // Data
        bit,      // 1 bit
        _byte,    // 8 bits

        kilobit,  // 1000 bits
        megabit,
        gigabit,
        terabit,
        petabit,
        exabit,

        kibibit,  // 1024 bits
        mebibit,
        gibibit,
        tebibit,
        pebibit,
        exbibit,

        kilobyte, // 1000 bytes
        megabyte,
        gibibyte,
        terabyte,
        petabyte,
        exabyte,

        kibibyte, // 1024 bytes
        mebibyte,
        gigabyte,
        tebibyte,
        pebibyte,
        exbibyte,


        // Distance
        femtometer,
        picometer,
        nanometer,
        micrometer,
        millimeter,
        centimeter,
        decimeter,
        meter,
        decameter,
        hectometer,
        kilometer,
        megameter,
        gigameter,

        inch,
        foot,
        yard,
        mile,
        nautical_mile,

        // Speed
        metersPerSecond,
        kilometersPerHour,
        milePerHour,
        knot,
        feetPerSecond,

        // Temperature
        celsius,
        fahrenheit,
        kelvin,
        reaumur,
        newton,
        rankine,

        // Time
        femtosecond,
        picosecond,
        nanosecond,
        microsecond,
        millisecond,
        second,
        hour,
        minute,
        day,
        week,
        fortnight,
        month,
        year,
        decade,
        century,
        millennium,

        // Weight
        microgram,
        milligram, //1/1K grams
        centigram,
        decigram, // 1/10 gram
        carat, // 1/5 gram
        gram,
        decagram,
        hectogram,
        kilogram, //1K grams
        megagram_metric_ton, //1K Kg

        grain,
        dram,
        ounce,
        pound,
        stone,
        us_ton,
        imperial_ton,
    }

    class Units
    {
        public static List<UnitGroup> UnitGroups = Enum.GetValues(typeof(UnitGroup))
                                                       .Cast<UnitGroup>()
                                                       .ToList();

        public static IDictionary<UnitType, string> UnitTypeAbbrNameMap = new Dictionary<UnitType, string>()
        {
            {UnitType.bit, "b"},
            {UnitType._byte, "B"},

            {UnitType.kilobit, "kib"},
            {UnitType.megabit, "Mb"},
            {UnitType.gigabit, "Gb"},
            {UnitType.terabit, "Tb"},
            {UnitType.petabit, "Pb"},
            {UnitType.exabit, "Eb"},

            {UnitType.kibibit, "Kib"},
            {UnitType.mebibit, "Mib"},
            {UnitType.gibibit, "Gib"},
            {UnitType.tebibit, "Tib"},
            {UnitType.pebibit, "Pib"},
            {UnitType.exbibit, "Exb"},

            {UnitType.kilobyte, "kB"},
            {UnitType.megabyte, "MB"},
            {UnitType.gigabyte, "GB"},
            {UnitType.terabyte, "TB"},
            {UnitType.petabyte, "PB"},
            {UnitType.exabyte, "EB"},

            {UnitType.kibibyte, "KiB"},
            {UnitType.mebibyte, "MiB"},
            {UnitType.gibibyte, "GiB"},
            {UnitType.tebibyte, "TiB"},
            {UnitType.pebibyte, "PiB"},
            {UnitType.exbibyte, "EiB"},

            {UnitType.femtometer, "fm"},
            {UnitType.picometer, "pm"},
            {UnitType.nanometer, "nm"},
            {UnitType.micrometer, "µm"},
            {UnitType.millimeter, "mm"},
            {UnitType.centimeter, "cm"},
            {UnitType.decimeter, "dm"},
            {UnitType.meter, "m"},
            {UnitType.decameter, "dam"},
            {UnitType.hectometer, "hm"},
            {UnitType.kilometer, "km"},
            {UnitType.megameter, "Mm"},
            {UnitType.gigameter, "Gm"},

            {UnitType.inch, "in"},
            {UnitType.foot, "ft"},
            {UnitType.yard, "yd"},
            {UnitType.mile, "mi"},
            {UnitType.nautical_mile, "n.m."},

            {UnitType.metersPerSecond, "m/s"},
            {UnitType.kilometersPerHour, "km/h"},
            {UnitType.milePerHour, "mph"},
            {UnitType.knot, "kn"},
            {UnitType.feetPerSecond, "ft/s"},

            {UnitType.celsius, "°C"},
            {UnitType.fahrenheit, "°F"},
            {UnitType.kelvin, "°K"},
            {UnitType.rankine, "°R"},

            {UnitType.femtosecond, "fs"},
            {UnitType.picosecond, "ps"},
            {UnitType.nanosecond, "ns"},
            {UnitType.microsecond, "µs"},
            {UnitType.millisecond, "ms"},
            {UnitType.second, "s"},
            {UnitType.minute, "min"},
            {UnitType.hour, "h"},
            //{UnitType.day, ""},
            {UnitType.week, "wk"},
            //{UnitType.fortnight, ""},
            {UnitType.month, "mth"},
            {UnitType.year, "yr"},
            //{UnitType.decade, ""},
            //{UnitType.century, "C"},
            //{UnitType.millennium, ""},


            {UnitType.microgram, "µg"},
            {UnitType.milligram, "mg"}, //1/1K grams
            {UnitType.centigram, "cg"},
            {UnitType.decigram, "dg"},
            {UnitType.carat, "c"},
            {UnitType.gram, "g"},
            {UnitType.decagram, "dag"},
            {UnitType.hectogram, "hg"},
            {UnitType.kilogram, "kg"}, //1K grams
            {UnitType.megagram_metric_ton, "Mg/t"}, //1K kg

            {UnitType.grain, "gr"},
            {UnitType.dram, "dr"},
            {UnitType.ounce, "oz"},
            {UnitType.pound, "lb"},
            {UnitType.stone, "st"},
            {UnitType.us_ton, "t"},
            {UnitType.imperial_ton, "t"},
        };

        public static IDictionary<UnitGroup, Converter> ConverterMap = new Dictionary<UnitGroup, Converter>()
        {
            {UnitGroup.data, Source.Groups.Data.Instance},
            {UnitGroup.distance, Source.Groups.Distance.Instance},
            {UnitGroup.speed, Source.Groups.Speed.Instance},
            {UnitGroup.temperature, Source.Groups.Tempurature.Instance},
            {UnitGroup.time, Source.Groups.Time.Instance},
            {UnitGroup.weight, Source.Groups.Weight.Instance},
        };

        public static string T(UnitGroup unitGroup)
        {
            string result = AppResources.ResourceManager.GetString(unitGroup.ToString(), App.CurrentCultureInfo);
            if (!string.IsNullOrWhiteSpace(result))
            {
                return result;
            }
            else
            {
                return unitGroup.ToString();
            }
        }

        public static string T(UnitType unitType)
        {
            string result = AppResources.ResourceManager.GetString(unitType.ToString(), App.CurrentCultureInfo);
            if (!string.IsNullOrWhiteSpace(result))
            {
                return result;
            }
            else
            {
                return unitType.ToString();
            }
        }

        public static string TAbbr(UnitType unitType)
        {
            string result = null;            
            UnitTypeAbbrNameMap.TryGetValue(unitType, out result);
            return result;
        }
    }
}
