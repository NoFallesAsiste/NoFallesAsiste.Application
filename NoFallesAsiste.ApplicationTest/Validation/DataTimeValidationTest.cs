using NoFallesAsiste.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NoFallesAsiste.ApplicationTest.Validation
{
    public class DataTimeValidationTest
    {
        private readonly DateValidation _dateValidation;

        public DataTimeValidationTest()
        {
            _dateValidation = new DateValidation();
        }
        [Fact]
        public void _dateValidation_validDateStartAndEnd_ReturnsTrue()
        {
            Assert.True(_dateValidation.IsValidDurationTraining(new DateTime(2021,09,19), new DateTime(2022, 09, 19), 1));
            Assert.True(_dateValidation.IsValidDurationTraining(new DateTime(2021,09,19), new DateTime(2023, 09, 19), 2));
            Assert.True(_dateValidation.IsValidDurationTraining(new DateTime(2021,09,19), new DateTime(2022, 05, 19), 3));

        }

        [Fact]
        public void _dateValidation_InvalidTypeProgram_ReturnsFalse()
        {
            Assert.False(_dateValidation.IsValidDurationTraining(new DateTime(2021, 09, 19), new DateTime(2022, 09, 19), 0));
            Assert.False(_dateValidation.IsValidDurationTraining(new DateTime(2021, 09, 19), new DateTime(2023, 09, 19), -1));
            Assert.False(_dateValidation.IsValidDurationTraining(new DateTime(2021, 09, 19), new DateTime(2022, 05, 19), 4));

        }


        public static readonly object[][] Data =
        {
            new object[] { new DateTime(2021, 09, 19), new DateTime(2022, 11, 01), 1 },
            new object[] { new DateTime(2021, 09, 19), new DateTime(2023, 12, 24), 2 },
            new object[] { new DateTime(2021, 09, 19), new DateTime(2022, 09, 19), 3 }
        };


        [Theory]
        [MemberData(nameof(Data))]
        public void IsValidDurationTrainingTecnology_DateInvalidMax_WithTheory_ReturnFalse(DateTime startTraining, DateTime endTraining, int typeProgram)
        {
            Assert.False(_dateValidation.IsValidDurationTraining(startTraining, endTraining, typeProgram));
        }

        public static readonly object[][] Data1 =
        {
            new object[] { new DateTime(2021, 09, 19), new DateTime(2022, 7, 01), 1 },
            new object[] { new DateTime(2021, 09, 19), new DateTime(2023, 8, 24), 2 },
            new object[] { new DateTime(2021, 09, 19), new DateTime(2022, 5, 15), 3 }
        };


        [Theory]
        [MemberData(nameof(Data1))]
        public void IsValidDurationTrainingTecnology_DateInvalidMin_WithTheory_ReturnFalse(DateTime startTraining, DateTime endTraining, int typeProgram)
        {
            Assert.False(_dateValidation.IsValidDurationTraining(startTraining, endTraining, typeProgram));
        }


    }
}
