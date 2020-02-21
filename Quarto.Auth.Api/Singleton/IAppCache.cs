using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarto.Auth.Api.Singleton
{
    public interface IAppCache
    {
        public string AppSecret { get; set; }
    }
}
