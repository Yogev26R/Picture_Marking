using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.Interface
{
    public interface IIDGeneratorService
    {
        public string GenerateID(string input);
    }
}
