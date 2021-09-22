using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoFallesAsiste.WebApp.Validation
{
    public class DateValidation
    {
        public const int durationTecnologyMin = 720;//2
        public const int durationTecnologyMax = 800;//2
        public const int durationSpecializationMin = 240;//3
        public const int durationSpecializationMax = 300;//3
        public const int durationTechnicalMin = 360;//1
        public const int durationTechnicalMax = 400;//1
        public const int durationPracticeMin = 165;
        public const int durationPracticeMax = 205;
        public int numberDayStart { get; set; }
        public int numberDayEnd { get; set; }
        public DateTime StartTraining { get; set; }
        public DateTime EndTraining { get; set; }

        public DateValidation()
        {

        }
        public DateValidation(DateTime startTraining, DateTime endTraining)
        {
            StartTraining = startTraining;
            EndTraining = endTraining;
            numberDayStart = 365 - StartTraining.DayOfYear;
            numberDayEnd = EndTraining.DayOfYear;
        }

        public bool IsValidDurationTraining(DateTime startTraining, DateTime endTraining, int typeProgram)
        {
            StartTraining = startTraining;
            EndTraining = endTraining;
            numberDayStart = 365 - StartTraining.DayOfYear;
            numberDayEnd = EndTraining.DayOfYear;

            var time = numberDayStart + numberDayEnd + (((EndTraining.Year - StartTraining.Year) - 1) * 365);

            if (typeProgram > 3 || typeProgram < 1)
            {
                return false;
            }
            if (typeProgram == 1)
            {
                if (time < durationTechnicalMin || time > durationTechnicalMax) return false;
                return true;
            }
            if (typeProgram == 2)
            {
                if (time < durationTecnologyMin || time > durationTecnologyMax) return false;
                return true;
            }
            if (typeProgram == 3)
            {
                if (time < durationSpecializationMin || time > durationSpecializationMax) return false;
                return true;
            }

            return false;
        }

    }
}
