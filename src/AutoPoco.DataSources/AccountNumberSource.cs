using AutoPoco.Engine;
using System;

namespace AutoPoco.DataSources
{
    public class AccountNumberSource : Engine.DatasourceBase<String>
    {
        private String Prefix = "AC";
        private Int32 Length = 8;
        private IntegerSource _Integer;

        public AccountNumberSource( String prefix ) : this( prefix, 8 )
        {
        }

        public AccountNumberSource( Int32 length ) : this( "AC", length )
        {
        }

        public AccountNumberSource() : this( "AC", 8 )
        {
        }

        public AccountNumberSource( String prefix, Int32 length )
        {
            Length = length < 0 ? ( -length ) : length;
            Prefix = prefix;

            _Integer = new IntegerSource( 0, 9 );
        }

        public override String Next( IGenerationContext context )
        {
            String num = "";

            do
            {
                num += _Integer.Next( context );
            } while ( num.Length < Length );

            return $"{Prefix}{num}".Substring( 0, Length );
        }
    }
}