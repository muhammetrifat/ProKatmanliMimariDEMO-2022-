using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this, clasın kendisi demektir(Result)
        //burada Constructor'ların güzel bir kullanımı var. Tekrar edilesi.
        public Result(bool success, string message) : this(success)
        {
            Message = message;//lakin readonly'ler constructorda SET EDİLEBİLİRLER
                              //set ekleyebilir ve buna gerek bırakmayabilirdik, lakin yaptığımız yöntem, programın kullanımı standardize etmeye yarar
        }
        public Result(bool success)//overloading yaparak mesaj döndürmeden de kullanabiliriz.
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }//set edilemez, yani değiştirilemez(readonly)
    }
}
