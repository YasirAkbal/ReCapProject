using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //data ve mesaj var
        public SuccessDataResult(T data, string message) : base(data,true,message)
        {

        }

        //data var, mesaj yok
        public SuccessDataResult(T data) : base(data,true)
        {

        }

        //data yok, mesaj var
        public SuccessDataResult(string message) : base(default,true,message)
        {

        }

        //hiçbir şey yok
        public SuccessDataResult() : base(default,true)
        {

        }
    }
}
