using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Core.Repositories
{
    public interface IShakespeareWebAppRepository
    {
        Task<string> TranslateText(string text);
    }
}
