using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        //Na atualização precisa do Id do produto
        public int Id { get; set; }
    }
}
