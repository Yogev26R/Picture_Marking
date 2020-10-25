using Contracts;
using PictureMarkingContracts.Interface;
using System;
using System.Text;

namespace IDGeneratorService
{
    [Register(Policy.Transient, typeof(IIDGeneratorService))]
    public class IDGeneratorImpl : IIDGeneratorService
    {
        public IDGeneratorImpl() { }

        public string GenerateID(string input)
        {
            var retval = "";
            var md5 = System.Security.Cryptography.MD5.Create();
            var ticks = DateTime.Now.Ticks;
            // input + ticks 
            var bytes = System.Text.Encoding.ASCII.GetBytes(input + ticks);
            var hashBytes = md5.ComputeHash(bytes);           
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            retval = sb.ToString();

            return retval;
        }
    }
}
