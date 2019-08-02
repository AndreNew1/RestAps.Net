using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Principal;
using Calculadora.Data.Converters;
using Calculadora.Data.VO;
using Calculadora.Model;
using Calculadora.Repository;
using Calculadora.Repository.Generic;
using Calculadora.Security.Configuration;

namespace Calculadora.Business.Implementattions
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fullpath = path + "\\Other\\Guia-de-Configura-o-de-Ambiente-Windows.pdf";
            return File.ReadAllBytes(fullpath);
        }
    }
}
