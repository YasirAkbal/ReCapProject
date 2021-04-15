using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T> 
    {
        //data ve mesaj var
        public ErrorDataResult(T data, string message) : base(data,false,message)
        {

        }

        //data var, mesaj yok
        public ErrorDataResult(T data) : base(data,false)
        {

        }

        //data yok, mesaj var
        public ErrorDataResult(string message) : base(default,false,message)
        {

        }

        public ErrorDataResult() : base(default,false)
        {

        }
    }
}
