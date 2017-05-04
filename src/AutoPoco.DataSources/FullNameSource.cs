using AutoPoco.Engine;
using System;

namespace AutoPoco.DataSources
{
    public class FullNameSource : Engine.DatasourceBase<String>
    {
        private FirstNameSource _firstName;
        private LastNameSource _lastName;

        public FullNameSource()
        {
            _firstName = new FirstNameSource();
            _lastName = new LastNameSource();
        }

        public override String Next( IGenerationContext context )
        {
            return $"{_firstName.Next( context )} {_lastName.Next( context )}";
        }
    }
}