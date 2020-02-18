using APIX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIX.Dal
{
   public  interface IMetodosLogin
    {
        IEnumerable<LoginDto>Get();
        int Post(LoginDto dto);
        int Put(LoginDto dto);
        LoginDto ObterPorId(int id);
        int Delete(int id);
        LoginDto ValidarLogin(string nome, string email);
    }
}
